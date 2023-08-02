using System.ComponentModel.DataAnnotations;

namespace WeServe.Models
{
    /// <summary>
    /// Token
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>07/28/2023</date>
    public record Token
    {
        [Key]
        public Guid Id { get; init; }
        public int UserId { get; init; }
    }
}
