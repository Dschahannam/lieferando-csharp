using Lieferando.Interfaces;
using Lieferando.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferando.Managers
{
    public sealed class TakeawayRequestManager
    {
        public TakeawayRequestManager(IServiceProvider serviceProvider)
        {
            foreach (var requestObject in serviceProvider.GetServices<TakeawayRequest>())
                Requests[requestObject.GetType()] = requestObject;
        }

        private readonly Dictionary<Type, object> Requests = new Dictionary<Type, object>();

        public T Get<T>() where T : TakeawayRequest
        {
            if (!Requests.TryGetValue(typeof(T), out var component)) return null;
            return component as T;
        }
    }
}
