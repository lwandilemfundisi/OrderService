using Microservice.Framework.Common;
using Microservice.Framework.Domain.Rules.Notifications;
using Microservice.Framework.Domain.Rules.RuleValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Domain.Extensions
{
    public static class IValidatorExtensions
    {
        public static Task<Notification> Validate(
            this IValidator validator, 
            object instance, 
            object context,
            CancellationToken cancellationToken)
        {
            return validator.Validate(
                instance,
                context,
                SystemCulture.Default(),
                typeof(IValidatorExtensions).Assembly,
                cancellationToken
                );
        }
    }
}
