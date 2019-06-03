using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface ISendRandomData2Seconds
    {
        [OperationContract]
        void ForwardToLoadBalancer(string code, float value);
    }
}
