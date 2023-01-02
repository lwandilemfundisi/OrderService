using AutoMapper;
using Microservice.Framework.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Models;
using OrderService.Domain.DomainModel.OrderDomainModel.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQueryProcessor _queryProcessor;

        public OrderController(
            IQueryProcessor queryProcessor,
            IMapper mapper)
        {
            _mapper = mapper;
            _queryProcessor = queryProcessor;
        }

        [HttpGet("getOrders/{userId}")]
        public async Task<IActionResult> List(string userId)
        {
            var orders = await _queryProcessor
                .ProcessAsync(new GetOrdersQuery(null, userId), CancellationToken.None);
            var debug = orders.Select(o => _mapper.Map<OrderDtoModel>(o));
            return Ok(debug);
        }
    }
}
