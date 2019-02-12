// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

#if !NETFX_CORE && !PORTABLE
#endif

namespace Configit.SignalR.Client.Http
{
#if !NETFX_CORE && !PORTABLE && !__ANDROID__ && !IOS
    public class DefaultHttpHandler : WebRequestHandler
#else
    public class DefaultHttpHandler : HttpClientHandler
#endif
    {
        private readonly IConnection _connection;

        public DefaultHttpHandler(IConnection connection)
        {
            if (connection != null)
            {
                _connection = connection;
            }
            else
            {
                throw new ArgumentNullException("connection");
            }

            Credentials = _connection.Credentials;
#if PORTABLE
            if (this.SupportsPreAuthenticate())
            {
                PreAuthenticate = true;
            }
#elif NET45
            PreAuthenticate = true;
#endif

            if (_connection.CookieContainer != null)
            {
                CookieContainer = _connection.CookieContainer;
            }

#if !PORTABLE
            if (_connection.Proxy != null)
            {
                Proxy = _connection.Proxy;
            }
#endif

#if (NET4 || NET45)
            foreach (X509Certificate cert in _connection.Certificates)
            {
                ClientCertificates.Add(cert);
            }
#endif
        }
    }
}
