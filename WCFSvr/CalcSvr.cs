using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LibCore;

namespace WCFSvr
{
    public class CalcSvr : ICalc
    {
        public event FileEventHandler FileRequested;
        public event FileEventHandler FileUploaded;
        public event FileEventHandler FileDeleted;

        public double Add(double n1, double n2)
        {
            //throw new TimeoutException();
            return n1 + n2;
        }
        public double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public double Divide(double n1, double n2)
        {
            return n1 / n2;
        }

        /// <summary>
        /// 将文件从客户端传到服务器
        /// </summary>
        /// <param name="msg"></param>
        public void PutFile(FileUploadMessage msg)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, msg.VirtualPath);
            string dir = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (var outputStream = new FileStream(filePath, FileMode.Create))
            {
                msg.DataStream.CopyTo(outputStream);
            }

            SendFileUploaded(filePath);
        }

        /// <summary>
        /// 从服务器获取文件
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public System.IO.Stream GetFile(string virtualPath)
        {
            SendFileRequested(virtualPath);

            Stream s;
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, virtualPath);
                if (File.Exists(filePath))
                    s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                else
                    s = new MemoryStream();
            }
            catch (Exception ex)
            {
                s = new MemoryStream();
            }
            return s;
        }

        /// <summary>
        /// Raises the FileUploaded event
        /// </summary>
        protected void SendFileUploaded(string vPath)
        {
            if (FileUploaded != null)
                FileUploaded(this, new FileEventArgs(vPath));
        }

        /// <summary>
        /// Raises the FileRequested event.
        /// </summary>
        protected void SendFileRequested(string vPath)
        {
            if (FileRequested != null)
                FileRequested(this, new FileEventArgs(vPath));
        }

    }

    public delegate void FileEventHandler(object sender, FileEventArgs e);

    public class FileEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the virtual path.
        /// </summary>
        public string VirtualPath
        {
            get { return _VirtualPath; }
        }
        string _VirtualPath = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEventArgs"/> class.
        /// </summary>
        /// <param name="vPath">The v path.</param>
        public FileEventArgs(string vPath)
        {
            this._VirtualPath = vPath;
        }
    }
}
