using System.ComponentModel.DataAnnotations;

namespace WeServe.DTO
{
    /// <summary>
    /// Token response DTO
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public class TokenResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public UserDTO User { get; set; }
        public int ExpiresIn { get; set; }
        public TokenResponseDTO() { }
        public TokenResponseDTO(string token, string refreshToken, UserDTO user, int expiresIn)
        {
            AccessToken = token;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
            User = user;
        }
    }

    /// <summary>
    /// Refresh token DTO
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public class RefreshTokenDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
