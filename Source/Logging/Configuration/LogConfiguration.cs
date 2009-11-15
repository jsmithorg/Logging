using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Tmobile.Framework.Logging.Configuration
{
    public sealed class LogConfiguration
    {
        public Dictionary<string, string> Loggers { get; set; }
        public List<LogRule> Rules { get; set; }
        public List<LogTarget> Targets { get; set; }

    }//end class

}//end namespace