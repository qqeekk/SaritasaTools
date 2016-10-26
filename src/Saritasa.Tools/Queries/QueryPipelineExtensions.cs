﻿// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Saritasa.Tools.Queries
{
    /// <summary>
    /// Query pipeline extensions.
    /// </summary>
    public static class QueryPipelineExtensions
    {
        /// <summary>
        /// Use internal IoC container.
        /// </summary>
        /// <param name="queryPipeline">Query pipeline.</param>
        /// <param name="resolveMethodParameters">Resolve method parameters.</param>
        /// <returns>Query pipeline.</returns>
        public static IQueryPipeline UseInternalResolver(this IQueryPipeline queryPipeline,
            bool resolveMethodParameters = false)
        {
            var middleware = (QueryPipelineMiddlewares.QueryObjectResolverMiddleware)queryPipeline.GetMiddlewareById("QueryResolver");
            middleware.UseInternalObjectResolver = true;
            middleware.UseParametersResolve = resolveMethodParameters;
            return queryPipeline;
        }
    }
}