using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class AdopterPetSizePreference : BaseEntity
    {
        [Required]
        public Guid AdopterId { get; set; }
        [Required]
        public Guid SizeId { get; set; }

        [ForeignKey("AdopterId")]
        public User User { get; set; }
        [ForeignKey("SizeId")]
        public PetSize PetSize { get; set; }
    }
}
