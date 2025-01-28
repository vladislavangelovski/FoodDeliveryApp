using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class ShelterPetListing : BaseEntity
    {
        [Required]
        public Guid ShelterId { get; set; }
        [Required]
        public Guid PetId { get; set; }
        public Guid? MedicalRecordId { get; set; }
        public ApprovalStatus Approved { get; set; } = ApprovalStatus.PENDING;
        public DateTime IntakeDate { get; set; }

        [ForeignKey("ShelterId")]
        public Shelter Shelter { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; }
    }
}
