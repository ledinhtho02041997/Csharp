using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SendEmail
{
    public partial class App_Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btbSend_Click(object sender, EventArgs e)
        {
            try
            {
                void CreatesFolder()
                {
                    DirectoryInfo thisFolder = new DirectoryInfo(Server.MapPath("UploadedFiles"));
                    if (!thisFolder.Exists)
                        thisFolder.Create();
                }

                void Deletefolder()
                {
                    DirectoryInfo thisFolder = new DirectoryInfo(Server.MapPath("UploadedFiles"));
                    if (thisFolder.Exists)
                        thisFolder.Delete(true);                   
                }

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

                Deletefolder();
                CreatesFolder();
                if (file.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in file.PostedFiles)
                    {
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/UploadedFiles/"), uploadedFile.FileName));
                    }
                }
                //Multiple File Attachment
                string Uplodefile = Request.PhysicalApplicationPath + "UploadedFiles\\";
                string[] S1 = Directory.GetFiles(Uplodefile);
                foreach (string fileName in S1)
                {
                    message.Attachments.Add(new Attachment(fileName));
                }

                //thêm file vào listbox
                //      foreach (var filename in file.FileName)
                //  {
                //Thêm các file đã chọn vào listBox1
                //           listbox.Items.Add(filename.ToString());
                //   }

                //Kiểm tra nếu có file trong listBox1
                //      if (listbox.Items.Count > 0)
                //   foreach (var filename in listbox.Items)
                //Kiểm tra file có tồn tại trong ổ đĩa không
                //       if (File.Exists(filename.ToString()))
                //Thêm file đính kèm vào tin nhắn
                //    message.Attachments.Add(new Attachment(filename.ToString()));

                
                mailclient.Send(message);
                Response.Write("<script>alert('" + "Mail đã được gửi đi" + "')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + "Hãy kiểm tra lại" + "')</script>");
            }

        }

        
    }
}