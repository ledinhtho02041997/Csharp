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

namespace Send_Email_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string smtpServer = txtSMTPServer.Text;
                int port = 0;
                if (rdo25.Checked == true) port = 25;
                if (rdo587.Checked == true) port = 587;


                SmtpClient mailclient = new SmtpClient(smtpServer, port);
                mailclient.EnableSsl = chkSSL.Checked;
                mailclient.Credentials = new NetworkCredential(txtUsername.Text, txtPassword.Text);

                MailMessage message = new MailMessage(txtUsername.Text, txtToEmail.Text);
                message.Subject = txtSubject.Text;
                message.Body = txtBody.Text;

                //Nếu có nhập Cc
                if (txtCc.Text != "")
                {
                    //Cắt chuỗi Cc bằng dấu ";"
                    string[] cc = txtCc.Text.Split(';');

                    foreach (var _cc in cc)
                    {
                        message.CC.Add(_cc.ToString());
                    }
                }

                //Nếu có nhập Bcc
                if (txtBcc.Text != "")
                {
                    //Cắt chuỗi Bcc bằng dấu ";"
                    string[] bcc = txtBcc.Text.Split(';');

                    foreach (var _bcc in bcc)
                    {
                        message.Bcc.Add(_bcc.ToString());
                    }
                }

                //Kiểm tra nếu có file trong listBox1
                if (listBox1.Items.Count > 0)
                {
                    foreach (var filename in listBox1.Items)
                    {
                        //Kiểm tra file có tồn tại trong ổ đĩa không
                        if (File.Exists(filename.ToString()))
                        {
                            //Thêm file đính kèm vào tin nhắn
                            message.Attachments.Add(new Attachment(filename.ToString()));
                        }
                    }
                }


                mailclient.Send(message);
                MessageBox.Show("Mail đã được gửi đi", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Hãy kiểm tra lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
