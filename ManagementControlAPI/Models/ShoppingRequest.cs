using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementControlAPI.Models
{
    public class ShoppingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string ItemName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsBought { get; set; } = false;
        public int FlatId { get; set; }
    }
}