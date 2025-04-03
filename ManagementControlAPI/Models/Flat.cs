using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManagementControlAPI.Models;

namespace ManagementControlAPI.Models
{
    public class Flat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public required User Owner { get; set; }

        public List<User> Users { get; set; } = new();
        [Required]
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}