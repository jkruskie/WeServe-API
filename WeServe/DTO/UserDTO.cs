using System.ComponentModel.DataAnnotations;
using WeServe.Models;

namespace WeServe.DTO
{
    /// <summary>
    /// The data transfer object for a user.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Age { get; set; }
        public string Year { get; set; }
        public string Major { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public Boolean IsBanned { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Create a new instance of the user data transfer object.
        /// </summary>
        /// <param name="user"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public UserDTO(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
            Age = user.Age.ToString();
            Year = user.Year;
            Major = user.Major;
            Bio = user.Bio;
            ProfilePicture = user.ProfilePicture;
            IsBanned = user.IsBanned;
            IsDeleted = user.IsDeleted;
            CreatedAt = user.CreatedAt;
        }
    }

    /// <summary>
    /// The data transfer object for signing in a user.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class LoginUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    /// <summary>
    /// The data transfer object for signing up a user.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class CreateUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        public string? Age { get; set; }
        public string? Year { get; set; }
        public string? Major { get; set; }
        public string? Bio { get; set; }
    }
}
