using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels.PawPrintModels
{
    public class AdoptionStatus : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
