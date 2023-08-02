using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WeServe.DTO;

namespace WeServe.Models
{
    /// <summary>
    /// The user model for the application.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }
        public string Role { get; set; } = "User"; // Student, Organization, Moderator, Admin
        public string? Year { get; set; } = "Freshman";
        public string? Major { get; set; } = "Undeclared";
        public string? Bio { get; set; } = "This user has not set a bio yet.";
        public string? ProfilePicture { get; set; } = "https://placehold.co/320x320";
        public Boolean IsBanned { get; set; } = false;
        public Boolean IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Create a new instance of the user model.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public User() { }

        /// <summary>
        /// Create a new instance of the user model.
        /// </summary>
        /// <param name="dto"></param>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public User(CreateUserDTO dto)
        {
            Email = dto.Email;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            UserName = dto.Email;
            Age = dto.Age.IsNullOrEmpty() ? 0 : int.Parse(dto.Age);
            Role = dto.Role;
            Year = dto.Year;
            Major = dto.Major;
            Bio = dto.Bio;
        }
    }
}
