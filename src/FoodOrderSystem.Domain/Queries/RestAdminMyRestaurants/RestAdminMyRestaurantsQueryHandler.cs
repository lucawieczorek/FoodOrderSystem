﻿using FoodOrderSystem.Domain.Model;
using FoodOrderSystem.Domain.Model.PaymentMethod;
using FoodOrderSystem.Domain.Model.Restaurant;
using FoodOrderSystem.Domain.Model.User;
using FoodOrderSystem.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrderSystem.Domain.Queries.RestAdminMyRestaurants
{
    public class RestAdminMyRestaurantsQueryHandler : IQueryHandler<RestAdminMyRestaurantsQuery, ICollection<RestaurantViewModel>>
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IPaymentMethodRepository paymentMethodRepository;
        private readonly IUserRepository userRepository;

        public RestAdminMyRestaurantsQueryHandler(IRestaurantRepository restaurantRepository, IPaymentMethodRepository paymentMethodRepository, IUserRepository userRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.paymentMethodRepository = paymentMethodRepository;
            this.userRepository = userRepository;
        }

        public async Task<Result<ICollection<RestaurantViewModel>>> HandleAsync(RestAdminMyRestaurantsQuery query, User currentUser, CancellationToken cancellationToken = default)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (currentUser == null)
                return FailureResult<ICollection<RestaurantViewModel>>.Unauthorized();

            if (currentUser.Role < Role.RestaurantAdmin)
                return FailureResult<ICollection<RestaurantViewModel>>.Forbidden();

            var paymentMethods = (await paymentMethodRepository.FindAllAsync(cancellationToken))
                .ToDictionary(en => en.Id.Value, PaymentMethodViewModel.FromPaymentMethod);

            var restaurants = await restaurantRepository.FindByUserIdAsync(currentUser.Id, cancellationToken);

            return SuccessResult<ICollection<RestaurantViewModel>>.Create(restaurants
                .Select(en => RestaurantViewModel.FromRestaurant(en, paymentMethods, userRepository)).ToList());
        }
    }
}
