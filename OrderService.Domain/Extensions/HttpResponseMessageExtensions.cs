using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static Task<TResult> As<TResult>(this HttpResponseMessage httpResponseMessage)
        {
            Invariant.IsNotNull(httpResponseMessage, () => $"{typeof(HttpResponseMessage).PrettyPrint()} is null");
            return httpResponseMessage.Content.ReadAsAsync<TResult>();
        }
    }
}
