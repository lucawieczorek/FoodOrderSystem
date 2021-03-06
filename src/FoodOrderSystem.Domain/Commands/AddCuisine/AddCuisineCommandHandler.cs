﻿using FoodOrderSystem.Domain.Model;
using FoodOrderSystem.Domain.Model.Cuisine;
using FoodOrderSystem.Domain.Model.User;
using FoodOrderSystem.Domain.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrderSystem.Domain.Commands.AddCuisine
{
    public class AddCuisineCommandHandler : ICommandHandler<AddCuisineCommand, CuisineViewModel>
    {
        private readonly ICuisineFactory cuisineFactory;
        private readonly ICuisineRepository cuisineRepository;

        public AddCuisineCommandHandler(ICuisineFactory cuisineFactory, ICuisineRepository cuisineRepository)
        {
            this.cuisineFactory = cuisineFactory;
            this.cuisineRepository = cuisineRepository;
        }

        public async Task<Result<CuisineViewModel>> HandleAsync(AddCuisineCommand command, User currentUser, CancellationToken cancellationToken = default)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (currentUser == null)
                return FailureResult<CuisineViewModel>.Unauthorized();

            if (currentUser.Role < Role.SystemAdmin)
                return FailureResult<CuisineViewModel>.Forbidden();

            var cuisine = await cuisineRepository.FindByNameAsync(command.Name, cancellationToken);
            if (cuisine != null)
                return FailureResult<CuisineViewModel>.Create(FailureResultCode.CuisineAlreadyExists);

            cuisine = cuisineFactory.Create(command.Name);
            await cuisineRepository.StoreAsync(cuisine, cancellationToken);

            return SuccessResult<CuisineViewModel>.Create(CuisineViewModel.FromCuisine(cuisine));
        }
    }
}
