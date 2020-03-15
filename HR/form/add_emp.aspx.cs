using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Web.Configuration;


namespace Webhr
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string chuoiketnoi = WebConfigurationManager.ConnectionStrings["stringconnec"].ConnectionString;
        SqlConnection myConn = new SqlConnection(chuoiketnoi);

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack) // chưa có dữ liệu
            {
                Business.LoadDataControl(ddlgioitinh, "SELECT DISTINCT CASE WHEN Gender = 1 THEN 'Nam' ELSE N'Nữ' END AS Gender1, Gender FROM EmpCV", "Gender1", "Gender");    

                Business.LoadDataControl(ddlcongty, "SELECT DISTINCT LSCompanyName, LSCompanyID FROM Company", "LSCompanyName", "LSCompanyID");

                Business.LoadDataControl(ddlchucdanh, "SELECT DISTINCT LSJobTitleName, LSJobTitleID FROM JobTitle", "LSJobTitleName", "LSJobTitleID");
                
                Business.LoadDataControl(ddlquoctich, "SELECT DISTINCT LSNationalityName, LSNationalityID FROM Nationality", "LSNationalityName", "LSNationalityID");
            }
        }

        public void Insert()
        {
            int EmpCode = Convert.ToInt32(txtmanhanvien.Value);
            int ID = EmpCode;
            int EmpID = EmpCode;
            int active = 1;

            // Tách họ tên thành FirstName và LastName
            string lastname = Business.Cat_hoten(txthoten.Value.ToString())[0];
            string firstname = Business.Cat_hoten(txthoten.Value.ToString())[1];

            string sql1 = "EXEC dbo.Insert_Emp '"+EmpID+"','"+EmpCode+"','"+dngayvaolam.Value+"','"+ddlphongban.SelectedValue+"','"+ddlchucdanh.SelectedValue+"','"+active+"';";
            bool emp = Business.Execute(sql1);

            string sql2 = "EXEC dbo.Insert_EmpCV '"+ID+"','"+EmpID+"','"+firstname+"','"+lastname+"','"+dngaysinh.Value+"','"+ddlgioitinh.SelectedValue+"','"+ddlquoctich.SelectedValue+"';";
            bool empcv = Business.Execute(sql2);
            
            if (emp && empcv)
            {
                Response.Write("<script>alert('" + "Đã thêm nhân viên mới vào bảng" + "')</script>"); 
            }
            else
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                     sql1= "EXEC dbo.Update_Emp '" + EmpCode + "','" + dngayvaolam.Value + "','" + ddlphongban.SelectedValue + "','" + ddlchucdanh.SelectedValue + "';";
                     emp = Business.Execute(sql1);
                     sql2 = "EXEC dbo.Update_EmpCV '" + EmpID + "','" + firstname + "','" + lastname + "','" + dngaysinh.Value + "','" + ddlgioitinh.SelectedValue + "','" + ddlquoctich.SelectedValue + "';";
                     empcv = Business.Execute(sql2);
                    if (emp && empcv)
                        Response.Write("<script>alert('" + $"Đã cập nhật thông tin cho nhân viên có mã nhân viên là:  {EmpCode} " + "')</script>");
                    else 
                        Response.Write("<script>alert('" + "Đã xảy ra lỗi trong quá trình!" + "')</script>");
                }
                else
                {
                    Response.Write("<script>alert('" + "Mã nhân viên bạn nhập đã tồn tại!" + "')</script>");
                }
            }
        }

        protected void btbAdd_Click(object sender, EventArgs e)
        {
            Insert();  
        }

        protected void ntnDanhSach_Click(object sender, EventArgs e)
        {
            Response.Redirect("search_emp.aspx");
        }

        protected void ddlcongty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Business.LoadDataControl(ddlphongban, "SELECT DISTINCT LSDeptName,LSDeptID FROM Department WHERE Department.LSCompanyID = '" + ddlcongty.SelectedValue.ToString() + "'", "LSDeptName", "LSDeptID");
        }
    }
}