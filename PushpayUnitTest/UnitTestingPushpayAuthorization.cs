using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CmsWeb.Areas.Setup.Controllers;
using CmsWeb.Common;
using CmsData.Interfaces;
using CmsWeb.Pushpay.Entities;
using UtilityExtensions.Interfaces;
using CmsData;
using System.Threading.Tasks;


//using PushpayUnitTest.TestUtilities;

namespace PushpayUnitTest
{
    [TestClass]
    public class UnitTestingPushpayAuthorization
    {
        private PushpayController _controller;
        private Mock<IConfigurationManager> _configurationManager;
        private Mock<IDbUtilManager> _dbUtilManager;
        private Mock<IUtilManager> _Util;

        public UnitTestingPushpayAuthorization()
        {
            _Util = new Mock<IUtilManager>();
            _Util.Setup(_ => _.Host).Returns("bellevue");

            _dbUtilManager = new Mock<IDbUtilManager>();

            _dbUtilManager.Setup(_ => _.Create(_Util.Object.Host)).Returns(new DbUtilObj().Create(_Util.Object.Host));

            _configurationManager = new Mock<IConfigurationManager>();
            _configurationManager.Setup(_ => _.Current).Returns(new Configuration());            
            _configurationManager.Setup(_ => _.OAuth2AuthorizeEndpoint).Returns("https://auth.pushpay.com/pushpay-sandbox/oauth/authorize");
            _configurationManager.Setup(_ => _.OAuth2TokenEndpoint).Returns("https://auth.pushpay.com/pushpay-sandbox/oauth/token");
            _configurationManager.Setup(_ => _.PushpayAPIBaseUrl).Returns("https://sandbox-api.pushpay.io/v1/");
            _configurationManager.Setup(_ => _.PushpayClientID).Returns("pursuant-touchpoint-dev");
            _configurationManager.Setup(_ => _.PushpayClientSecret).Returns("bDWH1CrVl11nORXKHXWoVIeIuY2NRmYhY0d6anjp1E");
            _configurationManager.Setup(_ => _.PushpayScope).Returns("list_my_merchants merchant:manage_community_members merchant:manage_webhooks merchant:view_community_members merchant:view_payments merchant:view_recurring_payments read");
            _configurationManager.Setup(_ => _.TouchpointAuthServer).Returns("https://123ec8c6.ngrok.io/pushpay/complete");

            _controller = new PushpayController(_configurationManager.Object, _dbUtilManager.Object, _Util.Object);
        }

        [TestMethod]
        public void Index_returns_proper_URL()
        {
            var urlExpected = "https://auth.pushpay.com/pushpay-sandbox/oauth/authorize?client_id=pursuant-touchpoint-dev&response_type=code&redirect_uri=https://123ec8c6.ngrok.io/pushpay/complete&scope=list_my_merchants merchant:manage_community_members merchant:manage_webhooks merchant:view_community_members merchant:view_payments merchant:view_recurring_payments read&state=bellevue";
            var result = (RedirectResult)_controller.Index();
            Assert.IsNotNull(result);
            Assert.AreEqual(urlExpected, result.Url);
        }

        [TestMethod]
        public void Complete_returns_proper_url()
        {
#if DEBUG
            var urlExpected = "http://localhost:44301/Pushpay/Save?_at=&_rt=";
#else
            var urlExpected = "https://bellevue.tpsdb.com/Pushpay/Save?_at=&_rt=";
#endif

            var code = "bb4d9a4f648244d4b0b9daeffc4f9296";
            var state = _Util.Object.Host;
            var result = _controller.Complete(code, state) as Task<ActionResult>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Result);
            Assert.AreEqual(urlExpected, ((RedirectResult)result.Result).Url);
        }

        [TestMethod]
        public void GetAuthorizationToken()
        {
            var code = "bb4d9a4f648244d4b0b9daeffc4f9296";
            var result = _controller.AuthorizationCodeCallback(code) as Task<AccessToken>;
            Assert.IsNotNull(result.Result.access_token);
        }
    }
}
