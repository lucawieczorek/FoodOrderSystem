﻿using FoodOrderSystem.Domain.Model.DishCategory;
using FoodOrderSystem.Domain.Model.Restaurant;
using System.Collections.Generic;

namespace FoodOrderSystem.Domain.Model.Dish
{
    public class Dish
    {
        public Dish(DishId dishId, RestaurantId restaurantId, DishCategoryId categoryId, string name, string description, string productInfo, IList<DishVariant> variants)
        {
            DishId = dishId;
            RestaurantId = restaurantId;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            ProductInfo = productInfo;
            Variants = variants;
        }

        public DishId DishId { get; }
        public RestaurantId RestaurantId { get; }
        public DishCategoryId CategoryId { get; }
        public string Name { get; }
        public string Description { get; }
        public string ProductInfo { get; }
        public IList<DishVariant> Variants { get; }
    }
}
