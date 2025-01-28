using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class AdopterPetTypePreference : BaseEntity
    {
        [Required]
        public Guid AdopterId { get; set; }
        [Required]
        public Guid TypeId { get; set; }

        [ForeignKey("AdopterId")]
        public User User { get; set; }
        [ForeignKey("TypeId")]
        public PetType PetType { get; set; }
    }
}
