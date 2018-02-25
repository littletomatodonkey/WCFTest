using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace WCFSvr
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost host = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                if (host != null)
                    host.Close();
                host = new ServiceHost(typeof(CalcSvr));
                host.Open();
                Console.WriteLine("WCF svr start successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            
        }

        protected override void OnStop()
        {
            try
            {
                if (host != null)
                    host.Close();
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex);
            }
            

        }

    }
}
