using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAdminApp.Models
{
    public class FoodItemInDelivery : BaseEntity
    {
        public Guid FoodItemId{ get; set; }
        public FoodItem? FoodItem{ get; set; }
        public Guid DeliveryOrderId { get; set; }
        public DeliveryOrder? DeliveryOrder { get; set; }
        public int Quantity { get; set; }
        public Guid? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
