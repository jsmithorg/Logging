using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Xml.Linq;
using Tmobile.Framework.Logging.Configuration;
using System.Configuration;
using Tmobile.Framework.Logging.Output;

namespace Tmobile.Framework.Logging
{
    public static class LogManager
    {
        public static LogConfiguration Configuration { get; set; }

        public static string LogName { get; set; }

        /*static LogManager()
        {
            LogSection ls = (LogSection)ConfigurationManager.GetSection("tmobile.framework/log");

            Configuration = new LogConfiguration()
            {
                Targets = CreateLogTargets(ls.Targets),
                Rules = CreateLogRules(ls.Rules)
            };

        }//end constructor

        private static List<LogTarget> CreateLogTargets(LogTargetElementCollection targetElements)
        {
            List<LogTarget> targets = new List<LogTarget>();
            for (int i = 0; i < targetElements.Count; i++)
            {
                LogTargetElement lte = targetElements[i];
                targets.Add(new LogTarget()
                {
                    Name = lte.Name,
                    Type = (LogType)Enum.Parse(typeof(LogType), lte.Type),
                    Format = lte.Format
                });

                Debug.WriteLine("TARGET: " + lte.Name);

            }//end for

            return targets;

        }//end method
        

        private static List<LogRule> CreateLogRules(LogRuleElementCollection ruleElements)
        {
            List<LogRule> rules = new List<LogRule>();
            for (int i = 0; i < ruleElements.Count; i++)
            {
                LogRuleElement lre = ruleElements[i];
                rules.Add(new LogRule()
                {
                    Class = lre.Class,
                    Levels = ParseLogLevels(lre.Levels),
                    Targets = ParseStringList(lre.Targets),
                    Categories = ParseStringList(lre.Categories)
                });

            }//end for

            return rules;

        }//end method

        private static List<LogLevel> ParseLogLevels(string levels)
        {
            List<LogLevel> levelList = new List<LogLevel>();

            string[] list = levels.Split(',');
            for (int i = 0; i < list.Length; i++)
                levelList.Add((LogLevel)Enum.Parse(typeof(LogLevel), list[i]));

            return levelList;

        }//end method

        private static List<string> ParseStringList(string strings)
        {
            List<string> stringList = new List<string>();

            string[] list = strings.Split(',');
            for (int i = 0; i < list.Length; i++)
                stringList.Add(list[i]);

            return stringList;

        }//end method
        */

        public static Logger GetLogger()
        {
            if (Configuration == null)
                throw new LogException("The configuration must be loaded before performing any logging functions.");

            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            string className = sf.GetMethod().DeclaringType.FullName;

            //retrieve all the log rules related to this class
            List<LogRule> classRules = Configuration.Rules.Where(r => (r.Class == className || r.Class == "*")).ToList();

            return new Logger(classRules, Configuration.Targets);

        }//end method

        public static void RegisterTarget(string name, Type type)
        {
            //register the output

        }//end method

    }//end class

}//end namespace