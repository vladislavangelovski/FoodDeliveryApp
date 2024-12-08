
using FoodDeliveryAdminApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAdminApp.Models
{
    public class DeliveryOrder : BaseEntity
    {
        public string? OwnerId { get; set; }
        public Customer? Owner { get; set; }
        public ICollection<FoodItemInDelivery>? FoodItemInDeliveries { get; set; }

    }
}
