using FoodDelivery.Domain.DomainModels.PawPrintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Repository.Interface
{
    public interface IPawPrintRepository
    {
        List<Pet> GetAllPets();
    }
}
