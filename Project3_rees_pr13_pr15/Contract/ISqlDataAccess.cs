using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ISqlDataAccess
    {
        bool SaveData1(IWorkerModel workerModel, string connectionString, string DataSet);
    }
}
