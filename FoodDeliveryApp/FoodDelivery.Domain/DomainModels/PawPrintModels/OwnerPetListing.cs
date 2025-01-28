using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class OwnerPetListing : BaseEntity
    {
        [Required]
        public Guid AdopterId { get; set; }
        [Required]
        public Guid PetId { get; set; }
        public ApprovalStatus Approved { get; set; } = ApprovalStatus.PENDING;
        [Required]
        public Guid SurrenderReasonId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("AdopterId")]
        public User User { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        [ForeignKey("SurrenderReasonId")]
        public SurrenderReason SurrenderReason { get; set; }
    }
}
