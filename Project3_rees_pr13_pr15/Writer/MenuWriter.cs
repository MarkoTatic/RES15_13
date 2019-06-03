using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Writer
{
    public class MenuWriter
    {
        public string StartServer { get; set; }
        public string StatusWorker { get; set; }
        public string PreuzmiOdKlijenta { get; set; }

        SendDataToLoadBalancer sd = new SendDataToLoadBalancer();
        AddRemoveWorker anw = new AddRemoveWorker();

        public MenuWriter()
        {

        }

        public void StartServerMenu()
        {
            do
            {
                Console.WriteLine("1. Start sending data to Server[Y/N]");
                StartServer = Console.ReadLine();
                try
                {
                    if (CheckWriterInputRequest(StartServer))
                    {
                        RequestStartServer(StartServer);
                        //StartWriterUI();
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            } while (StartServer.ToLower() != "y");    

        }

        public bool CheckWriterInputRequest(string temp1)
        {
            bool check = false;
            if (temp1 == "Y" || temp1 == "y")
            {
                check = true;
                return check;
            }
            else if (temp1 == "N" || temp1 == "n")
            {
                check = false;
                return check;
            }
            else
            {
                throw new ArgumentException("Wrnog input[choose beetween Y,y or N,n");
            }
        }

        public bool RequestStartServer(string SS)
        {
            bool start = false;
            if (SS == "Y" || SS == "y")
            {
                sd.SendDataEvry2Seconds();
                start = true;
                return start;
            }
            else if (SS == "N" || SS == "n")
            {
                start = false;
                return start;
            }
            else
            {
                throw new ArgumentException("Wrong parameter");
            }
        }

        public void StartWriterUI()
        {
            string pom = "";
            do
            {
                pom = PrintMenu();
                try
                {
                    ActivateDeActivateWorker(pom);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            } while (pom != "x");
        }

        public string PrintMenu()
        {
            Console.WriteLine(@"
            Enter Command: + for add worker
                           - for delete worker
                           . for number of active workers
                           x for application exit");
            string temp = Console.ReadLine();
            return temp;
        }

        public bool ActivateDeActivateWorker(string request)
        {
            if (request == "+")
            {
                return anw.AddWorker();
            }
            else if (request == "-")
            {
                return anw.RemoveWorker();
            }
            else if (request == ".")
            {
                int tempWorkerNumber = 0;
                //tempWorkerNumber = anw.proxy2.vratiListuWorkeraOdnosnoBrojWorkera();
                tempWorkerNumber = anw.ReturnNumberOfWorkers();
                Console.WriteLine("Activate workers:" + tempWorkerNumber);
                return true;
            }
            else if (request == "x")
            {
                Console.WriteLine("Turning OFF Writer");
                return true;
            }
            else
            {
                throw new ArgumentException("Pogresan unos od klijenta");
            }
        }


    }
}
