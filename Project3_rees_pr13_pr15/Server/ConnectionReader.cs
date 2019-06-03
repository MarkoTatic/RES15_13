using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ConnectionReader
    {
        private ServiceHost serviceHost;

        public ConnectionReader()
        {
            Start();
        }


        public void Start()
        {
            serviceHost = new ServiceHost(typeof(ReadDataProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IReadData), binding, new Uri("net.tcp://localhost:7000/ReadDataProvider"));
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