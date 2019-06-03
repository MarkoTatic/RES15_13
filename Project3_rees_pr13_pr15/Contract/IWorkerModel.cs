using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IWorkerModel
    {
        int Id { get; set; }
        int Value { get; set; }
        string Code { get; set; }
        string TimeStamp { get; set; }
    }
}
