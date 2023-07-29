using Microsoft.AspNetCore.Identity;

namespace WeServe.Models
{
    /// <summary>
    /// The user model for the application.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// The user's first name.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string? FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string? LastName { get; set; }

        /// <summary>
        /// The user's age.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public int Age { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public enum Role { Student, Moderator, Admin }

        /// <summary>
        /// The user's year in school.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string? Year { get; set; } = "Freshman";

        /// <summary>
        /// The user's major.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string? Major { get; set; } = "Undeclared";

        /// <summary>
        /// The user's bio.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string? Bio { get; set; } = "This user has not set a bio yet.";

        /// <summary>
        /// The user's profile picture.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public string? ProfilePicture { get; set; } = "https://placehold.co/320x320";

        /// <summary>
        /// The user's ban status.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public Boolean IsBanned { get; set; } = false;

        /// <summary>
        /// The user's delete status.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public Boolean IsDeleted { get; set; } = false;

        /// <summary>
        /// The user's creation date.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// The user's last update date.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// The user's deletion date.
        /// </summary>
        /// <author>Justin Kruskie</author>
        /// <date>07/28/2023</date>
        public DateTime? DeletedAt { get; set; }
    }
}
