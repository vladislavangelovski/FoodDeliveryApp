using FoodDelivery.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DTO
{
    public class DeliveryDTO
    {
        public List<FoodItemInDelivery>? AllFoodItems {  get; set; }
        public double TotalPrice { get; set; }
    }
}
