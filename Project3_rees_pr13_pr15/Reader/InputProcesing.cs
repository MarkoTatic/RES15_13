﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class InputProcesing
    {
        Menu menu;

        private string code;

        LastValue connect = new LastValue();
        public InputProcesing() {

        }

        public void IniinitializationMenu()
        {
            menu = new Menu();
            menu.PrintRead();
            menu.PrintCode();
            this.code = menu.Code;
        }

        public void Process()
        {
            if (menu.Read == 1)
            {
                string lastValue = connect.ReadLastValue(code);
                Console.WriteLine("The last arrived value for the " + code + " is: " + lastValue);
                Console.WriteLine();

                string test = "[" + DateTime.Now.ToString() + "] - " + "Poslednja procitana vrednost je: " + lastValue;
                Logger.WriteToLogFile(test, @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt");

                Console.WriteLine("To refresh the last received value for the " + code + ", press r/R...");

                string refresh = Console.ReadLine();
                bool isValid = ChooseRefresh(refresh);

                while (isValid)
                {

                    Refreshing refreshing = new Refreshing();
                    lastValue = refreshing.ReadRefreshValue(code);
                    Console.WriteLine("The last refresh recived value for " + code +" is: " + lastValue);

                    Console.WriteLine();

                    test = "[" + DateTime.Now.ToString() + "] - " + "Poslednja procitana osvezena vrednost je: " + lastValue;
                    Logger.WriteToLogFile(test, @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt");

                    Console.WriteLine("To refresh the last received value for the " + code + ", press r/R...");
                    refresh = Console.ReadLine();
                    isValid = ChooseRefresh(refresh);
                }
            }
            else if (menu.Read == 2)
            {
                Console.WriteLine("Enter the date and time of the start of the interval in the form (mm/dd/yyyy hh:mm:ss) AM/PM");

                string start = Console.ReadLine();
                DateTime resultStart = new DateTime();
                DateTime.TryParse(start, out resultStart);

                bool isValid = false;

                try
                {
                    isValid = CheckDateTime(resultStart);
                    Console.WriteLine("This moment of beginning was chosen: " + resultStart + Environment.NewLine);
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                }

                if (isValid == true)
                {


                    Console.WriteLine("Enter the date and time of the end of the interval in the form (mm/dd/yyyy hh:mm:ss) AM/PM");

                    string stop = Console.ReadLine();
                    DateTime resultStop = new DateTime();
                    DateTime.TryParse(stop, out resultStop);

                    try
                    {
                        isValid = CheckDateTime(resultStop);
                        Console.WriteLine("For the moment of completion, the following was selected:" + resultStop + Environment.NewLine);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (isValid) {
                        bool isCorect = CheckCorectDateTime(resultStart, resultStop);
                        if(isCorect == true) {                         
                            ValuesFromInterval valuesFromInterval = new ValuesFromInterval();
                            string fromTheInterval = valuesFromInterval.ReadValuesFromInterval(resultStart, resultStop, code);
                            Console.WriteLine("Values ​​from the interval for " + code +" are: " + fromTheInterval);

                            string test = "[" + DateTime.Now.ToString() + "] - " + "Procitane vrednosti iz intervala su: " + fromTheInterval;
                            Logger.WriteToLogFile(test, @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt");

                        }
                    }
                    
                }
                
                Console.WriteLine("Please select the option to read data:" + Environment.NewLine);
            }
            else if (menu.Read == 3) {
                NumberWorkers num = new NumberWorkers();
                Console.WriteLine("Number of active workers: " + num.Number());
            }
            else
            {
                Console.WriteLine("Bad input, try again...");
            }
        }

        public bool CheckCorectDateTime(DateTime time1, DateTime time2)
        {
            bool ret = false;
            int check = 0;
            check = DateTime.Compare(time1, time2);

            if (check > 0)
            {
                string test = "[" + DateTime.Now.ToString() + "] - " + "Los unos datuma. Trenutak kraja intervala je kasniji od trenutka pocetka intervala...";
                Logger.WriteToLogFile(test, @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt");

                Console.WriteLine("Bad input date and time. The moment of the end of the interval is later than the start of the interval...");
                ret = false;
            }
            else if (check == 0)
            {
                string test = "[" + DateTime.Now.ToString() + "] - " + "Los unos datuma. Trenutci pocetka i kraja su isti...";
                Logger.WriteToLogFile(test, @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt");

                Console.WriteLine("Bad input date and time. The start and end times are equals...");
                ret = false;
            }
            else
            {
                Console.WriteLine("Moments are entered correctly.." + Environment.NewLine);
                ret = true;
            }

            return ret;
        }

        public bool ChooseRefresh(string input) {
            bool ret = false;
            if (input == "r" || input == "R")
            {
                ret = true;
            }
            else {
                ret = false;
            }

            return ret;
        }
        
        public bool CheckDateTime(DateTime result) {
            bool ret = false;
            if (result.ToString() == "1/1/0001 12:00:00 AM")
            {
                //ret = false;
                throw new ArgumentException("No good format is entered");
            }
            else {
                ret = true;
            }

            return ret;
        }
    }
}
