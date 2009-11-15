using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tmobile.Framework.Logging.Configuration
{
    public class LogTarget
    {
        public string Name { get; set; }
        public LogType Type { get; set; }
        public string Format { get; set; }

        public override string ToString()
        {
            return "[ LogTarget name=\"" + Name +
                   "\" type=\"" + Type +
                   "\" format=\"" + Format + "\" ]";

        }//end method

    }//end class

}//end namespace