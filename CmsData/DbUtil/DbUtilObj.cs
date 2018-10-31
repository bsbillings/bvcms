using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using UtilityExtensions;
using CmsData.Interfaces;
using CmsData;

namespace CmsData
{
    public class DbUtilObj : IDbUtilManager
    {
        public CMSDataContext Create(string host)
        {
            return DbUtil.Create(host);
        }
    }
}

