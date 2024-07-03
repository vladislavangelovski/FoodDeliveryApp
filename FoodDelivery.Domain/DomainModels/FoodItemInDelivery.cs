using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class FoodItemInDelivery : BaseEntity
    {
        public Guid FoodItemInRestaurantId { get; set; }
        public RestaurantFoodItem? FoodItemInRestaurant { get; set; }
        public Guid DeliveryId { get; set; }
        public DeliveryOrder? DeliveryOrder { get; set; }
        public int Quantity { get; set; }
    }
}
