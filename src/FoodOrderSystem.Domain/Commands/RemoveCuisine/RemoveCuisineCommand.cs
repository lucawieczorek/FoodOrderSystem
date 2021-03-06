﻿using FoodOrderSystem.Domain.Model.Cuisine;

namespace FoodOrderSystem.Domain.Commands.RemoveCuisine
{
    public class RemoveCuisineCommand : ICommand<bool>
    {
        public RemoveCuisineCommand(CuisineId cuisineId)
        {
            CuisineId = cuisineId;
        }

        public CuisineId CuisineId { get; }
    }
}
