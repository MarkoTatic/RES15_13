using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class NumberOfWorkerProvider : INumberOfWorkers
    {
        public int ActiveWorkers()
        {

            return LoadBalancer.Workers.Count;
        }
    }
}
