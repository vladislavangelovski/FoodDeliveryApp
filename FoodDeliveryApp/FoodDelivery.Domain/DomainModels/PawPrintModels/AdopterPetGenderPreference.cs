using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class AdopterPetGenderPreference : BaseEntity
    {
        [Required]
        public Guid AdopterId { get; set; }
        [Required]
        public Guid GenderId { get; set; }

        [ForeignKey("AdopterId")]
        public User User { get; set; }
        [ForeignKey("GenderId")]
        public PetGender PetGender { get; set; }
    }
}
