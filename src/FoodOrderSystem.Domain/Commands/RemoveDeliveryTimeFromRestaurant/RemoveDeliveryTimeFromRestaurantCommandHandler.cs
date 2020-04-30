﻿using FoodOrderSystem.Domain.Model.Restaurant;
using FoodOrderSystem.Domain.Model.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrderSystem.Domain.Commands.RemoveDeliveryTimeFromRestaurant
{
    public class RemoveDeliveryTimeFromRestaurantCommandHandler : ICommandHandler<RemoveDeliveryTimeFromRestaurantCommand>
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RemoveDeliveryTimeFromRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<CommandResult> HandleAsync(RemoveDeliveryTimeFromRestaurantCommand command, User currentUser, CancellationToken cancellationToken = default)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (currentUser == null)
                return new UnauthorizedCommandResult();

            if (currentUser.Role < Role.RestaurantAdmin)
                return new ForbiddenCommandResult();

            var restaurant = await restaurantRepository.FindByRestaurantIdAsync(command.RestaurantId, cancellationToken);
            if (restaurant == null)
                return new FailureCommandResult<string>("restaurant does not exist");

            restaurant.RemoveDeliveryTime(command.DayOfWeek, command.Start);

            await restaurantRepository.StoreAsync(restaurant, cancellationToken);

            return new SuccessCommandResult<Restaurant>(restaurant);
        }
    }
}
