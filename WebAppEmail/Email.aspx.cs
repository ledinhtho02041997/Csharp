using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using WebAppEmail;


namespace WebAppEmail
{
    public partial class Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btbSend_Click(object sender, EventArgs e)
        {
         try
            {              

                var smtpServer = txtSMTPServer.Value.Trim();
                var port = 0;
                var chkSsl = chkSSL1.Checked;             
                var chkAuthen = chkAuth1.Checked;
                var toEmail = txtToEmail.Value.Trim();
                var subject = txtSubject.Value;
                var body = txtBody.Value;
                var userName = txtUsername.Value.Trim();
                var password = txtPassword.Value;

                if (string.IsNullOrEmpty(smtpServer))
                {
                    Response.Write("<script>alert('" + "Bạn không được để trống SMTP Server" + "')</script>");
                    return;
                }
                else if (string.IsNullOrEmpty(toEmail))
                {
                    Response.Write("<script>alert('" + "Bạn không được để trống To Email" + "')</script>");
                    return;
                }
                else if (string.IsNullOrEmpty(subject))
                {
                    Response.Write("<script>alert('" + "Mail không có Subject" + "')</script>");
                    return;
                }
                else if (string.IsNullOrEmpty(body))
                {
                    Response.Write("<script>alert('" + "Mail không có Body" + "')</script>");
                    return;
                }


                if (rdio25.Checked == true)
                    port = 25;
                if (rdio587.Checked == true)
                    port = 587;
                SmtpClient mailclient = new SmtpClient(smtpServer, port);
                mailclient.EnableSsl = chkSsl;
                if (chkAuthen == false)
                {
                    // dung tai khoan mac dinh de gui thu
                    userName = "ledinhtho241997@gmail.com";
                    password = "ledinhtho241997";
                }


                mailclient.Credentials = new NetworkCredential(userName, password);
                MailMessage message = new MailMessage(userName, toEmail);
                message.Subject = subject;
                message.Body = body;


                //Kiểm tra nếu có file trong listBox1
                //   if (listBox1.Items.Count > 0)
                //     foreach (var filename in listBox1.Items)
                //Kiểm tra file có tồn tại trong ổ đĩa không
                //        if (File.Exists(filename.ToString()))
                //Thêm file đính kèm vào tin nhắn
                //           message.Attachments.Add(new Attachment(filename.ToString()));


                mailclient.Send(message);
                Response.Write("<script>alert('" + "Mail đã được gửi đi" + "')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + "Hãy kiểm tra lại" + "')</script>");
            }  

        }

        protected void chkAuth1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuth1.Checked == true)
            {
                txtUsername.EnableViewState = true;
                txtPassword.EnableViewState = true;
            }
            else
            {
                txtUsername.EnableViewState = false;
                txtPassword.EnableViewState = false;
            }
        }

        protected void rdio25_CheckedChanged(object sender, EventArgs e)
        {
            if (rdio25.Checked == true) rdio587.Checked = false;     
        }

        protected void rdio587_CheckedChanged(object sender, EventArgs e)
        {
            if (rdio587.Checked==true) rdio25.Checked = false; 
        }
    }
}