using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeServe.Data;
using WeServe.DTO;
using WeServe.Models;
using WeServe.Repositories;
using WeServe.Services;
using WeServe.Validation;

namespace WeServe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        // Repository
        private readonly WeServeContext _context;
        private readonly UserManager<User> _users;
        private readonly TokenGenerator _tokens;
        private readonly TokenRepository _repository;
        private readonly TokenValidator _tokenValidator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="users">User manager</param>
        /// <param name="tokens">Token generator</param>
        /// <param name="repository">Token repository</param>
        /// <param name="tokenValidator">Token validator</param>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public AuthenticationController(
            WeServeContext context,
            UserManager<User> users,
            TokenGenerator tokens,
            TokenRepository repository,
            TokenValidator tokenValidator
        )
        {
            _context = context;
            _users = users;
            _tokens = tokens;
            _repository = repository;
            _tokenValidator = tokenValidator;
        }

        /// <summary>
        /// Get the currently logged in user
        /// </summary>
        /// <returns>Current user DTO</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            // Get the user's ID from the claims, which is the NameIdentifier
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            // Get the user's ID from the claims
            if (userId is null) return BadRequest("User not found.");

            // Get the user from the database with their company
            var user = await _users.FindByIdAsync(userId);

            // Check if the user exists
            if (user is null) return BadRequest("User not found.");

            // Create a new user DTO
            var userDTO = new UserDTO(user);

            // Return the user
            return Ok(userDTO);
        }

        /// <summary>
        /// Sign in a user
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>TokenResponseDTO</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] SigninUserDTO credentials)
        {
            // Create a new validator
            SigninUserDTOValidator validator = new SigninUserDTOValidator();

            // Get the validation result
            ValidationResult validationResult = validator.Validate(credentials);

            // Check if the validation failed
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            // Get the user from the database
            var user = await _users.FindByEmailAsync(credentials.Email);

            // Check if the user exists
            if (user is null) return BadRequest("User not found.");

            // Compare the password to the user's password
            var result = await _users.CheckPasswordAsync(user, credentials.Password);

            // Check if the password is correct
            if (!result) return BadRequest("Invalid password.");

            // Generate the access token
            var accessToken = _tokens.GenerateAccessToken(user);

            // Generate the refresh token
            var (refreshTokenId, refreshToken) = _tokens.GenerateRefreshToken();

            // Add the refresh token to the database
            await _repository.Tokens.AddAsync(new Token { Id = refreshTokenId, UserId = user.Id });

            // Save the changes
            await _repository.SaveChangesAsync();

            // Get the response
            var response = HttpContext.Response;

            // Add the refresh token to the response
            response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                IsEssential = true,
                MaxAge = new TimeSpan(1, 0, 0, 0),
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            // Create new user DTO
            var userDTO = new UserDTO(user);

            // Create new tokenresponsedto with 30 min expiration
            var tokenResponse = new TokenResponseDTO(accessToken, refreshToken, userDTO, 30 * 60);

            // Return the token response
            return Ok(tokenResponse);
        }

        /// <summary>
        /// Sign up a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>New user DTO</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] CreateUserDTO user)
        {
            // Create a new validator
            CreateUserDTOValidator validator = new CreateUserDTOValidator();

            // Get the validation result
            ValidationResult result = validator.Validate(user);

            // Check if the validation failed
            if (!result.IsValid) return BadRequest(result.Errors);

            // Check if the user already exists
            if (_users.Users.Any(u => u.Email == user.Email))
            {
                return Conflict("Invalid `email`: A user with this email address already exists.");
            }

            // Create a new user
            var newuser = new User(user);

            // Create the user
            var creationResults = await _users.CreateAsync(newuser, user.Password);

            if (!creationResults.Succeeded) return BadRequest(creationResults.Errors);

            // Create a new user DTO
            var newUserDTO = new UserDTO(newuser);

            return Created($"/users/{newuser.Id}", newUserDTO);
        }

        //[HttpPost("refresh-token")]
        //public async Task<IActionResult> RefreshTokenAsync()
        //{
        //    var request = HttpContext.Request;

        //    var refreshToken = request.Cookies["refresh_token"];

        //    if (string.IsNullOrWhiteSpace(refreshToken))
        //        return BadRequest("Please include a refresh token in the request.");

        //    var tokenIsValid = _tokenValidator.TryValidate(refreshToken, out var tokenId);
        //    if (!tokenIsValid) return BadRequest("Invalid refresh token.");

        //    var token = await _repository.Tokens.Where(token => token.Id == tokenId).FirstOrDefaultAsync();
        //    if (token is null) return BadRequest("Refresh token not found.");

        //    var user = await _users.Users.Where(u => u.Guid == token.UserId).FirstOrDefaultAsync();
        //    if (user is null) return BadRequest("User not found.");

        //    var accessToken = _tokens.GenerateAccessToken(user);
        //    var (newRefreshTokenId, newRefreshToken) = _tokens.GenerateRefreshToken();

        //    _repository.Tokens.Remove(token);
        //    await _repository.Tokens.AddAsync(new Token { Id = newRefreshTokenId, UserId = user.Guid });
        //    await _repository.SaveChangesAsync();

        //    var response = HttpContext.Response;

        //    response.Cookies.Append("refresh_token", newRefreshToken, new CookieOptions
        //    {
        //        Expires = DateTime.Now.AddDays(1),
        //        HttpOnly = true,
        //        IsEssential = true,
        //        MaxAge = new TimeSpan(1, 0, 0, 0),
        //        Secure = true,
        //        SameSite = SameSiteMode.Strict
        //    });

        //    return Ok(accessToken);
        //}
    }
}
