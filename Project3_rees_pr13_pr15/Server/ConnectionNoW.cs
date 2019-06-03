using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ConnectionNoW
    {
        private ServiceHost serviceHost;

        public ConnectionNoW()
        {
            Start();
        }


        public void Start()
        {
            serviceHost = new ServiceHost(typeof(NumberOfWorkerProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(INumberOfWorkers), binding, new Uri("net.tcp://localhost:7200/NumberOfWorkerProvider"));
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
