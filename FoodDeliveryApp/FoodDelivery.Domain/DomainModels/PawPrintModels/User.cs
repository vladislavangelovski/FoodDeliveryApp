using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        [Column("LastAnme")] // Matches schema typo
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool HasChildren { get; set; } = false;
        public bool HasOtherPets { get; set; } = false;
        public string HomeType { get; set; }
        public UserRole UserRole { get; set; } = UserRole.CONSUMER;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
