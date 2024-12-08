using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAdminApp.Models
{
    public class FoodItemInOrder : BaseEntity
    {
        public Guid FoodItemId { get; set; }
        public FoodItem? OrderedFoodItem { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
    }
}
