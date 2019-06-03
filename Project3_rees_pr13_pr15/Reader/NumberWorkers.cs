using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class NumberWorkers
    {
        private INumberOfWorkers proxy;

        public INumberOfWorkers Proxy
        {
            get { return proxy; }
            set { proxy = value; }
        }

        public NumberWorkers()
        {

            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<INumberOfWorkers> factory = new ChannelFactory<INumberOfWorkers>(binding, new EndpointAddress("net.tcp://localhost:7200/NumberOfWorkerProvider"));

            proxy = factory.CreateChannel();
        }


        public int Number()
        {
            return proxy.ActiveWorkers();
        }
    }
}
