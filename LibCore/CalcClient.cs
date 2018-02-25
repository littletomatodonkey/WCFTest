using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace LibCore
{
    public class CalcClient : ClientBase<ICalc>, IDisposable
    {
        public CalcClient() : base()
        {
        }

        public CalcClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        public CalcClient(string endpointConfigurationName, string uri)
            : base(endpointConfigurationName, uri)
        {
        }

        public double Add(double n1, double n2)
        {
            return base.Channel.Add(n1, n2);
        }

        public double Subtract(double n1, double n2)
        {
            return base.Channel.Subtract( n1, n2 );
        }

        public double Multiply(double n1, double n2)
        {
            return base.Channel.Multiply(n1, n2);
        }

        public double Divide(double n1, double n2)
        {
            return base.Channel.Divide(n1, n2);
        }

        public Stream GetFile(string virtualPath)
        {
            Stream s = base.Channel.GetFile(virtualPath);
            return s;
        }

        public void PutFile(FileUploadMessage msg)
        {
            base.Channel.PutFile(msg);
        }

        #region IDisposable Members
        public void Dispose()
        {
            if (this.State != CommunicationState.Closed)
                this.Abort();
            this.Close();
        }
        #endregion
    }
}
