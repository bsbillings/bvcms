using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CmsData;

namespace CmsData.Interfaces
{
    public interface IDbUtilManager
    {
        CMSDataContext Create(string host);
        

        //string PushpayScope { get; }
    }
}
