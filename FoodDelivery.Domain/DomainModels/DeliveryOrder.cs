using FoodDelivery.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class DeliveryOrder : BaseEntity
    {
        public string? OwnerId { get; set; }
        public Customer? Owner { get; set; }
        public virtual ICollection<FoodItemInDelivery>? FoodItemInDeliveries { get; set; }

    }
}
