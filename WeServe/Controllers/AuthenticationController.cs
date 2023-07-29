using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly WeServeContext _context;
        private readonly UserManager<User> _users;
        private readonly TokenGenerator _tokens;
        private readonly TokenRepository _repository;
        private readonly TokenValidator _tokenValidator;

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


        //[HttpGet("me")]
        //[Authorize]
        //public async Task<IActionResult> GetCurrentUserAsync()
        //{
        //    // Get the user's ID from the claims, which is the NameIdentifier
        //    var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        //    // Get the user's ID from the claims
        //    if (userId is null)
        //    {
        //        return BadRequest("Invalid token.");
        //    }

        //    // Get the user from the database with their company
        //    var user = await _users.Users
        //        //.Include(u => u.Company)
        //        .FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

        //    // Check if the user exists
        //    if (user is null)
        //    {
        //        return NotFound("User not found.");
        //    }

        //    // Return the user
        //    return Ok(user);
        //}


        //[HttpPost("signin")]
        //public async Task<IActionResult> SignInAsync([FromBody] LoginUserDTO credentials)

        //{
        //    if (credentials is null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!MiniValidator.TryValidate(credentials, out var errors))
        //    {
        //        return BadRequest(errors);
        //    }

        //    var isUsingEmailAddress = EmailAddressValidator.TryValidate(credentials.Email, out var _);
        //    var user = isUsingEmailAddress
        //        ? await _users.FindByEmailAsync(credentials.Email)
        //        : await _users.FindByNameAsync(credentials.Email);
        //    if (user is null)
        //    {
        //        return NotFound("User with this email address not found.");
        //    }

        //    var result = await _users.CheckPasswordAsync(user, credentials.Password);
        //    if (!result)
        //    {
        //        return BadRequest("Incorrect password.");
        //    }

        //    var accessToken = _tokens.GenerateAccessToken(user);
        //    var (refreshTokenId, refreshToken) = _tokens.GenerateRefreshToken();

        //    await _repository.Tokens.AddAsync(new Token { Id = refreshTokenId, UserId = user.Guid });
        //    await _repository.SaveChangesAsync();

        //    var response = HttpContext.Response;

        //    response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
        //    {
        //        Expires = DateTime.Now.AddDays(1),
        //        HttpOnly = true,
        //        IsEssential = true,
        //        MaxAge = new TimeSpan(1, 0, 0, 0),
        //        Secure = true,
        //        SameSite = SameSiteMode.Strict
        //    });

        //    // Create new user DTO
        //    var userDTO = new UserDTO(user);

        //    // Create new tokenresponsedto with 30 min expiration
        //    var tokenResponse = new TokenResponseDTO(accessToken, userDTO, 30 * 60);

        //    return Ok(tokenResponse);
        //}

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] CreateUserDTO user)
        {
            // Check if the user is null
            if (user is null) return BadRequest();

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

        [HttpPost("signout")]
        public async Task<IActionResult> SignOutAsync()
        {
            var request = HttpContext.Request;

            var refreshToken = request.Cookies["refresh_token"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest("Please include a refresh token in the request.");

            var tokenIsValid = _tokenValidator.TryValidate(refreshToken, out var tokenId);
            if (!tokenIsValid) return BadRequest("Invalid refresh token.");

            var token = await _repository.Tokens.Where(token => token.Id == tokenId).FirstOrDefaultAsync();
            if (token is null) return BadRequest("Refresh token not found.");

            _repository.Tokens.Remove(token);
            await _repository.SaveChangesAsync();

            var response = HttpContext.Response;

            response.Cookies.Delete("refresh_token");
            return NoContent();
        }
    }
}
