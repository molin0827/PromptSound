using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Media;
using System.Windows.Forms;
using System.IO;
using System.Web;

namespace PromptSound
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
            string url = "http://5.emopshop.sinaapp.com/SyncData/get_verify_count";
            Encoding code = Encoding.GetEncoding("utf-8");
            WebRequest wr = WebRequest.Create(url);
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Timeout = 20000;
            WebResponse response;
            response = wr.GetResponse();
            string html;
            html = new StreamReader(response.GetResponseStream(), code).ReadToEnd();
            //html = "0";
            //label1.Text = html;
            
            int a = int.Parse(html);
            if (a > 0)
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "msg.wav";
                sp.Load();
                sp.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Console.Out.WriteLine("this my write");
                string url = "http://5.emopshop.sinaapp.com/SyncData/get_verify_count";
                Encoding code = Encoding.GetEncoding("utf-8");
                WebRequest wr = WebRequest.Create(url);
                wr.Credentials = CredentialCache.DefaultCredentials;
                wr.Timeout = 20000;
                WebResponse response;
                response = wr.GetResponse();
                string html;
                html = new StreamReader(response.GetResponseStream(), code).ReadToEnd();
                //html = "0";
                //label1.Text = html;

                int a = int.Parse(html);
                if (a > 0)
                {
                    SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation = "msg.wav";
                    sp.Load();
                    sp.Play();
                }
            }
            catch( Exception ex)
            {
                Console.Out.WriteLine(ex);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                notifyIcon1.Visible = true;
                this.Hide();
                return;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
