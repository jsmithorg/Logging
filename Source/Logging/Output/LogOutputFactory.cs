using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tmobile.Framework.Logging.Configuration;

namespace Tmobile.Framework.Logging.Output
{
    internal static class LogOutputFactory
    {
        public static LogOutput CreateFromLogTarget(LogTarget target)
        {
            LogOutput output = null;
            LogType type = target.Type;

            switch (type)
            {
                case LogType.Console:
                    output = new ConsoleLogOutput();
                    break;

                case LogType.Debug:
                    output = new DebugLogOutput();
                    break;

                case LogType.SOS:
                    output = new SOSLogOutput();
                    break;

                case LogType.File:
                    throw new NotImplementedException("LogOutputFactory :: File output not yet implemented");
                    //break;

            }//end switch

            output.MessageFormat = target.Format;

            return output;

        }//end method

    }//end class

}//end namespace