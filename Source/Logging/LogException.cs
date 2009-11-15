using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tmobile.Framework.Logging
{
    public class LogException : Exception
    {
        public LogException() : base() { }
        public LogException(string message) : base(message){}
        public LogException(string message, LogLevel level) : base(message)
        {

        }//end constructor

    }//end class

}//end namespace