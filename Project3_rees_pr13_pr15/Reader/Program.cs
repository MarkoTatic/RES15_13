using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to READER. For further work, press ENTER...");
            Console.ReadLine();

            Console.WriteLine("Please select the option to read data:");

            //InputProcesing inputProcessing;

            while (true) {
                //inputProcessing = new InputProcesing();
                InputProcesing inputProcesing = new InputProcesing();
                inputProcesing.IniinitializationMenu();
                inputProcesing.Process();
            }
        }
    }
}
