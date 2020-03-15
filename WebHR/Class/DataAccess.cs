using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Webhr
{
    public class DataAccess
    {
        static string chuoiketnoi = WebConfigurationManager.ConnectionStrings["stringconnec"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(chuoiketnoi);

        public DataAccess() { }

        public static DataTable GetData(string query)
        { 
            myConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, myConn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            myConn.Close();
            return tb;
        }

        public static bool Execute(string query)
        {
            try
            {
                myConn.Open();
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.ExecuteNonQuery();
                myConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                myConn.Close();
                return false;
            }
        }
    }
}