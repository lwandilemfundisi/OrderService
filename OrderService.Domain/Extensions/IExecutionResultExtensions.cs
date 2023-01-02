using Microservice.Framework.Common;
using Microservice.Framework.Domain.ExecutionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Extensions
{
    public static class IExecutionResultExtensions
    {
        public static TResult As<TResult>(this IExecutionResult executionResult )
        {
            if (executionResult.IsNotNull() 
                && executionResult.IsSuccess 
                && executionResult.GetType().IsGenericType
                && executionResult.GetType().GetGenericTypeDefinition() == typeof(SuccessExecutionResult<>))
            {
                return ((SuccessExecutionResult<TResult>)executionResult).Result;
            }

            if(executionResult.IsNotNull()
                && !executionResult.IsSuccess)
            {
                throw new Exception(((FailedExecutionResult)executionResult).Errors);
            }

            throw new Exception($"As<> method is only for type {typeof(SuccessExecutionResult<>).PrettyPrint()} and must not be null");
        }
    }
}
