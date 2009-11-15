using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Tmobile.Framework.Logging.Output
{
    internal class FormattedMessage
    {
        #region Fields / Properties

        public DateTime DateTime { get { return DateTime.Now; } }
        public Assembly Assembly { get { return (Class != null) ? Class.Assembly : null; } }
        public Type Class { get { return (Method != null) ? Method.DeclaringType : null; } }
        public MethodBase Method { get; internal set; }
        public StackTrace StackTrace { get; internal set; }
        public LogLevel Level { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }

        private string _format;

        #endregion

        #region Constructor

        public FormattedMessage(string format)
        {
            _format = format;

            if (_format.Contains("${stacktrace}") ||
               _format.Contains("${method}") ||
               _format.Contains("${class}") ||
               _format.Contains("${assembly}"))
            {
                StackTrace = new StackTrace(3);
                StackFrame sf = StackTrace.GetFrame(0);
                Method = sf.GetMethod();
                
            }//end if

        }//end constructor

        public FormattedMessage(string format, string message) : this(format)
        {
            Message = message;

        }//end constructor

        #endregion

        public override string ToString()
        {
            string message = _format;

            if (message.Contains("${date}"))
                message = message.Replace("${date}", DateTime.ToString("yyyy-MM-dd"));

            if (message.Contains("${time}"))
                message = message.Replace("${time}", DateTime.ToString("HH:mm:ss"));

            if (message.Contains("${assembly}"))
                message = message.Replace("${assembly}", Assembly.FullName);

            if (message.Contains("${class}"))
                message = message.Replace("${class}", Class.FullName);

            if (message.Contains("${method}"))
                message = message.Replace("${method}", Method.Name);

            if (message.Contains("${stacktrace}"))
                message = message.Replace("${stacktrace}", Environment.NewLine + StackTrace.ToString());

            if (message.Contains("${category}"))
                message = message.Replace("${category}", Category);

            if (message.Contains("${level}"))
                message = message.Replace("${level}", Level.ToString());

            if (message.Contains("${message}"))
                message = message.Replace("${message}", Message);

            return message;

        }//end method

    }//end class

}//end namespace