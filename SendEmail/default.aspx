<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SendEmail.App_Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SendEmail</title>
    <link rel="apple-touch-icon" sizes="57x57" href="file/image/apple-icon-57x57.png">
    <link rel="apple-touch-icon" sizes="60x60" href="file/image/apple-icon-60x60.png">
    <link rel="apple-touch-icon" sizes="72x72" href="file/image/apple-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="76x76" href="file/image/apple-icon-76x76.png">
    <link rel="apple-touch-icon" sizes="114x114" href="file/image/apple-icon-114x114.png">
    <link rel="apple-touch-icon" sizes="120x120" href="file/image/apple-icon-120x120.png">
    <link rel="apple-touch-icon" sizes="144x144" href="file/image/apple-icon-144x144.png">
    <link rel="apple-touch-icon" sizes="152x152" href="file/image/apple-icon-152x152.png">
    <link rel="apple-touch-icon" sizes="180x180" href="file/image/apple-icon-180x180.png">
    <link rel="icon" type="image/png" sizes="192x192"  href="file/image/android-icon-192x192.png">
    <link rel="icon" type="image/png" sizes="32x32" href="file/image/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="96x96" href="file/image/favicon-96x96.png">
    <link rel="icon" type="image/png" sizes="16x16" href="file/image/favicon-16x16.png">
    <link rel="manifest" href="file/image/manifest.json">
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="msapplication-TileImage" content="file/image/ms-icon-144x144.png">
    <meta name="theme-color" content="#ffffff">

    <link rel="stylesheet" type="text/css" href="file/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <div id ="header-content">
                <b>NOTIFICATION BY SEND EMAIL</b>
            </div>
        </div>

        <div id="main">
            <div id="main-content">
                <div id="line">
                    <label>SMTP Server</label>
                    <input class="text" style="margin-left: 30px;" type="text" runat="server"  id="txtSMTPServer" name="txtSMTPServer"/>
                    <label style="margin-left: 130px"> Authentication</label>
                    <asp:CheckBox Class="chk" style="margin-left: 30px;" runat="server" ID="chkAuth1" value="" />
                </div>
                
                <div id="line">
                    <label >Port</label>
                    <asp:RadioButton style="margin-left: 160px;" runat="server" ID="rdio25" value="" GroupName="radio"  />
                    <label >25</label>
                     <asp:RadioButton  style="" runat="server" ID="rdio587" GroupName="radio" value=""  />
                    <label >587</label>
                    <label style="margin-left: 265px">Username</label>
                    <input  style="margin-left: 100px;" type="text" runat="server" id="txtUsername" name="username" /><br />
                </div>

                <div id="line">
                    <label > Secure</label>
                    <asp:CheckBox Class="chk" style="margin-left: 115px; width: 25px; height: 25px;" runat="server" ID="chkSSL1" value=""/>
                    <label >SSL</label>
                    <label style="margin-left: 350px">Password</label>
                    <input class="text" style="margin-left: 110px;" type="password" runat="server" id="txtPassword" name="password"/>
                </div>

                <hr />

                <div id="line" style="display:block">
                    <label >To Email</label>
                    <input class="text" style="margin-left: 95px" type="text" runat="server" id="txtToEmail" name="toemail"/>
                </div>

                <div id="line" style="clear:left;">
                    <label style="margin-left: 0px">Subject</label>
                    <input class="text" style="margin-left: 110px" type="text" runat="server" id="txtSubject" name="subject"/>
                </div>

                  <div id="line" style="clear:left;">
                    <label >Body</label>
                    <input  style="margin-left: 150px;height:150px;width:1000px" type="text" runat="server" id="txtBody" name="body"/>
                </div>
                
               <div id="line"> 
                    <asp:Button Class="button" id="btbSend"  runat="server" text= "SEND" OnClick="btbSend_Click"  /> 
                   <asp:FileUpload style="margin-left:50px;" ID="file" runat="server" text="File" AllowMultiple="True" Width="451px"  />
                </div>  
            </div>
        </div>
    </form>
</body>
</html>
