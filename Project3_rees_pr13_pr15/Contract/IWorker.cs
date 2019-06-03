using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IWorker
    {

        bool IsWorking { get; set; }
        int IdWorkera { get; set; }
        DateTime TimeStamp { get; set; }
        bool ReaderRequested { get; set; }
    }
}
