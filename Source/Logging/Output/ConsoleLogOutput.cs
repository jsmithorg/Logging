using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tmobile.Framework.Logging.Output
{
    internal sealed class ConsoleLogOutput : LogOutput
    {
        public override void Trace(FormattedMessage message)
        {
            Console.WriteLine(message.ToString());

        }//end method 

        public override void Info(FormattedMessage message)
        {
            Console.WriteLine(message.ToString());

        }//end method 

        public override void Warn(FormattedMessage message)
        {
            Console.WriteLine(message.ToString());

        }//end method

        public override void Debug(FormattedMessage message)
        {
            Console.WriteLine(message.ToString());

        }//end method 

        public override void Error(FormattedMessage message)
        {
            Console.WriteLine(message.ToString());

        }//end method

        public override void Fatal(FormattedMessage message)
        {
            Console.WriteLine(message.ToString());

        }//end method 

    }//end class

}//end namespace