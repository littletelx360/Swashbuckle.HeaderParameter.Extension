﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.HeaderParameter.Extension
{
    public static class SwaggerGenOptionsExtensions
    {
        public static SwaggerGenOptions AddHeaderParameters(this SwaggerGenOptions swaggerGenOptions)
        {
            return swaggerGenOptions.AddHeaderParameters(config => { });
        }

        public static SwaggerGenOptions AddHeaderParameters(this SwaggerGenOptions swaggerGenOptions, IEnumerable<IHeaderParameter> headerParameters)
        {
            var config = new ApiConfig { HeaderParameters = headerParameters };

            swaggerGenOptions.OperationFilter<HeaderParameterOperationalFilter>(config);

            return swaggerGenOptions;
        }

        public static SwaggerGenOptions AddHeaderParameters(this SwaggerGenOptions swaggerGenOptions, Action<ApiConfig> setupAction)
        {
            var config = new ApiConfig();

            setupAction.Invoke(config);

            swaggerGenOptions.OperationFilter<HeaderParameterOperationalFilter>(config);

            return swaggerGenOptions;
        }
    }
}
