using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class VetSpecialization : BaseEntity
    {
        [Required]
        public Guid VetId { get; set; }
        [Required]
        public string Specialization { get; set; }

        [ForeignKey("VetId")]
        public Veterinarian Veterinarian { get; set; }
    }
}
