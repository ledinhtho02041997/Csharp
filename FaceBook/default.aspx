<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FaceBook.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facebook</title>
    <link rel="stylesheet" type="text/css" href="file/Style.css" />
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
    <meta name = "theme-color"  content = "#ffffff" >
</head>
<body>
    <form id="form1" runat="server">
       <div id="header">
           <div id="header-content">
               <div id="left">
                   <a href="#" title="Vào trang chủ facebook"><b>facebook</b></a>
               </div>
            <div id="right">
                <table>
                    <tr>
                        <td>Email hoặc điện thoại</td>
                        <td>Mật khẩu</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td ><input type="text" /></td>
                        <td ><input type="password" /></td>
                        <td ><input type="button"  value="Đăng nhập"/></td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td ><a href="#"  >Quên mật khấu?</a></td>
                        <td ></td>
                    </tr>
                </table>
            </div>
           </div>
       </div>
        <div id="main">
            <div id="main-content">
                <div id="left">
                    <div style="font-size:18px;color:#0e385f;"><b>Facebook giúp bạn kết nối và chia sẻ với mọi người trong cuộc sống của bạn.</b></div>
                    <img src="file/image/face.png" />
                </div>
                <div id="right">
                    <div style="font-size:35px;padding-top:0px;font-weight:bold">Đăng ký</b></div>
                    <p style="font-size:18px;color:black;">Nhanh chóng và dễ dàng.</p>
                    <input type="text" value="Họ" />
                    <input type="text" value="Tên"/>
                    <input type="text" style="width:400px;"value="Số di động hoặc email"/>
                    <input type="text" style="width:400px;"value="Mật khẩu mới"/>
                    <p style="font-size:20px;color:#90949c;">Ngày sinh</p>
                    <input type="date" name="bday">
                    <p style="font-size:20px;color:#90949c;">Giới tính</p>
                    <input type="radio" name="gender" value="male" /> Nam
                    <input type="radio" name="gender" value="female"/> Nữ<br />
                    <p style="margin-top:30px">Bằng cách nhấp vào Đăng ký, bạn đồng ý với <a  href="#"> Điều khoản</a>, <a href="#">Chính sách dữ liệu</a> và <a href="#">Chính sách cookie</a> của chúng tôi. Bạn có thể nhận được thông báo của chúng tôi qua SMS và hủy nhận bất kỳ lúc nào.</p>
                    <input type="button" value="Đăng kí" /><br />
                    <p style="margin-top:50px;"><a href="#">Tạo Trang</a>  dành cho người nổi tiếng, nhãn hiệu hoặc doanh nghiệp.</p>
                  
                </div>
            </div>
        </div>
        <div id="footer">
            <div id="footer-content">
                <div>Copyright: Lê Đình Thơ</div>
                <div>Đại học sư phạm kĩ thuật TpHCM</div>
                <div>Facebook © 2019</div>
            </div>
        </div>
    </form>
</body>
</html>
