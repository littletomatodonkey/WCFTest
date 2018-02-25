using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibCore;
using System.ServiceModel;

namespace WCFClt
{
    public partial class MainWnd : Form
    {
        public MainWnd()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("client start..." );
            cbOperation.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CalcSvrExecutor.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string hostName = "localhost";
            ushort calcServerPoint = 8001;
            string calcServerUri = "net.tcp://" + hostName + ":" + calcServerPoint.ToString();
            CalcSvrExecutor.Open(calcServerUri);
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            double n1 = 0, n2 = 0, result = 0;
            try
            {
                n1 = Convert.ToDouble( tbNum1.Text );
                n2 = Convert.ToDouble(tbNum2.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            switch( cbOperation.SelectedIndex )
            {
                case 0:
                    CalcSvrExecutor.Execute(client => result = client.Add(n1, n2));
                    break;
                case 1:
                    CalcSvrExecutor.Execute(client => result = client.Subtract(n1, n2));
                    break;
                case 2:
                    CalcSvrExecutor.Execute(client => result = client.Multiply(n1, n2));
                    break;
                case 3:
                    CalcSvrExecutor.Execute(client => result = client.Divide(n1, n2));
                    break;
                default:
                    break;
            }
            Console.WriteLine( result );
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            string serverFn = "result.txt";
            string cltFp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "download.txt");
            Stream downloadStream = null;
            CalcSvrExecutor.Execute(client => downloadStream = client.GetFile( serverFn ));
            if (downloadStream != null)
            {
                using (FileStream output = new FileStream(cltFp, FileMode.Create))
                {
                    downloadStream.CopyTo(output);
                }
                downloadStream.Dispose();
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            string fp = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "result.txt" );
            FileUploadMessage msg = new FileUploadMessage()
            {
                VirtualPath = "result.txt",
                DataStream = new FileStream(fp, FileMode.Open, FileAccess.Read),
            };
            CalcSvrExecutor.Execute( client => client.PutFile(msg) );
        }

        
    }
}
