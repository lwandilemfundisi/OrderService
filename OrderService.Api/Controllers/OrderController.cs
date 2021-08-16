using Microservice.Framework.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderService.Domain.DomainModel.OrderDomainModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        public OrderController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("getOrders/{userId?}")]
        public async Task<IActionResult> List([FromQuery]string userId)
        {
            var orders = await _queryProcessor
                .ProcessAsync(new GetOrdersQuery(null, userId), CancellationToken.None);

            return Ok(orders);
        }
    }
}
