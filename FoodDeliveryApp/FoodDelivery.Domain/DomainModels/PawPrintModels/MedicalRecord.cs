using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class MedicalRecord : BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid VetId { get; set; }
        public bool SpayNeuterStatus { get; set; } = false;
        public DateTime? LastMedicalCheckup { get; set; }
        public string MicrochipNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("VetId")]
        public Veterinarian Veterinarian { get; set; }
    }
}
