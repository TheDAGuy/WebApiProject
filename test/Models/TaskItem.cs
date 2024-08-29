using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Keep It Shorter than 500 chars")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = true;
    }
}
