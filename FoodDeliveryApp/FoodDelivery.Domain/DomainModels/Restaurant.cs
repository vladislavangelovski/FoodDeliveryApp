﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain.DomainModels
{
    public class Restaurant : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Rating { get; set; }

        public virtual ICollection<FoodItem>? FoodItems { get; set; } = new List<FoodItem>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    }
}
