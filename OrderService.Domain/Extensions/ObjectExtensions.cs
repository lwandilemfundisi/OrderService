using Microservice.Framework.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static HttpContent SerializeToJson(this object value)
        {
            if (value.IsNull())
            {
                throw new Exception("Cannot serialize null");
            }

            var json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
