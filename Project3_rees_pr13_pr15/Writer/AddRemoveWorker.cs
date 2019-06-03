using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Writer
{
    public class AddRemoveWorker : IAddRemoveWorker
    {
        public ITurnOnOffWorker proxy2;

        public AddRemoveWorker()
        {
            ConnectToSetWorker();
        }

        public void ConnectToSetWorker()
        {
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<ITurnOnOffWorker> factory = new ChannelFactory<ITurnOnOffWorker>(binding, new EndpointAddress("net.tcp://localhost:6001/ManagerWriter"));

            proxy2 = factory.CreateChannel();
        }

        public bool AddWorker()
        {
            return proxy2.StartNewWorker();
        }

        public bool RemoveWorker()
        {
            return proxy2.RemoveWorker();
        }

        public int ReturnNumberOfWorkers()
        {
            return proxy2.vratiListuWorkeraOdnosnoBrojWorkera();
        }
    }
}
