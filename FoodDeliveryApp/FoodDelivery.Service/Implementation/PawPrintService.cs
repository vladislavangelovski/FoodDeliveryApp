using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DomainModels.PawPrintModels;
using FoodDelivery.Repository.Implementation;
using FoodDelivery.Repository.Interface;
using FoodDelivery.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Service.Implementation
{
    public class PawPrintService : IPawPrintService
    {
        private readonly IPawPrintRepository _pawPrintRepository;

        public PawPrintService(IPawPrintRepository pawPrintRepository)
        {
            _pawPrintRepository = pawPrintRepository;
        }
        public List<Pet> GetAllPets()
        {
            return _pawPrintRepository.GetAllPets().ToList();
        }
    }
}
