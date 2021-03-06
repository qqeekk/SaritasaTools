﻿// Copyright (c) 2015-2017, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Saritasa.Tools.Messages.Abstractions
{
    /// <summary>
    /// Message pipeline. The base abstract pipeline interface.
    /// </summary>
    public interface IMessagePipeline
    {
        /// <summary>
        /// Available message types the pipeline is able to process.
        /// </summary>
        byte[] MessageTypes { get; }

        /// <summary>
        /// Middlewares to process messages.
        /// </summary>
        IMessagePipelineMiddleware[] Middlewares { get; set; }

        /// <summary>
        /// Process prepared message context thru all middlewares.
        /// </summary>
        /// <param name="messageContext">Message context.</param>
        void Invoke(IMessageContext messageContext);

        /// <summary>
        /// Process prepared message context thru all middlewares. Middlewares should support
        /// <see cref="IAsyncMessagePipelineMiddleware" /> interface. Otherwise they will be called
        /// in sync mode.
        /// </summary>
        /// <param name="messageContext">Message context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>The task specifies current async operation.</returns>
        Task InvokeAsync(IMessageContext messageContext,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
