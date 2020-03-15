using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Webhr
{
    public class Business
    {
        public static void LoadDataControl(DropDownList ddl, string query){}

        public static void LoadDataControl(DropDownList ddl, string query,string obj1, string obj2)
        {
            ddl.DataSource = DataAccess.GetData(query);
            ddl.DataTextField = obj1;
            ddl.DataValueField = obj2;
            ddl.DataBind();
            ddl.Items.Insert(0, "");
        }

        public static void LoadDataControl(GridView grid, string query)
        {
            grid.DataSource = DataAccess.GetData(query);
            grid.DataBind();
        }

        public static bool Execute(string query)
        {
            if (DataAccess.Execute(query))
                return true;
            else return false;
        }

        // Tách họ tên thành FirstName và LastName
        public static string[] Cat_hoten(string hoten)
        {
            String[] a = new string[2];
            int index = hoten.LastIndexOf(" ");
            if (index == -1)
            {
                a[0] = "";
                a[1] = hoten.ToString();
            }
            else
            {
                a[0] = hoten.Substring(0, index);
                a[1] = hoten.Substring(index + 1, hoten.Length - index - 1);
            }
            return a;
        }
    }
}