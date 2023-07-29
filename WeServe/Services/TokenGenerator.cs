using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeServe.Models;

namespace WeServe.Services
{
    /// <summary>
    /// JWT Token Generator
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class TokenGenerator
    {
        private readonly byte[] _accessTokenSecret;
        private readonly byte[] _refreshTokenSecret;
        private readonly string _issuer;
        private readonly string _audience;

        /// <summary>
        /// Constructor for testing
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public TokenGenerator()
        {
            _accessTokenSecret = new byte[32];
            _refreshTokenSecret = new byte[32];
            _issuer = "issuer";
            _audience = "audience";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">App configuration for secret values</param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public TokenGenerator(IConfiguration config)
        {
            _accessTokenSecret = Encoding.ASCII.GetBytes(config.GetValue<string>("Jwt:AccessTokenSecret"));
            _refreshTokenSecret = Encoding.ASCII.GetBytes(config.GetValue<string>("Jwt:RefreshTokenSecret"));
            _issuer = config.GetValue<string>("Jwt:Issuer");
            _audience = config.GetValue<string>("Jwt:Audience");
        }

        /// <summary>
        /// Generate a JWT Access Token for a specific user
        /// </summary>
        /// <param name="user">The user the token is generated for</param>
        /// <returns>A token as a string</returns>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string GenerateAccessToken(User user)
        {
            var date = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					// GUID
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					// Company Guid
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    }
                ),
                NotBefore = date,
                Expires = date.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_accessTokenSecret),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _issuer,
                Audience = _audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Generate a refresh token
        /// </summary>
        /// <returns>A token id as Guid, and token as String</returns>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public (Guid, string) GenerateRefreshToken()
        {
            var tokenId = Guid.NewGuid();
            var tokenHandler = new JwtSecurityTokenHandler();

            var date = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(JwtRegisteredClaimNames.Jti, tokenId.ToString()), }),
                NotBefore = date,
                Expires = date.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_refreshTokenSecret),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _issuer,
                Audience = _audience,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenId, tokenHandler.WriteToken(token));
        }
    }
}