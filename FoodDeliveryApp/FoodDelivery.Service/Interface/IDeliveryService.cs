using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Interface
{
    public interface IDeliveryService
    {
        DeliveryOrder AddFoodItemToDelivery(string customerId, AddToDeliveryDTO model);
        AddToDeliveryDTO GetFoodItemInfo(Guid Id);
        DeliveryDTO GetDeliveryDetails(string customerId);
        Boolean DeleteFromDelivery(string customerId, Guid? Id);
        Boolean OrderFoodItems(string customerId);
    }
}
