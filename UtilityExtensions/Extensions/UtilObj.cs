using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityExtensions.Interfaces;
using UtilityExtensions;

namespace UtilityExtensions.Extensions
{
    public class UtilObj : IUtilManager
    {
        private string _host;
        
        public string Host { get => Util.Host; set => _host = value; }
    }
}
