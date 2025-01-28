using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class Adoption : BaseEntity
    {
        [Required]
        public Guid PetId { get; set; }
        [Required]
        public Guid AdopterId { get; set; }
        [Required]
        public DateTime AdoptionDate { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "decimal(18,2)")]
        public decimal AdoptionFee { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string CounselorNotes { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        [ForeignKey("AdopterId")]
        public User User { get; set; }
    }
}
