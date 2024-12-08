using FoodDeliveryAdminApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryAdminApp.Models.Identity;

public class Customer : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DeliveryOrder? DeliveryOrder { get; set; }
    public ICollection<FoodItem>? MyFoodItems { get; set; }
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
