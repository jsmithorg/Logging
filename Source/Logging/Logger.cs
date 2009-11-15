using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Tmobile.Framework.Logging.Output;
using Tmobile.Framework.Logging.Configuration;

namespace Tmobile.Framework.Logging
{
    public sealed class Logger
    {
        #region Fields / Properties

        public static string LogName { get; set; }
        public string Class { get; set; }
        //public List<LogOutput> Outputs { get; set; }

        public List<LogRule> Rules { get; internal set; }
        public List<LogTarget> Targets { get; internal set; }

        private Dictionary<LogLevel, List<LogRule>> _rules;
        private Dictionary<LogRule, List<LogOutput>> _outputs;

        #endregion

        #region Constructor

        public Logger(List<LogRule> rules, List<LogTarget> targets)
        {
            //Outputs = new List<LogOutput>();
            _rules = new Dictionary<LogLevel, List<LogRule>>();
            _outputs = new Dictionary<LogRule, List<LogOutput>>();

            Rules = rules;
            Targets = targets;

        }//end static constructor

        #endregion

        #region Retrieval Methods

        private List<LogRule> RetrieveRules(LogLevel level)
        {
            List<LogRule> rules;

            if (_rules.ContainsKey(level))
            {
                return _rules[level];
            }
            else
            {
                //Debug.WriteLine("Logger :: creating list of rules: " + Rules.Count);

                rules = Rules.Where(r => r.Levels.Contains(level)).ToList();

            }//end if

            _rules[level] = rules;

            return rules;

        }//end method

        /*private List<LogOutput> RetrieveOutputs(LogLevel level)
        {
            List<LogOutput> outputs = new List<LogOutput>();

            Debug.WriteLine("Logger :: retrieving outputs for: " + level);

            if (_outputs.ContainsKey(level))
            {
                Debug.WriteLine("Logger :: retrieving saved list of outputs");

                return _outputs[level];
            }
            else
            {
                Debug.WriteLine("Logger :: creating list of outputs: " + Rules.Count);

                List<LogRule> rules = Rules.Where(r => r.Levels.Contains(level)).ToList();

                Debug.WriteLine("Logger :: rule count for " + level + ": " + rules.Count);

                for (int i = 0; i < rules.Count; i++)
                {
                    LogRule r = rules[i];

                    Debug.WriteLine("Logger :: creating outputs for rule: " + r);

                    AddLogOutputs(r, outputs);

                }//end for

            }//end if

            _outputs[level] = outputs;
            
            return outputs;

        }//end method
        */

        private List<LogOutput> RetrieveOutputs(LogRule rule, LogLevel level)
        {
            List<LogOutput> outputs = new List<LogOutput>();

            //Debug.WriteLine("Logger :: retrieving outputs for: " + level);

            if (_outputs.ContainsKey(rule))
            {
                //Debug.WriteLine("Logger :: retrieving saved list of outputs");

                return _outputs[rule];
            }
            else
            {
                //Debug.WriteLine("Logger :: creating list of outputs");

                //Debug.WriteLine("Logger :: rule count for " + level + ": " + rules.Count);

                for (int i = 0; i < rule.Targets.Count; i++)
                {
                    LogTarget target = Targets.Where(t => t.Name == rule.Targets[i]).SingleOrDefault();
                    LogOutput output = LogOutputFactory.CreateFromLogTarget(target);

                    //Debug.WriteLine("Logger :: creating output for rule: " + rule + ", " + output);

                    outputs.Add(output);

                    //AddLogOutputs(r, outputs);

                }//end for

            }//end if

            _outputs[rule] = outputs;

            return outputs;

        }//end method

        /*private List<LogOutput> AddLogOutputs(LogRule rule, List<LogOutput> outputs)
        {
            Debug.WriteLine("Logger :: adding outputs for " + rule.Targets.Count + " targets");

            for (int i = 0; i < rule.Targets.Count; i++)
            {
                string targetName = rule.Targets[i];
                List<LogTarget> targets = Targets.Where(t => t.Name == targetName).ToList();

                for (int j = 0; j < targets.Count; j++)
                {
                    LogOutput output = LogOutputFactory.CreateFromLogTarget(targets[j]);

                    Debug.WriteLine("Logger :: log output created: " + output);
                    Debug.WriteLine("Logger :: output found? " + outputs.Where(o => o.GetType() == output.GetType()).Any());

                    //if (!outputs.Where(o => o.GetType() == output.GetType()).Any())
                        outputs.Add(output);

                }//end for

            }//end for

            Debug.WriteLine("Logger :: added log outputs: " + outputs.Count);

            return outputs;

        }//end method
        */

        #endregion

        #region Logging Methods

        public void Trace(string message)
        {
            LogLevel level = LogLevel.Trace;
            List<LogRule> rules = RetrieveRules(level);

            for (int i = 0; i < rules.Count; i++)
            {
                LogRule r = rules[i];

                List<LogOutput> outputs = RetrieveOutputs(r, level);
                for (int j = 0; j < outputs.Count; j++)
                {
                    FormattedMessage fm = new FormattedMessage(outputs[j].MessageFormat, message);
                    fm.Level = level;

                    //Debug.WriteLine("output: " + outputs[j]);
                    outputs[j].Trace(fm);

                }//end for

            }//end for

        }//end method

        public void Info(string message)
        {
            LogLevel level = LogLevel.Info;
            List<LogRule> rules = RetrieveRules(level);

            for (int i = 0; i < rules.Count; i++)
            {
                LogRule r = rules[i];

                List<LogOutput> outputs = RetrieveOutputs(r, level);

                for (int j = 0; j < outputs.Count; j++)
                {
                    FormattedMessage fm = new FormattedMessage(outputs[j].MessageFormat, message);
                    fm.Level = level;

                    //Debug.WriteLine("output: " + outputs[j]);
                    outputs[j].Info(fm);

                }//end for

            }//end for

        }//end method

        public void Warn(string message)
        {
            LogLevel level = LogLevel.Warn;
            List<LogRule> rules = RetrieveRules(level);

            for (int i = 0; i < rules.Count; i++)
            {
                LogRule r = rules[i];

                List<LogOutput> outputs = RetrieveOutputs(r, level);
                for (int j = 0; j < outputs.Count; j++)
                {
                    FormattedMessage fm = new FormattedMessage(outputs[j].MessageFormat, message);
                    fm.Level = level;

                    //Debug.WriteLine("output: " + outputs[j]);
                    outputs[j].Warn(fm);

                }//end for

            }//end for

        }//end method

        public void Debug(string message)
        {
            LogLevel level = LogLevel.Debug;
            List<LogRule> rules = RetrieveRules(level);

            for (int i = 0; i < rules.Count; i++)
            {
                LogRule r = rules[i];

                List<LogOutput> outputs = RetrieveOutputs(r, level);
                for (int j = 0; j < outputs.Count; j++)
                {
                    FormattedMessage fm = new FormattedMessage(outputs[j].MessageFormat, message);
                    fm.Level = level;

                    //Debug.WriteLine("output: " + outputs[j]);
                    outputs[j].Debug(fm);

                }//end for

            }//end for

        }//end method

        public void Error(string message)
        {
            LogLevel level = LogLevel.Error;
            List<LogRule> rules = RetrieveRules(level);

            for (int i = 0; i < rules.Count; i++)
            {
                LogRule r = rules[i];

                List<LogOutput> outputs = RetrieveOutputs(r, level);
                for (int j = 0; j < outputs.Count; j++)
                {
                    FormattedMessage fm = new FormattedMessage(outputs[j].MessageFormat, message);
                    fm.Level = level;

                    //Debug.WriteLine("output: " + outputs[j]);
                    outputs[j].Error(fm);

                }//end for

            }//end for

        }//end method

        public void Fatal(string message)
        {
            LogLevel level = LogLevel.Fatal;
            List<LogRule> rules = RetrieveRules(level);

            for (int i = 0; i < rules.Count; i++)
            {
                LogRule r = rules[i];

                List<LogOutput> outputs = RetrieveOutputs(r, level);
                for (int j = 0; j < outputs.Count; j++)
                {
                    FormattedMessage fm = new FormattedMessage(outputs[j].MessageFormat, message);
                    fm.Level = level;

                    //Debug.WriteLine("output: " + outputs[j]);
                    outputs[j].Fatal(fm);

                }//end for

            }//end for

        }//end method

        #endregion

    }//end class

}//end namespace