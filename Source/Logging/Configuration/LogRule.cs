using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tmobile.Framework.Logging.Configuration
{
    public class LogRule
    {
        public string Class { get; set; }
        public List<LogLevel> Levels { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Targets { get; set; }

        public LogRule()
        {
            Levels = new List<LogLevel>();
            Categories = new List<string>();
            Targets = new List<string>();

        }//end constructor

        public override string ToString()
        {
            return "[ LogRule class=\"" + Class +
                   "\" levels=\"" + Levels.Count +
                   "\" categories=\"" + Categories.Count +
                   "\" targets=\"" + Targets.Count + "\" ]";
        
        }//end method

    }//end class

}//end namespace