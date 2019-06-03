using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadBOpenConnection LBconnection = new LoadBOpenConnection();
            ConnectionWriter connectionWriter = new ConnectionWriter();
            ConnectionReader connectionReader = new ConnectionReader();

            ConnectionRefresh connectionRefresh = new ConnectionRefresh();
            ConnectionNoW connectionNoW = new ConnectionNoW();
            LBconnection.Start();
            connectionWriter.Start();

           

            Console.ReadKey();
        }
    }
}
