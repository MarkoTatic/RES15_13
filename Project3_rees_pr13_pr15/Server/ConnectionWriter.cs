using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public class ConnectionWriter
    {
        private ServiceHost serviceHost;

        public ConnectionWriter()
        {
            
        }

        public void Start()
        {
            serviceHost = new ServiceHost(typeof(ManagerWriter));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(ITurnOnOffWorker), binding, new Uri("net.tcp://localhost:6001/ManagerWriter"));
            serviceHost.Open();
        }
    }
}
