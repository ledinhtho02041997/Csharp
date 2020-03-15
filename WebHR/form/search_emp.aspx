<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_emp.aspx.cs" Inherits="Webhr.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách nhân viên</title>
    <link rel="stylesheet" type="text/css" href="~/resource/search_emp.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            danh sách nhân viên
        </div>

        <div class="main">
            <div class="content">
                <div class="row">
                    Mã nhân viên
                    <input type="text"  id="txtmanhanvien" name="username" runat="server"/>
                </div>
                <div class="row">
                    Họ tên
                    <input type="text"  id="txthoten" name="hoten" runat="server"/>
                </div>
              
                <div class="row">
                    Công ty
                    <asp:DropDownList Class="drop"  id="ddlcongty"  runat="server"/> 
                </div>
                <div class="row">
                    <asp:Button Class="button" id="btbSearch"  runat="server" text= "TÌM" OnClick="btbSearch_Click"  /> 
                </div>
            </div> <!--hết content-->
        </div>  <!--hết main-->

        <div class="bang">
            <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" AllowSorting="True" PageSize="50" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" >
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                        <ItemTemplate><%#get_stt() %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Mã" HeaderText="Mã"> </asp:BoundField> 
                    <asp:BoundField DataField="Tên" HeaderText="Tên"> </asp:BoundField>
                    <asp:BoundField DataField="Giới tính" HeaderText="Giới tính"> </asp:BoundField>
                    <asp:BoundField DataField="Ngày vào làm" HeaderText="Ngày vào làm"> </asp:BoundField>
                    <asp:BoundField DataField="Công ty" HeaderText="Công ty"> </asp:BoundField>
                    <asp:BoundField DataField="Chức danh" HeaderText="Chức danh"> </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div> <!--hết bảng-->
    </form>
</body>
</html>
