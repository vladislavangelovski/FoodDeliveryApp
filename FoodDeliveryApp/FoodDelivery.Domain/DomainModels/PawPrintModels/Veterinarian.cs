using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class Veterinarian : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ClinicName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
