using FoodDelivery.Domain.DomainModels.PawPrintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Interface
{
    public interface IPawPrintService
    {
        public List<Pet> GetAllPets();
    }
}
