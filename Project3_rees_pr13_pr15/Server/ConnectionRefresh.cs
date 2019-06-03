using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ConnectionRefresh
    {
        private ServiceHost serviceHost;

        public ConnectionRefresh()
        {
            Start();
        }


        public void Start()
        {
            serviceHost = new ServiceHost(typeof(RefreshDataProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IRefreshData), binding, new Uri("net.tcp://localhost:7100/RefreshDataProvider"));
            try
            {
                serviceHost.Open();
            }
            catch (Exception e)
            {
            }
        }
    }
}
