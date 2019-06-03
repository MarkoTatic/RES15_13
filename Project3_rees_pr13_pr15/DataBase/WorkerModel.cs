using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataBase
{
    public class WorkerModel : IWorkerModel
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Code { get; set; }
        public string TimeStamp { get; set; }

        public WorkerModel()
        {

        }

        public WorkerModel(int id, int value, string code, string timeStamp)
        {
            Id = id;
            Value = value;
            Code = code;
            TimeStamp = timeStamp;
        }
    }
}
