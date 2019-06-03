using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class LastValue : ILastValue
    {
        private IReadData proxy;

        public IReadData Proxy
        {
            get { return proxy; }
            set { proxy = value; }
        }

        public LastValue()
        {

            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IReadData> factory = new ChannelFactory<IReadData>(binding, new EndpointAddress("net.tcp://localhost:7000/ReadDataProvider"));

            proxy = factory.CreateChannel();
        }


        public string ReadLastValue(string code)
        {
            return proxy.ReadLastValue(code);
        }
    }
}
