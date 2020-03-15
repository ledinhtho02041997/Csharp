using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace Webhr
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static string chuoiketnoi = WebConfigurationManager.ConnectionStrings["stringconnec"].ConnectionString;
        SqlConnection myConn = new SqlConnection(chuoiketnoi);

        int stt = 1;
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }

        public void Load_NV()
        {
            stt = GridView1.PageIndex * 50 + 1;

            string sql = " EXEC dbo.search '" + txtmanhanvien.Value.ToString() + "','"+txthoten.Value.ToString()+"','"+ddlcongty.SelectedValue+"';";

            Business.LoadDataControl(GridView1, sql);
        }

        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.LoadDataControl(ddlcongty, "Select distinct LSCompanyName, LSCompanyID From Company", "LSCompanyName", "LSCompanyID");
                Load_NV();
            }
        }

        protected void btbSearch_Click(object sender, EventArgs e)
        {
            Load_NV();
            if (GridView1.Rows.Count == 0) 
                Response.Write("<script>alert('" + "Không có dữ liệu được tìm thấy" + "')</script>");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Load_NV();
        }
    }
}