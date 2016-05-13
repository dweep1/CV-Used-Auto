using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RestServiceStackTemplate
{
    public class SqlDatabase : IDisposable
    {
        private SqlConnection myConn;
        private SqlCommand myComm;

        public SqlDatabase()
        {
            myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            RestoreCommand();
            myConn.Open();
        }

        private void RestoreCommand()
        {
            myComm = new SqlCommand();
            myComm.Connection = myConn;
            myComm.CommandType = CommandType.StoredProcedure;
        }

        public void AddParameter(string pm_name, object pm_value)
        {
            myComm.Parameters.AddWithValue(pm_name, pm_value);

        }

        public DataTable Fill(string sp_name)
        {
            myComm.CommandText = sp_name;
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(myComm);
            DataTable TestDT = new DataTable();
            myDataAdapter.Fill(TestDT);
            myDataAdapter.Dispose();
            RestoreCommand();
            return TestDT;
        }
        public int ExecuteNonQuery(string sp_name)
        {
            myComm.CommandText = sp_name;
            int n = myComm.ExecuteNonQuery();
            // RestoreCommand();
            return n;
        }

        public void AdapterUpdate(string sp_name, DataTable dt)
        {
            myComm.CommandText = sp_name;
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(myComm);
            DataTable origDT = new DataTable();
            myDataAdapter.Fill(origDT);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(myDataAdapter);

            myDataAdapter.Update(dt);
            myDataAdapter.Dispose();
            RestoreCommand();
        }

        #region IDisposable Members

        public void Dispose()
        {
            myComm.Dispose();
            myConn.Dispose();
        }

        #endregion
    }
}