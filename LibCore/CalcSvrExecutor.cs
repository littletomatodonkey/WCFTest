using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public class CalcSvrExecutor
    {
        private static CalcClient client = null;
        private static string serverUri = "";                   // 2016/01/03
        public static EventHandler FatalErrorEvent = null;      // 2016/01/03

        public static void Open(string uri)
        {
            if (client == null || uri != serverUri)
            {
                client = new CalcClient("CalcService", uri); // 2017/03/01
                serverUri = uri;        // 2016/01/03
            }
        }

        // 2017/03/01 {
        public static void Open()
        {
            if (client == null)
            {
                client = new CalcClient("CalcService");
                serverUri = "";
            }
        }
        // } 2017/03/01

        public static CalcErrorCode  Execute(Action<CalcClient> act)
        {
            CalcErrorCode errorCode = CalcErrorCode.None;
            try
            {
                if (client == null)
                    Open(serverUri);

                act(client);
                errorCode = CalcErrorCode.None;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                client.Abort();
                client = null;
                errorCode = CalcErrorCode.CommunicationWithServerError;
                OnFatalError();
                Console.WriteLine("WCF communication error happened.");
                Console.WriteLine( ex );
            }
            catch (TimeoutException)
            {
                client.Abort();
                client = null;
                errorCode = CalcErrorCode.CommunicationWithServerError;
                Console.WriteLine("WCF timeout happened.");
            }
            catch (DivideByZeroException ex)
            {
                client = null;
                errorCode = CalcErrorCode.DivideByZero;
                OnFatalError(); 
                Console.WriteLine(ex);
            }
            return errorCode;
        }

        public static void Close()
        {
            try
            {
                client.Close();
                client = null;
            }
            catch (System.ServiceModel.CommunicationException)
            {
                client.Abort();
                client = null;
                Console.WriteLine("WCF communication error happened.");
            }
            catch (TimeoutException)
            {
                client.Abort();
                client = null;
                Console.WriteLine("WCF timeout happened.");
            }
            catch (Exception ex)
            {
                client = null;
                Console.WriteLine(ex);
            }
        }

        private static void OnFatalError()      // 2016/01/03
        {
            if (FatalErrorEvent != null)
                FatalErrorEvent(null, null);
            client = null;
        }
    }
}
