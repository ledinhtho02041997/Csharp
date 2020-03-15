<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_emp.aspx.cs" Inherits="Webhr.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới nhân viên</title>
    <link rel="stylesheet" type="text/css" href="~/resource/add_emp.css"/>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Mã nhân viên bạn nhập có thể đã tồn tại. Nếu đã tồn tại bạn có muốn cập nhật thông tin cho nhân viên đó không?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            thêm mới nhân viên
        </div> <!-- hết header-->

        <div class="main">
            <div class="content">
                <div class="row">
                    Mã nhân viên
                    <input type="text"  id="txtmanhanvien" name="manhanvien" runat="server" />
                </div>
                <div class="row">
                    Họ tên
                    <input type="text"  id="txthoten" name="hoten" runat="server"  />
                </div>
                <div class="row">
                    Giới tính
                    <asp:DropDownList Class="drop"  id="ddlgioitinh"  runat="server"/> 
                </div>
            
                 <div class="row">
                    Ngày sinh
                    <input type="date"  id="dngaysinh" name="ngaysinh" runat="server" />
                </div>
              
                <div class="row">
                    Công ty
                    <asp:DropDownList Class="drop"  id="ddlcongty"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcongty_SelectedIndexChanged"/> 
                </div>
             
                <div class="row">
                    Phòng ban
                    <asp:DropDownList Class="drop"  id="ddlphongban"  runat="server"/> 
                </div>
               
                <div class="row">
                    Chức danh
                    <asp:DropDownList Class="drop"  id="ddlchucdanh"  runat="server" >
                        <asp:ListItem Text="" Value=0 />
                    </asp:DropDownList>
                </div>
                <div class="row">
                    Ngày vào làm
                    <input type="date"  id="dngayvaolam" name="ngayvaolam" runat="server"  />
                </div>
            
                <div class="row">
                    Quốc tịch
                    <asp:DropDownList Class="drop"  id="ddlquoctich"  runat="server"/> 
                </div>
                <div class="row">
                    <asp:Button Class="button" id="btbAdd"  runat="server" text= "LƯU" OnClick="btbAdd_Click" OnClientClick="Confirm();" /> 
                    <asp:Button Class="button" id="ntnDanhSach"  runat="server" text= "DANH SÁCH" OnClick="ntnDanhSach_Click" /> 
                </div>
            </div>  <!--hết content-->
        </div> <!--hết main-->
    </form>
</body>
</html>
