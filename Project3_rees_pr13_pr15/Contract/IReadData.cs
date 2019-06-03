using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IReadData
    {
        [OperationContract]
        string ReadLastValue(string code);

        [OperationContract]
        string ReadValueFromTimeInterval(DateTime start, DateTime end, string code);
    }
}
