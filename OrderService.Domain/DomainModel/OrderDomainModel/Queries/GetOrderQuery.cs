using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.DomainModel.OrderDomainModel.Queries
{
    public class GetOrderQuery
        : EFCoreCriteriaDomainQuery<Order>, IQuery<Order>
    {
        #region Constructors

        public GetOrderQuery(OrderId id)
        {
            Id = id;
        }

        #endregion
    }

    public class GetOrderQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Order>, IQueryHandler<GetOrderQuery, Order>
    {
        #region Constructors

        public GetOrderQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<Order> ExecuteQueryAsync(
            GetOrderQuery query, 
            CancellationToken cancellationToken)
        {
            return Find(query);
        }

        #endregion
    }
}
