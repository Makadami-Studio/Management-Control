using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementControlAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain letters and numbers.")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
        public bool isInFlat { get; set; } = false;
    }
}