﻿using System.Collections.Generic;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.HeaderParameter.Extension.Extensions
{
    internal static class OperationFilterContextExtensions
    {
        public static IEnumerable<T> GetControllerAndActionAttributes<T>(this OperationFilterContext context) where T : System.Attribute
        {
            var controllerAttributes = context.MethodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes<T>();
            var actionAttributes = context.MethodInfo.GetCustomAttributes<T>();

            var result = new List<T>(controllerAttributes);
            result.AddRange(actionAttributes);

            return result;
        }
    }
}
