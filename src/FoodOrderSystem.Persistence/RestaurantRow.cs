﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderSystem.Persistence
{
    [Table("Restaurant")]
    public class RestaurantRow
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string AddressLine1 { get; set; }
        
        public string AddressLine2 { get; set; }
        
        public string AddressZipCode { get; set; }
        
        public string AddressCity { get; set; }
        
        public virtual ICollection<DeliveryTimeRow> DeliveryTimes { get; set; } = new List<DeliveryTimeRow>();

        [Column(TypeName = "decimal(5, 2)")]
        public decimal MinimumOrderValue { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal DeliveryCosts { get; set; }
        
        public string WebSite { get; set; }
        
        public string Imprint { get; set; }

        public virtual ICollection<RestaurantCuisineRow> RestaurantCuisines { get; set; } = new List<RestaurantCuisineRow>();

        public virtual ICollection<RestaurantPaymentMethodRow> RestaurantPaymentMethods { get; set; } = new List<RestaurantPaymentMethodRow>();
        
        public virtual ICollection<DishCategoryRow> Categories { get; set; } = new List<DishCategoryRow>();
        
        public virtual ICollection<DishRow> Dishes { get; set; } = new List<DishRow>();
    }
}
