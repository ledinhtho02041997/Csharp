using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO; 
namespace Email
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var smtpServer = txtSMTPServer.Text.Trim();
                var port = 0;
                var chkSsl = chkSSL.Checked;
                var chkAuthen = chkAuth.Checked;
                var toEmail = txtToEmail.Text.Trim();
                var subject = txtSubject.Text;
                var body = txtBody.Text;
                var userName = txtUsername.Text.Trim();
                var password = txtPassword.Text;


                if (string.IsNullOrEmpty(smtpServer))
                {
                    MessageBox.Show("Bạn không được để trống SMTP Server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (string.IsNullOrEmpty(toEmail))
                {
                    MessageBox.Show("Bạn không được để trống To Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (string.IsNullOrEmpty(subject))
                {
                    MessageBox.Show("Mail không có Subject", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (string.IsNullOrEmpty(body))
                {
                    MessageBox.Show("Mail không có Body", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
                if (rdo25.Checked == true) 
                    port = 25;
                if (rdo587.Checked == true) 
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
                if (listBox1.Items.Count > 0)
                    foreach (var filename in listBox1.Items)
                        //Kiểm tra file có tồn tại trong ổ đĩa không
                        if (File.Exists(filename.ToString()))
                            //Thêm file đính kèm vào tin nhắn
                            message.Attachments.Add(new Attachment(filename.ToString()));


                mailclient.Send(message);
                MessageBox.Show("Mail đã được gửi đi", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hãy kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuth.Checked == true)
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cho phép chọn nhiều dòng trong OpenFileDialog
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var filename in openFileDialog1.FileNames)
                {
                    //Thêm các file đã chọn vào listBox1
                    listBox1.Items.Add(filename.ToString());
                }
            }
        }
    }
}