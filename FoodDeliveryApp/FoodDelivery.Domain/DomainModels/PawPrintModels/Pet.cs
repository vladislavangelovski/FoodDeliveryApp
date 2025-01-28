using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class Pet : BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public string Breed { get; set; }
        [Required]
        public string AvatarImg { get; set; }
        public List<string> ImageShowcase { get; set; } = new List<string>();
        public int AgeYears { get; set; }

        [Required]
        public Guid TypeId { get; set; }
        [Required]
        public Guid GenderId { get; set; }
        [Required]
        public Guid SizeId { get; set; }
        [Required]
        public Guid AdoptionStatusId { get; set; }
        [Required]
        public Guid HealthStatusId { get; set; }

        public bool GoodWithChildren { get; set; } = false;
        public bool GoodWithDogs { get; set; } = false;
        public bool GoodWithCats { get; set; } = false;
        public int EnergyLevel { get; set; }
        public string? Description { get; set; }
        public string? SpecialRequirements { get; set; }
        public string? BehavioralNotes { get; set; }

        // Navigation properties
        [ForeignKey("TypeId")]
        public PetType? Type { get; set; }
        [ForeignKey("GenderId")]
        public PetGender? Gender { get; set; }
        [ForeignKey("SizeId")]
        public PetSize? Size { get; set; }
        [ForeignKey("AdoptionStatusId")]
        public AdoptionStatus? AdoptionStatus { get; set; }
        [ForeignKey("HealthStatusId")]
        public HealthStatus? HealthStatus { get; set; }
    }
}
