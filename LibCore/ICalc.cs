using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace LibCore
{
    [ServiceContract]
    public interface ICalc
    {
        [OperationContract]
        double Add(double n1, double n2);

        [OperationContract]
        double Subtract(double n1, double n2);

        [OperationContract]
        double Multiply(double n1, double n2);

        [OperationContract]
        double Divide(double n1, double n2);

        [OperationContract]
        void PutFile(FileUploadMessage msg);

        [OperationContract]
        Stream GetFile( string virtualPath );

    }

    [MessageContract]
    public class FileUploadMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public string VirtualPath { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream DataStream { get; set; }
    }

    public static class StreamExtensions
    {
        /// <summary>
        /// Copies data from one stream to another.
        /// </summary>
        /// <param name="input">The input stream</param>
        /// <param name="output">The output stream</param>
        public static void CopyTo(this Stream input, Stream output)
        {
            const int bufferSize = 2048;
            byte[] buffer = new byte[bufferSize];
            int bytes = 0;

            while ((bytes = input.Read(buffer, 0, bufferSize)) > 0)
            {
                output.Write(buffer, 0, bytes);
            }
        }
    }

    public enum CalcErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        None,

        /// <summary>
        /// 被0整除
        /// </summary>
        DivideByZero,

        /// <summary>
        /// 与服务器通信错误
        /// </summary>
        CommunicationWithServerError,
    }
}
