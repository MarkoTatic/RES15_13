using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public struct Item
    {
        public string code;
        public float value;
    };

    public struct Description
    {
        public int id;
        public List<Item> items;
        public int dataSet;
    };


    public class LoadBalancer : ISendRandomData2Seconds
    {
        private static List<Worker> workers = new List<Worker>();
        private static List<Item> allItems = new List<Item>();
        private static List<Description> allDescriptions = new List<Description>();
        private static Worker currentWorker = new Worker();

        private static Queue<Description> tasks = new Queue<Description>();

        public static int brojacWorkera = 1;

        public static List<Worker> Workers { get => workers; set => workers = value; }
        public static Worker CurrentWorker { get => currentWorker; set => currentWorker = value; }

        Description description1 = new Description();
        Description description2 = new Description();
        Description description3 = new Description();
        Description description4 = new Description();

        Description tempDescriptionToSend = new Description();

        List<Item> itemsDescription1 = new List<Item>();
        List<Item> itemsDescription2 = new List<Item>();
        List<Item> itemsDescription3 = new List<Item>();
        List<Item> itemsDescription4 = new List<Item>();

        public LoadBalancer()
        {
            description1.id = 1;
            description2.id = 2;
            description3.id = 3;
            description4.id = 4;

            description1.dataSet = 1;
            description2.dataSet = 2;
            description3.dataSet = 3;
            description4.dataSet = 4;

            description1.items = itemsDescription1;
            description2.items = itemsDescription2;
            description3.items = itemsDescription3;
            description4.items = itemsDescription4;

            allDescriptions.Add(description1);
            allDescriptions.Add(description2);
            allDescriptions.Add(description3);
            allDescriptions.Add(description4);
        }

        public void ForwardToLoadBalancer(string code, float value)
        {
            Item itemTemp = new Item();
            itemTemp.code = code;
            itemTemp.value = value;

            int tempDataSetValue = 0;
            bool tempDescription = false;
            tempDataSetValue = CheckDataSet(code);
            tempDescription = CheckDescription(tempDataSetValue, itemTemp);
           
            if (brojacWorkera == Workers.Count + 1)
            {
                brojacWorkera = 1;
            }

            Console.WriteLine("-----------SERVER RECIVED-----------");
            tasks.Enqueue(tempDescriptionToSend);
            Task.Run(() =>
            {
                try
                {
                    BalanceToWorkers();
                }catch(Exception e)
                {
                }
                Console.WriteLine("------------------------------------");

            });
        }


        public void BalanceToWorkers()
        {
            foreach (Worker item in Workers)
            {

                if (brojacWorkera == item.IdWorkera && item.IsWorking == false)
                {
                    if (item.IsWorking == true)
                    {
                        continue;
                    }
                    if (tasks.Count == 0)
                    {
                        break;
                    }
                    CurrentWorker = item;
                    item.ProcessData(tasks.Dequeue());
                    brojacWorkera++;
                }
            }
        }

        public int CheckDataSet(string cd)
        {
            int tempDataSet = 0;

            if(cd == "CODE_ANALOG" || cd == "CODE_DIGITAL")
            {
                tempDataSet = 1;
            }
            else if(cd == "CODE_CUSTOM" || cd == "CODE_LIMITSET")
            {
                tempDataSet = 2;
            }
            else if(cd == "CODE_SINGLENODE" || cd == "CODE_MULTIPLENODE")
            {
                tempDataSet = 3;
            }
            else if(cd == "CODE_CONSUMER" || cd == "CODE_SOURCE")
            {
                tempDataSet = 4;
            }

            return tempDataSet;
        }

        public bool CheckDescription(int tempDataSetValue, Item itemTemp)
        {
            if (tempDataSetValue == 1)
            {
                description1.items.Add(itemTemp);
                tempDescriptionToSend = description1;
                return true;
            }
            else if (tempDataSetValue == 2)
            {
                description2.items.Add(itemTemp);
                tempDescriptionToSend = description2;
                return true;
            }
            else if (tempDataSetValue == 3)
            {
                description3.items.Add(itemTemp);
                tempDescriptionToSend = description3;
                return true;
            }
            else if (tempDataSetValue == 4)
            {
                description4.items.Add(itemTemp);
                tempDescriptionToSend = description4;
                return true;
            }
            return false;
        }

    }
}
