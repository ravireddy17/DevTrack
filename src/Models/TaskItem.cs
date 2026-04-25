using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, In Progress, Completed

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public string? AssignedTo { get; set; }
    }
}
