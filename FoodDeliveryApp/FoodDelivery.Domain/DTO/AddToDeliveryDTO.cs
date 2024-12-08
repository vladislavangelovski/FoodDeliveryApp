using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DTO
{
    public class AddToDeliveryDTO
    {
        public Guid SelectedFoodItemId { get; set; }
        public string? SelectedFoodItemName { get; set; }
        public int Quantity { get; set; } 
    }
}
