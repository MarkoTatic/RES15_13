using Common;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ReadDataProvider : IReadData
    {
        public string ReadLastValue(string code)
        {
            //throw new NotImplementedException();
            SqlDataAccess sqliteDataAccess = new SqlDataAccess();
            if (code == "CODE_ANALOG" || code == "CODE_DIGITAL")
            {
                return sqliteDataAccess.LoadLastData1(code, "Default", "DataSet1");
            }
            else if (code == "CODE_CUSTOM" || code == "CODE_LIMITSET")
            {
                return sqliteDataAccess.LoadLastData1(code, "Default", "DataSet2");
            }
            else if (code == "CODE_SINGLENODE" || code == "CODE_MULTIPLENODE")
            {
                return sqliteDataAccess.LoadLastData1(code, "Default", "DataSet3");
            }
            else {
                return sqliteDataAccess.LoadLastData1(code, "Default", "DataSet4");
            }
        }

        public string ReadValueFromTimeInterval(DateTime start, DateTime end, string code)
        {
            List<int> temp = new List<int>();
            string tempString = "";
            SqlDataAccess sqliteDataAccess = new SqlDataAccess();
            if (code == "CODE_ANALOG" || code == "CODE_DIGITAL")
            {
                temp = sqliteDataAccess.LoadDataFromInterval1(start, end, code, "Default", "DataSet1");
            }

            if (code == "CODE_CUSTOM" || code == "CODE_LIMITSET")
            {
                temp = sqliteDataAccess.LoadDataFromInterval1(start, end, code, "Default", "DataSet2");
            }

            if (code == "CODE_SINGLENODE" || code == "CODE_MULTIPLENODE")
            {
                temp = sqliteDataAccess.LoadDataFromInterval1(start, end, code, "Default", "DataSet3");
            }

            if (code == "CODE_CONSUMER" || code == "CODE_SOURCE")
            {
                temp = sqliteDataAccess.LoadDataFromInterval1(start, end, code, "Default", "DataSet4");
            }
            foreach (var v in temp)
            {
                tempString += v + "  ";
            }
            return tempString;
        }
    }
}
