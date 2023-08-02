namespace WeServe.Models
{
    /// <summary>
    /// An event that an organization is hosting.
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; } = "This event has no details.";
        public string? Details { get; set; } = "This event has no details.";
        public string? Location { get; set; } = "This event has no location.";
        public string? Image { get; set; } = "https://placehold.co/320x320";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
    }
}
