using System.ComponentModel.DataAnnotations;

namespace WeServe.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public Boolean IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
