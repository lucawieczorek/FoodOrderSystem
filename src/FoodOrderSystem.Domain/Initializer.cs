﻿using FoodOrderSystem.Domain.Commands;
using FoodOrderSystem.Domain.Model;
using FoodOrderSystem.Domain.Model.Cuisine;
using FoodOrderSystem.Domain.Model.PaymentMethod;
using FoodOrderSystem.Domain.Model.Restaurant;
using FoodOrderSystem.Domain.Model.User;
using FoodOrderSystem.Domain.Queries;
using FoodOrderSystem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;

namespace FoodOrderSystem.Domain
{
    public static class Initializer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Register model classes
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<ICuisineFactory, CuisineFactory>();
            services.AddTransient<IPaymentMethodFactory, PaymentMethodFactory>();
            services.AddTransient<IRestaurantFactory, RestaurantFactory>();

            // Register command classes
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            CommandDispatcher.Initialize(services);

            // Register query classes
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            QueryDispatcher.Initialize(services);

            // Initialize failure messages
            var failureMessageService = new FailureMessageService();
            services.AddSingleton<IFailureMessageService>(failureMessageService);

            var deDeCultureInfo = new CultureInfo("de-DE");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.Unauthorized, "Sie sind nicht angemeldet");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.Forbidden, "Sie sind nicht berechtigt, diese Aktion auszuführen");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.UserDoesNotExist, "Benutzer existiert nicht");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.UserAlreadyExists, "Benutzer existiert bereits");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.CannotRemoveCurrentUser, "Sie können nicht den gerade angemeldeten Benutzer löschen");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.CuisineDoesNotExist, "Cuisine existiert nicht");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.CuisineAlreadyExists, "Cuisine existiert bereits");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.PaymentMethodDoesNotExist, "Zahlungsmethode existiert nicht");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.PaymentMethodAlreadyExists, "Zahlungsmethode existiert bereits");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.RestaurantDoesNotExist, "Restaurant existiert nicht");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.RestaurantContainsDishCategories, "Restaurant enthält noch Gerichtkategorien");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.RestaurantContainsDishes, "Restaurant enthält noch Gerichte");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.DishCategoryDoesNotBelongToRestaurant, "Gerichtkategorie gehört nicht zum Restaurant");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.DishCategoryContainsDishes, "Gerichtkategorie enthält noch Gerichte");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.DishDoesNotBelongToDishCategory, "Gericht gehört nicht zur Gerichtkategorie");
            failureMessageService.RegisterMessage(deDeCultureInfo, FailureResultCode.CannotRemoveCurrentUserFromRestaurantAdmins, "Sie können nicht den gerade angemeldeten Benutzer aus den Administratoren des Restaurants löschen");

            if (!failureMessageService.AreAllCodesRegisteredForCulture(deDeCultureInfo))
                throw new InvalidOperationException($"Not all messages for culture {deDeCultureInfo} are registered");
        }
    }
}
