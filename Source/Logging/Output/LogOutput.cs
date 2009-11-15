using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tmobile.Framework.Logging.Output
{
    internal abstract class LogOutput
    {
        public string MessageFormat { get; set; }

        public abstract void Trace(FormattedMessage message);
        public abstract void Info(FormattedMessage message);
        public abstract void Warn(FormattedMessage message);
        public abstract void Debug(FormattedMessage message);
        public abstract void Error(FormattedMessage message);
        public abstract void Fatal(FormattedMessage message);

    }//end class

}//end namespace