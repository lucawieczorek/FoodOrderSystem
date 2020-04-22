﻿using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.App.Models
{
    public class AddPaymentMethodModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
