using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Xml;

namespace Tmobile.Framework.Logging.Output
{
    internal sealed class SOSLogOutput : LogOutput
    {
        private const string SOS_HOST = "localhost";
        private const int SOS_PORT = 4444;

        //private TcpClient _tcpClient;
        //private NetworkStream _stream;

        ~SOSLogOutput()
        {
           // if (_stream != null)
               // _stream.Close();

            //if (_tcpClient != null)
                //_tcpClient.Close();
            //
        }//end destructor

        private void WriteToSOS(string message, LogLevel level)
        {
            try
            {
                //if (_tcpClient == null)
                   // _tcpClient = new TcpClient();

                //if (!_tcpClient.Connected)
                    //_tcpClient.Connect(SOS_HOST, SOS_PORT);
            }
            catch (Exception ex)
            {
                //couldn't connect to SOS
                System.Diagnostics.Debug.WriteLine("Could not connect to SOS: " + ex);
                return;

            }//end try

            string sosMessage = "!SOS<showMessage key='" + level + "'><![CDATA[" + message + "]]></showMessage>\n";

            System.Diagnostics.Debug.WriteLine("SOS Message: " + sosMessage);

            byte[] bytes = Encoding.UTF8.GetBytes(sosMessage);

           // if (_stream == null)
                //_stream = _tcpClient.GetStream();

           // _stream.Write(bytes, 0, bytes.Length);

            //_stream.Close();

            //_tcpClient.Close();

            //"!SOS<showMessage key='" + type + "'><![CDATA[" + message + "]]></showMessage>\n"

        }//end method

        public override void Trace(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

            WriteToSOS(message.ToString(), message.Level);

        }//end method 

        public override void Info(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

        }//end method 

        public override void Warn(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

        }//end method

        public override void Debug(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

        }//end method 

        public override void Error(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

        }//end method

        public override void Fatal(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

        }//end method 

    }//end class

}//end namespace