using Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public bool SaveData1(IWorkerModel workerModel, string connectionString, string DataSet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString(connectionString)))
            {
                cnn.Execute("insert into " + DataSet + " (Value, Code, TimeStamp) values (@Value, @Code, @TimeStamp)", workerModel);              
            }
            return true;
        }

        public string LoadLastData1(string code, string connectionString, string DataSet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString(connectionString)))
            {
                var output = cnn.Query<WorkerModel>("select Value from "+ DataSet +" where Code = '" + code + "'", new DynamicParameters());
                string pom = "";
                foreach (var v in output)
                {
                    pom = v.Value.ToString();
                }
                return pom;
            }
        }

        public List<int> LoadDataFromInterval1(DateTime time1, DateTime time2, string code, string connectionString, string DataSet) {
            List<int> ret = new List<int>();
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString(connectionString))) {
                var output = cnn.Query<WorkerModel>("select Value from " + DataSet + " where Code = '" + code + "' and TimeStamp between '" + time1 + "' and '" + time2 + "'", new DynamicParameters());
                foreach (var v in output)
                {
                    ret.Add(v.Value);
                }
                return ret;
            }
        }

        public string LoadConnectionString(string connectionString)
        {
            string id = connectionString;
            return ConfigurationManager.ConnectionStrings[id].ConnectionString.ToString();
        }
    }
}
