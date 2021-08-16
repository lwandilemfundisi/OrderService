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
    public class GetOrdersQuery
        : EFCoreCriteriaDomainQuery<Order>, IQuery<IEnumerable<Order>>
    {
        #region Constructors

        public GetOrdersQuery(
            OrderId[] ids,
            string userId)
        {
            Ids = ids;
            UserId = userId;
        }

        #endregion

        #region Properties

        public string UserId { get; }

        #endregion
    }

    public class GetOrdersQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Order>, IQueryHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        #region Constructors

        public GetOrdersQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<IEnumerable<Order>> ExecuteQueryAsync(
            GetOrdersQuery query, 
            CancellationToken cancellationToken)
        {
            return FindAll(query);
        }

        #endregion
    }
}
