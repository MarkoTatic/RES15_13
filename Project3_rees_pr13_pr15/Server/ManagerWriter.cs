using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    class ManagerWriter : ITurnOnOffWorker
    {
        public bool StartNewWorker()
        {
            Worker worker = new Worker();
            LoadBalancer.Workers.Add(worker);
            if (LoadBalancer.Workers != null)
                return true;
            return false;
        }

        public bool RemoveWorker()
        {
            if (LoadBalancer.Workers.Count != 0)
            {
                if ((LoadBalancer.Workers[LoadBalancer.Workers.Count - 1].IdWorkera) != LoadBalancer.CurrentWorker.IdWorkera)
                {
                    LoadBalancer.Workers.RemoveAt(LoadBalancer.Workers.Count - 1);
                    Worker.redBroj--;
                }
                else
                {
                    int brojac = 0;
                    LoadBalancer.Workers.RemoveAt(0);
                    foreach (Worker item in LoadBalancer.Workers)
                    {
                        item.IdWorkera = ++brojac;//da bi mi presortirao ostale workere u listi
                    }
                    LoadBalancer.brojacWorkera--;
                    Worker.redBroj--;
                }
                return true;
            }
            return false;
        }

        public int vratiListuWorkeraOdnosnoBrojWorkera()
        {
            int temp = 0;
            temp = LoadBalancer.Workers.Count();
            return temp;
        }
    }
}
