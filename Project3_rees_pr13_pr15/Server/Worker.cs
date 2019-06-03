﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataBase;

namespace Server
{
    public struct WorkerProperty
    {
        public string code;
        public float workerValue;
    };

    public struct CollectionDescription
    {
        public int id;
        public int dataSet;
        public HistoricalCollection listaItema;
    };

    public struct HistoricalCollection
    {
        public List<WorkerProperty> items;
    };

    public class Worker : IWorker
    {
        CollectionDescription collectionDescription1 = new CollectionDescription();
        CollectionDescription collectionDescription2 = new CollectionDescription();
        CollectionDescription collectionDescription3 = new CollectionDescription();
        CollectionDescription collectionDescription4 = new CollectionDescription();

        HistoricalCollection historicalCollection1 = new HistoricalCollection();
        HistoricalCollection historicalCollection2 = new HistoricalCollection();
        HistoricalCollection historicalCollection3 = new HistoricalCollection();
        HistoricalCollection historicalCollection4 = new HistoricalCollection();
        
        List<WorkerProperty> workerProperties1 = new List<WorkerProperty>();
        List<WorkerProperty> workerProperties2 = new List<WorkerProperty>();
        List<WorkerProperty> workerProperties3 = new List<WorkerProperty>();
        List<WorkerProperty> workerProperties4 = new List<WorkerProperty>();

        CollectionDescription collectionDescriptionDataBase = new CollectionDescription();

        public static int redBroj = -1; 
        public static int BrojWorkera { get; set; }

        public bool IsWorking { get; set; }
        public int IdWorkera { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool ReaderRequested { get; set; }

        public Worker()
        {
            IdWorkera = ++redBroj;
            ReaderRequested = false;
            BrojWorkera = IdWorkera;
            IsWorking = false;

        }

        public bool ProcessData(Description description)
        {
            this.IsWorking = true;
            string temporaryReturn = "";
            WorkerProperty wp = new WorkerProperty();

            RepackData(description, wp);

            IWorkerModel workerModel = new WorkerModel();
            workerModel = CreateEntity(collectionDescriptionDataBase);

            SqlDataAccess sqliteDataAccess = new SqlDataAccess();
            if (CheckCode(workerModel.Code, workerModel.Value, sqliteDataAccess))
            {
                Console.WriteLine("Podatak se cuva . . . ");
                AddDataToTable(workerModel, collectionDescriptionDataBase.dataSet, sqliteDataAccess);
                temporaryReturn += "Worker ID:" + IdWorkera + Environment.NewLine;
                Console.WriteLine("Podatak sacuvan");
            }
            else
            {
                temporaryReturn += "Worker ID:" + IdWorkera + Environment.NewLine;
                Console.WriteLine("Podatak odbacen!");
                string test = "[" + DateTime.Now.ToString() + "] - " + "Podatak odbacen" + workerModel.Code + " - " + workerModel.Value;
                Logger.WriteToLogFile(test, @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt");
            }  
            
            Console.WriteLine(temporaryReturn);
            this.IsWorking = false;
            return true;
        }

        public IWorkerModel CreateEntity(CollectionDescription collectionDescriptionDataBase)
        {
            IWorkerModel workerModel = new WorkerModel();
            workerModel.Code = collectionDescriptionDataBase.listaItema.items[collectionDescriptionDataBase.listaItema.items.Count - 1].code;
            workerModel.Value = (int)(collectionDescriptionDataBase.listaItema.items[collectionDescriptionDataBase.listaItema.items.Count - 1].workerValue);
            workerModel.TimeStamp = DateTime.Now.ToString();

            return workerModel;
        }

        public bool RepackData(Description description, WorkerProperty wp)
        {
            if (description.dataSet == 1)
            {
                collectionDescription1.dataSet = description.dataSet;
                collectionDescription1.id = description.id;

                for (int i = 0; i < description.items.Count; i++)
                {
                    wp.code = description.items[i].code;
                    wp.workerValue = description.items[i].value;

                    workerProperties1.Add(wp);
                }

                historicalCollection1.items = workerProperties1;
                collectionDescription1.listaItema = historicalCollection1;

                collectionDescriptionDataBase = collectionDescription1;
                return true;
            }
            if (description.dataSet == 2)
            {
                collectionDescription2.dataSet = description.dataSet;
                collectionDescription2.id = description.id;

                for (int i = 0; i < description.items.Count; i++)
                {
                    wp.code = description.items[i].code;
                    wp.workerValue = description.items[i].value;

                    workerProperties2.Add(wp);
                }

                historicalCollection2.items = workerProperties2;
                collectionDescription2.listaItema = historicalCollection2;

                collectionDescriptionDataBase = collectionDescription2;
                return true;
            }
            if (description.dataSet == 3)
            {
                collectionDescription3.dataSet = description.dataSet;
                collectionDescription3.id = description.id;

                for (int i = 0; i < description.items.Count; i++)
                {
                    wp.code = description.items[i].code;
                    wp.workerValue = description.items[i].value;

                    workerProperties3.Add(wp);
                }

                historicalCollection3.items = workerProperties3;
                collectionDescription3.listaItema = historicalCollection3;

                collectionDescriptionDataBase = collectionDescription3;
                return true;
            }
            if (description.dataSet == 4)
            {
                collectionDescription4.dataSet = description.dataSet;
                collectionDescription4.id = description.id;

                for (int i = 0; i < description.items.Count; i++)
                {
                    wp.code = description.items[i].code;
                    wp.workerValue = description.items[i].value;

                    workerProperties4.Add(wp);
                }

                historicalCollection4.items = workerProperties4;
                collectionDescription4.listaItema = historicalCollection4;

                collectionDescriptionDataBase = collectionDescription4;
                return true;
            }

            return false;
        }

        public bool CheckCode(string code, int value, SqlDataAccess SDA)
        {
            int tempValue = 0;
            bool dataSet = false;

            if (code != "CODE_DIGITAL")
            {
                if (code == "CODE_ANALOG")
                {
                    try
                    {
                        tempValue = Int32.Parse(SDA.LoadLastData1(code, "Default", "DataSet1"));
                    }catch(Exception e)
                    {

                    }
                }
                else if (code == "CODE_CUSTOM" || code == "CODE_LIMITSET")
                {
                    try
                    {
                        tempValue = Int32.Parse(SDA.LoadLastData1(code, "Default", "DataSet2"));
                    }
                    catch (Exception e)
                    {

                    }
                }
                else if (code == "CODE_SINGLENODE" || code == "CODE_MULTIPLENODE")
                {
                    try
                    {
                        tempValue = Int32.Parse(SDA.LoadLastData1(code, "Default", "DataSet3"));
                    }
                    catch (Exception e)
                    {

                    }
                }
                else if(code == "CODE_CONSUMER" || code == "CODE_SOURCE")
                {
                    try
                    {
                        tempValue = Int32.Parse(SDA.LoadLastData1(code, "Default", "DataSet4"));
                    }
                    catch (Exception e)
                    {

                    }
                }

                dataSet = CheckDataSet(tempValue, value);
                if (dataSet == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            else
            {
                return true;
            }
        }

        public bool CheckDataSet(int tempValue, int value)
        {
            if(value < tempValue * 0.98 || value > tempValue * 1.02)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddDataToTable(IWorkerModel wm, int dataSet, ISqlDataAccess SDA)
        {
            if(dataSet == 1)
            {
                SDA.SaveData1(wm, "Default", "DataSet1");
                return true;
            }

            if (dataSet == 2) {
                SDA.SaveData1(wm, "Default", "DataSet2");
                return true;
            }

            if (dataSet == 3) {
                SDA.SaveData1(wm, "Default", "DataSet3");
                return true;
            }

            if (dataSet == 4)
            {
                SDA.SaveData1(wm, "Default", "DataSet4");
                return true;
            }
            return false;
        }

    }
}
