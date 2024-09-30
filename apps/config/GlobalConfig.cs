using SimpleMiniMarketSystem.apps.manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMiniMarketSystem.apps.config
{
    public static class GlobalConfig
    {
        public static IDbConnectionManager DbManager { get; set; }
    }
}
