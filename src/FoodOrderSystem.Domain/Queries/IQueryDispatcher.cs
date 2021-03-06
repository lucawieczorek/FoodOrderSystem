﻿using FoodOrderSystem.Domain.Model;
using FoodOrderSystem.Domain.Model.User;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrderSystem.Domain.Queries
{
    public interface IQueryDispatcher
    {
        Task<Result<TResult>> PostAsync<TQuery, TResult>(TQuery query, User currentUser, CancellationToken cancellationToken = default) where TQuery : IQuery<TResult>;
    }
}
