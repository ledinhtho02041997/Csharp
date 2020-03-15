<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="WebAppEmail.Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Email</title>
    <style>
        .form1 {
            margin: 0px;
            background-color: white;
            color: #3498db;
            font-family:Verdana;
        }

        p {
            width: 1460px;
            margin-left: 0px;
            background-color: #34495e;
            text-align: center;
            font-size: 25px;
            color: white;
            padding: 20px;
        }

        .form {
            margin: 0px 100px 0 100px;
            background-color: white;
            color: #3498db;
            font-family:Verdana;
            
        }

        label {   
            font-size: 30px;
            background-color: white;
        }

        input.text {
            border: 1px solid #3498db;
            width: 300px;
            height: 30px;
            font-family:Arial;
            font-size:20px;
            border-radius: 6px;
            padding-left: 0px;
            padding-top: 0px;
        }

        .chk {
            margin-left: 60px;
            width: 25px;
            height: 25px;
            color: white;
        }

        .display {
            display:block;
            margin-top: 30px;
        }

        .radio {
            width: 20px;
            height: 20px;
            margin-left: 180px;
        }

        hr {
            background-color: #5ccfb8; 
            width: 1290px;
            height: 2px;
            border:0;     
        }

        .button {
            width: 90px;
            height: 30px;
            background-color:#3498db;
            margin-left: 250px;
            color: white;
            border: 0;
            border-radius: 4px;
        }

        button:hover {
            background-color: blue;
        }

        button:active {
            background-color: blue;
        }
        
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>
            <div class="form1">
                <p><b>NOTIFICATION BY SEND EMAIL</b></p>
            </div>

            <div class="form">    
                <div class="display" style="margin-top:60px">
                    <label >SMTP Server</label> 
                    <input class="text" style="margin-left: 50px" type="text" runat="server" runat="server" id="txtSMTPServer" name="txtSMTPServer"/>
                    <label style="margin-left: 160px"> Authentication</label>
              <!--      <input class="chk" type="checkbox" runat="server" runat="server" id="chkAuth" name="auth" />  -->
                    <asp:CheckBox Class="chk"  runat="server" ID="chkAuth1" value="" OnCheckedChanged="chkAuth1_CheckedChanged" />
                </div>

                <div class="display">
                    <label >Port</label>
               <!--     <input class="radio" type="radio" runat="server" id="rdo25" name="25"/>  -->
                    <asp:RadioButton Class ="radio" runat="server" ID="rdio25" value="" GroupName="radio" OnCheckedChanged="rdio25_CheckedChanged" />
                    <label >25</label>
                <!--    <input class="radio" style="margin-left: 70px" type="radio" runat="server" id="rdo587" name="587"/> -->
                     <asp:RadioButton Class ="radio" style="margin-left: 70px;" runat="server" ID="rdio587" GroupName="radio" value="" OnCheckedChanged="rdio587_CheckedChanged" />
                    <label >587</label>
                    <label style="margin-left: 240px">Username</label>
                    <input class="text" style="margin-left: 120px;" type="text" runat="server" id="txtUsername" name="username" aria-atomic="False" />
                </div>
                
                <div class="display">
                    <label > Secure</label>
               <!--     <input class="chk" style="margin-left: 130px" type="checkbox" runat="server" id="chkSSL" name="ssl" />  -->
                    <asp:CheckBox Class="chk" style="margin-left: 130px; width: 25px; height: 25px;" runat="server" ID="chkSSL1" value=""/>
                    <label >SSL</label>
                    <label style="margin-left: 390px">Password</label>
                    <input class="text" style="margin-left: 125px;" type="password" runat="server" id="txtPassword" name="password"/>
                </div>

                <div class="display" style="margin-top:50px">
                    <hr align="left"/>
                </div>

                <div class="display" style="margin-top:50px">
                    <label >To Email</label>
                    <input class="text" style="margin-left: 115px" type="text" runat="server" id="txtToEmail" name="toemail"/>
                </div>

                <div class="display">
                    <label >Subject</label>
                    <input class="text" style="margin-left: 130px" type="text" runat="server" id="txtSubject" name="subject"/>
                </div>

                  <div class="display">
                    <label>Body</label>
                    <input class="text" style="position:relative;margin-top:0px; margin-left: 247px;margin-top:0px; width:1050px;height:170px; top: -35px; left: 0px;" type="text" runat="server" id="txtBody" name="body"/>
                </div>
    
               <div class="display" style="margin-top: 0px">     
                    <asp:Button Class="button" id="btbSend"  runat="server" text= "SEND" OnClick="btbSend_Click" />              
                </div>   
            </div>
        </div>
    </form>
</body>
</html>
