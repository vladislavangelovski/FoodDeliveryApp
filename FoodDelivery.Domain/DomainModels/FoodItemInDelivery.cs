using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class FoodItemInDelivery : BaseEntity
    {
        public Guid FoodItemId{ get; set; }
        public FoodItem? FoodItem{ get; set; }
        public Guid DeliveryId { get; set; }
        public DeliveryOrder? DeliveryOrder { get; set; }
        public int Quantity { get; set; }
    }
}
