﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ESpace
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for WebHook.
    /// </summary>
    public static partial class WebHookExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static object List(this IWebHook operations, string apiKey, long id, string version)
            {
                return Task.Factory.StartNew(s => ((IWebHook)s).ListAsync(apiKey, id, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ListAsync(this IWebHook operations, string apiKey, long id, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(apiKey, id, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static object Create(this IWebHook operations, string apiKey, WebHookCreateApiModel model, string version)
            {
                return Task.Factory.StartNew(s => ((IWebHook)s).CreateAsync(apiKey, model, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> CreateAsync(this IWebHook operations, string apiKey, WebHookCreateApiModel model, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(apiKey, model, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static object Edit(this IWebHook operations, string apiKey, WebHookCreateApiModel model, string version)
            {
                return Task.Factory.StartNew(s => ((IWebHook)s).EditAsync(apiKey, model, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> EditAsync(this IWebHook operations, string apiKey, WebHookCreateApiModel model, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.EditWithHttpMessagesAsync(apiKey, model, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static object Delete(this IWebHook operations, string apiKey, long id, string version)
            {
                return Task.Factory.StartNew(s => ((IWebHook)s).DeleteAsync(apiKey, id, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DeleteAsync(this IWebHook operations, string apiKey, long id, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(apiKey, id, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static object WebhookEvents(this IWebHook operations, string apiKey, string version)
            {
                return Task.Factory.StartNew(s => ((IWebHook)s).WebhookEventsAsync(apiKey, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiKey'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> WebhookEventsAsync(this IWebHook operations, string apiKey, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.WebhookEventsWithHttpMessagesAsync(apiKey, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
