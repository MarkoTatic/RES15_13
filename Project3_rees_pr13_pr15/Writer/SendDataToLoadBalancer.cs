using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Writer
{
    public class SendDataToLoadBalancer
    {
        private ISendRandomData2Seconds proxy;

        private static List<string> codes = new List<string>();

        public SendDataToLoadBalancer()
        {
            AddListofCodes(codes);
            Connect();
        }


        public void Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<ISendRandomData2Seconds> factory = new ChannelFactory<ISendRandomData2Seconds>(binding, new EndpointAddress("net.tcp://localhost:6000/LoadBalancer"));

            proxy = factory.CreateChannel();
        }


        public void SendDataEvry2Seconds()
        {
            Random rand = new Random();
            Task.Run(() =>
            {
                while (true)
                {
                    int trenutniCode = GetRandom1(0, 8);
                    //IsDigitalCode(trenutniCode);
                    float trenutnaVrednost = GetRandom2(0, 100, trenutniCode);
                    proxy.ForwardToLoadBalancer(codes[trenutniCode], trenutnaVrednost);
                    Thread.Sleep(2000);
                }
            });
        }


        public void AddListofCodes(List<string> codes)
        {
            codes.Add("CODE_ANALOG");
            codes.Add("CODE_DIGITAL");
            codes.Add("CODE_CUSTOM");
            codes.Add("CODE_LIMITSET");
            codes.Add("CODE_SINGLENODE");
            codes.Add("CODE_MULTIPLENODE");
            codes.Add("CODE_CONSUMER");
            codes.Add("CODE_SOURCE");
        }

        public int GetRandom1(int min, int max)
        {
            Random rand = new Random();
            int random = 0;
            random = rand.Next(min, max);


            return random;
        }
        public float GetRandom2(int min, int max, int currentCode)
        {
            Random rand = new Random();
            int random = 0;
            if (currentCode == 1)
            {
                random = rand.Next(min, max);
                random = random % 2;
            }
            else
            {
                random = rand.Next(min, max);
            }

            return random;
        }
    }
}
