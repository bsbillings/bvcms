using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CmsWeb.Common;
using CmsData;
using System.Net.Http;
using System.Net.Http.Headers;
using CmsWeb.Pushpay.Entities;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using UtilityExtensions;
using UtilityExtensions.Interfaces;
using CmsData.Interfaces;

namespace CmsWeb.Areas.Setup.Controllers
{
    [RouteArea("Setup", AreaPrefix = "Pushpay")]
    public class PushpayController : Controller
    {
        IConfigurationManager _configurationManager;
        IDbUtilManager _dbUtil;
        IUtilManager _Util;
        CMSDataContext _dbContext;
        
        public PushpayController(IConfigurationManager configurationManager, IDbUtilManager dbUtil, IUtilManager Util)
        {
            _configurationManager = configurationManager ?? throw new ArgumentNullException("configurationManager");
            _dbUtil = dbUtil ?? throw new ArgumentNullException("dbUtil");
            _Util = Util ?? throw new ArgumentNullException("Util");
            _dbContext = _dbUtil.Create(_Util.Host);
        }
        /// <summary>
        ///     Opens the developer console in a separate VIEW
        /// </summary>
        /// <returns></returns>
        public ActionResult DeveloperConsole()
        {
            return View();
        }

        /// <summary>
        ///     Entry point / home page into the application
        /// </summary>
        /// <returns></returns>
        [Route("~/Pushpay")]
        public ActionResult Index()
        {            
            string redirectUrl = _configurationManager.OAuth2AuthorizeEndpoint
                + "?client_id=" + _configurationManager.PushpayClientID
                + "&response_type=code"
                + "&redirect_uri=" + _configurationManager.TouchpointAuthServer
                + "&scope=" + _configurationManager.PushpayScope
                + "&state=" + _dbContext.Host; //Get  xsrf_token:tenantID

            return Redirect(redirectUrl);
        }

        [AllowAnonymous, Route("~/Pushpay/Complete")]
        public async Task<ActionResult> Complete(string code, string state)
        {
            string redirectUrl;
            var tenantHost = state;
#if DEBUG
            redirectUrl = "http://" + _configurationManager.Current.TenantHostDev + "/Pushpay/Save";
#else
            redirectUrl = "https://" + tenantHost + "." + _configurationManager.Current.OrgBaseDomain + "/Pushpay/Save";
#endif
            //Received authorization code from authorization server
            var authorizationCode = code;
            if (authorizationCode != null && authorizationCode != "")
            {
                //Get code returned from Pushpay
                var at = await AuthorizationCodeCallback(authorizationCode);
                redirectUrl = redirectUrl + "?_at=" + at.access_token + "&_rt=" + at.refresh_token;
                return Redirect(redirectUrl);
            }
            return Redirect("~/Home/Index");
        }

        [Route("~/Pushpay/Save")]
        public ActionResult Save(string _at, string _rt)
        {
            string idAccessToken = "PushpayAccessToken", idRefreshToken= "PushpayRefreshToken";
            
            var m = _dbContext.Settings.AsQueryable();
            if (!Regex.IsMatch(idAccessToken, @"\A[A-z0-9-]*\z"))
                return View("Invalid characters in setting id");

            if (!_dbContext.Settings.Any(s => s.Id == idAccessToken))
            {
                //Create access token
                var s = new Setting { Id = idAccessToken, SettingX = _at };
                _dbContext.Settings.InsertOnSubmit(s);
                _dbContext.SubmitChanges();
                _dbContext.SetSetting(idAccessToken, _at);
            }
            else { // Update access token
                _dbContext.SetSetting(idAccessToken, _at);
                _dbContext.SubmitChanges();
                DbLogUserActivity($"Edit Setting {idAccessToken} to {_at}", Util.UserId);
            }
            if (!_dbContext.Settings.Any(s => s.Id == idRefreshToken))
            { //Create refresh token
                var s = new Setting { Id = idRefreshToken, SettingX = _rt };
                _dbContext.Settings.InsertOnSubmit(s);
                _dbContext.SubmitChanges();
                _dbContext.SetSetting(idRefreshToken, _rt);
            }
            else
            { // Update refresh token
                _dbContext.SetSetting(idRefreshToken, _rt);
                _dbContext.SubmitChanges();
                DbLogUserActivity($"Edit Setting {idRefreshToken} to {_rt}", Util.UserId);                
            }

            return RedirectToAction("Finish");
        }

        protected virtual void DbLogUserActivity(string _activity, int _userId)
        {
            DbUtil.LogActivity(_activity, userId: _userId);
        }

        [Route("~/Pushpay/Finish")]
        public ActionResult Finish()
        { return View();  }

        public async Task<AccessToken> AuthorizationCodeCallback(string _authCode)
        {            
            
                       
            // exchange authorization code at authorization server for an access and refresh token
            Dictionary<string, string> post = null;
            post = new Dictionary<string, string>
            {
                { "client_id", _configurationManager.Current.PushpayClientID}
                ,{"client_secret", _configurationManager.Current.PushpayClientSecret}
                ,{"grant_type", "authorization_code"}
                ,{"code", _authCode}
                ,{"redirect_uri", _configurationManager.Current.TouchpointAuthServer}
            };

            var client = new HttpClient();
            //Setting a "basic auth" header
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", _configurationManager.Current.PushpayClientID, _configurationManager.Current.PushpayClientSecret)
                        )));            
            var postContent = new FormUrlEncodedContent(post);
            
            var response = await client.PostAsync(_configurationManager.Current.OAuth2TokenEndpoint, postContent);
            var content = await response.Content.ReadAsStringAsync();
            var _accessToken = new AccessToken();
            // exchange code for tokens from authorization server
            try {                
                var json = JObject.Parse(content);                
                _accessToken.access_token = json["access_token"].ToString() ?? throw new ArgumentNullException("access_token");
                _accessToken.token_type = json["token_type"].ToString() ?? throw new ArgumentNullException("token_type");
                var _expires_in = json["expires_in"].ToString() ?? throw new ArgumentNullException("expires_in");
                _accessToken.expires_in = Convert.ToInt64(_expires_in);
                if (json["refresh_token"] != null)
                    _accessToken.refresh_token = json["refresh_token"].ToString();
            }
            catch (Exception ex) {
                ModelState.AddModelError("form", ex.Message);                
            }            
            if (_accessToken != null)
                return _accessToken;
            else return null;                        
        }
        
    }
}
