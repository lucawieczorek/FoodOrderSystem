﻿using FoodOrderSystem.Domain.Model.Cuisine;
using FoodOrderSystem.Domain.Model.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrderSystem.Domain.Commands.RemoveCuisine
{
    public class RemoveCuisineCommandHandler : ICommandHandler<RemoveCuisineCommand>
    {
        private readonly ICuisineRepository cuisineRepository;

        public RemoveCuisineCommandHandler(ICuisineRepository cuisineRepository)
        {
            this.cuisineRepository = cuisineRepository;
        }

        public async Task<CommandResult> HandleAsync(RemoveCuisineCommand command, User currentUser, CancellationToken cancellationToken = default)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (currentUser == null)
                return new UnauthorizedCommandResult();

            if (currentUser.Role < Role.SystemAdmin)
                return new ForbiddenCommandResult();

            await cuisineRepository.RemoveAsync(command.CuisineId, cancellationToken);

            return new SuccessCommandResult();
        }
    }
}
