﻿using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.App.Models
{
    public class ChangeRestaurantContactDetailsModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string Imprint { get; set; }
        [Required]
        public string OrderEmailAddress { get; set; }
    }
}
