using Common;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class RefreshDataProvider : IRefreshData
    {
        public string RefreshRead(string code)
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
            else if (code == "CODE_SINGLENODE" || code == "CODE_MULIPLENODE")
            {
                return sqliteDataAccess.LoadLastData1(code, "Default", "DataSet3");
            }
            else
            {
                return sqliteDataAccess.LoadLastData1(code, "Default", "DataSet4");
            }
        }
    }
}
