namespace WeServe.DTO
{
    public class TokenResponseDTO
    {
        private UserDTO userDTO;

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
}
