using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public class LoadBOpenConnection
    {
        private ServiceHost serviceHost;
        public LoadBOpenConnection()
        {
            
        }

        public void Start()
        {
            serviceHost = new ServiceHost(typeof(LoadBalancer));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(ISendRandomData2Seconds), binding, new Uri("net.tcp://localhost:6000/LoadBalancer"));
            serviceHost.Open();
        }
    }
}
