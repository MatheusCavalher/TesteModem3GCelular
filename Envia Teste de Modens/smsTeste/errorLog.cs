using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;

namespace smsTeste
{
    class errorLog
    {
        String Log;
        public String ErrorLog(String Message)
        {
            StreamWriter sw = null;
            try
            {
                String sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
                String sPathName = @"AngioSysSMSSENDERErrorLog_";

                String sYear = DateTime.Now.Year.ToString();
                String sMonth = DateTime.Now.Month.ToString();
                String sDay = DateTime.Now.Day.ToString();

                String sErrorTime = sDay + "-" + sMonth + "-" + sYear;

                sw = new StreamWriter(sPathName + sErrorTime + ".txt", true);

                sw.WriteLine(sLogFormat + Message);
                sw.Flush();
            }
            catch (SqlException ex)
            {
                ErrorLog(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                    sw.Close();
                }
            }
            return Log;        
        }      
    }
}
