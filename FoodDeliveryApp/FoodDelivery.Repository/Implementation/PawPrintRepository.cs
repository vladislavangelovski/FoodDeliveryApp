using FoodDelivery.Domain.DomainModels;
using FoodDelivery.Domain.DomainModels.PawPrintModels;
using FoodDelivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Repository.Implementation
{
    public class PawPrintRepository : IPawPrintRepository
    {
        private readonly PawPrintDbcontext context;
        private DbSet<Pet> entities;

        public PawPrintRepository(PawPrintDbcontext context)
        {
            this.context = context;
            entities = context.Set<Pet>();
        }

        public List<Pet> GetAllPets()
        {
            return context.Pets
            .Include(p => p.Type)
            .Include(p => p.Gender)
            .Include(p => p.Size)
            .Include(p => p.AdoptionStatus)
            .Include(p => p.HealthStatus)
            .ToList();
        }
    }
}
