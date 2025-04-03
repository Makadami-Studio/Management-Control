using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManagementControlAPI.Models;

namespace ManagementControlAPI.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsCompleted { get; set; } = false;
        [Required]
        public User AssignedTo { get; set; } = new User();
        public int AssignedFlatId { get; set; }
        [ForeignKey("AssignedFlatId")]
        public required Flat AssignedFlat { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public User CreatedBy { get; set; } = new User();
        public User UpdatedBy { get; set; } = new User();
        public bool IsDeleted { get; set; } = false;
    }
}