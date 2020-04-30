﻿using FoodOrderSystem.App.Helper;
using FoodOrderSystem.Domain.Commands;
using FoodOrderSystem.Domain.Queries;
using FoodOrderSystem.Domain.Queries.OrderSearchForRestaurants;
using FoodOrderSystem.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrderSystem.App.Controllers.V1
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public OrderController(ILogger<OrderController> logger, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.logger = logger;
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [Route("restaurants")]
        [HttpGet]
        public async Task<IActionResult> SearchForRestaurantAsync(string search)
        {
            var queryResult = await queryDispatcher.PostAsync<OrderSearchForRestaurantsQuery, ICollection<RestaurantViewModel>>(new OrderSearchForRestaurantsQuery(search), null);
            return ResultHelper.HandleQueryResult(queryResult);
        }
    }
}
