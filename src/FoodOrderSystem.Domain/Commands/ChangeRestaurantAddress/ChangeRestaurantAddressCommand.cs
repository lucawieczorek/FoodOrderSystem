﻿using FoodOrderSystem.Domain.Model.Restaurant;

namespace FoodOrderSystem.Domain.Commands.ChangeRestaurantAddress
{
    public class ChangeRestaurantAddressCommand : ICommand
    {
        public ChangeRestaurantAddressCommand(RestaurantId restaurantId, Address address)
        {
            RestaurantId = restaurantId;
            Address = address;
        }

        public RestaurantId RestaurantId { get; }
        public Address Address { get; }
    }
}
