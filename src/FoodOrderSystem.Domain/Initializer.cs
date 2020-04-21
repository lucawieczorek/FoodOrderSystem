﻿using FoodOrderSystem.Domain.Commands;
using FoodOrderSystem.Domain.Model.User;
using FoodOrderSystem.Domain.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderSystem.Domain
{
    public static class Initializer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Register model classes
            services.AddTransient<IUserFactory, UserFactory>();

            // Register command classes
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            CommandDispatcher.Initialize(services);

            // Register query classes
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            QueryDispatcher.Initialize(services);
        }
    }
}
