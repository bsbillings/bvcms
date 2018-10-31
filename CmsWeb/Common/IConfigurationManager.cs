using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CmsWeb.Common
{
    public interface IConfigurationManager
    {
        Configuration Current { get; }
        string PushpayAPIBaseUrl { get; }

        string PushpayClientID { get; }

        string PushpayClientSecret { get; }

        string OAuth2TokenEndpoint { get; }

        string OAuth2AuthorizeEndpoint { get; }

        string TouchpointAuthServer { get; }

        string OrgBaseDomain { get; }

        string TenantHostDev { get; }

        string PushpayScope { get; }
    }
}
