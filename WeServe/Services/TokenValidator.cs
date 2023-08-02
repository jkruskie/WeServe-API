using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

/// <summary>
/// JWT Token Validator
/// </summary>
/// <author>Justin Kruskie</author>
/// <date>07/28/2023</date>
public class TokenValidator
{
    private readonly byte[] _refreshTokenSecret;
    private readonly string _issuer;
    private readonly string _audience;

    /// <summary>
    /// Constructor for testing
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public TokenValidator()
    {
        _refreshTokenSecret = new byte[32];
        _issuer = "issuer";
        _audience = "audience";
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="config"></param>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public TokenValidator(IConfiguration config)
    {
        _refreshTokenSecret = Encoding.ASCII.GetBytes(config.GetValue<string>("Jwt:RefreshTokenSecret"));
        _issuer = config.GetValue<string>("Jwt:Issuer");
        _audience = config.GetValue<string>("Jwt:Audience");
    }

    /// <summary>
    /// Validate a refresh token
    /// </summary>
    /// <param name="refreshToken">Refresh Token</param>
    /// <param name="tokenId">Return Token Id</param>
    /// <returns>True or false</returns>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public bool TryValidate(string refreshToken, out Guid tokenId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(_refreshTokenSecret),
            ValidateIssuer = true,
            ValidateAudience = true,
            ClockSkew = TimeSpan.Zero,
            ValidAudience = _audience,
            ValidIssuer = _issuer,
        };

        try
        {
            tokenHandler.ValidateToken(refreshToken, tokenValidationParams, out SecurityToken token);
            var jwt = (JwtSecurityToken)token;
            var valid = Guid.TryParse(jwt.Id, out var id);
            tokenId = id;
            return valid;
        }
        catch (Exception)
        {
            tokenId = default;
            return false;
        }
    }
}
