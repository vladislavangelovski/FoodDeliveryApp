using FoodDelivery.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Repository.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(string Id);
        void Insert(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
    }
}
