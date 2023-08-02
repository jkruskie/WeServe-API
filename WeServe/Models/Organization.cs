namespace WeServe.Models
{
    /// <summary>
    /// The organization model for the application.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public class Organization : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ProfilePicture { get; set; } = "https://placehold.co/320x320";
        public string? Banner { get; set; } = "https://placehold.co/640x320";
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public bool IsApproved { get; set; } = false;
        public ICollection<User>? Users { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
