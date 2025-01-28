using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class Vaccination : BaseEntity
    {
        [Required]
        public Guid MedicalRecordId { get; set; }
        [Required]
        public string VaccineName { get; set; }
        [Required]
        public DateTime VaccinationDate { get; set; }

        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; }
    }
}
