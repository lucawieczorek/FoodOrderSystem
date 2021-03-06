﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrderSystem.Domain.Model.PaymentMethod
{
    public interface IPaymentMethodRepository
    {
        Task<ICollection<PaymentMethod>> FindAllAsync(CancellationToken cancellationToken = default);

        Task<PaymentMethod> FindByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<PaymentMethod> FindByPaymentMethodIdAsync(PaymentMethodId paymentMethodId, CancellationToken cancellationToken = default);

        Task StoreAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken = default);

        Task RemoveAsync(PaymentMethodId paymentMethodId, CancellationToken cancellationToken = default);
    }
}
