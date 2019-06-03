using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Refreshing
    {
        private IRefreshData proxyRefresh;

        public IRefreshData Refresh
        {
            get { return proxyRefresh; }
            set { proxyRefresh = value; }
        }

        public Refreshing()
        {
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IRefreshData> factory = new ChannelFactory<IRefreshData>(binding, new EndpointAddress("net.tcp://localhost:7100/RefreshDataProvider"));

            proxyRefresh = factory.CreateChannel();
        }

        public string ReadRefreshValue(string code)
        {
            return proxyRefresh.RefreshRead(code);
        }
    }
}
