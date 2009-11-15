using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tmobile.Framework.Logging.Output
{
    internal sealed class DebugLogOutput : LogOutput
    {
        public override void Trace(FormattedMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.ToString());

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