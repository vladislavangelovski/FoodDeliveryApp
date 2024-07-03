using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class RestaurantFoodItem : BaseEntity
    {
        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public Guid RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

    }
}
