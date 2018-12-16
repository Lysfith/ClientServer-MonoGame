using _2016_Project_2.Library.Network;
using _2016_Project_2.Server.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Server.Managers
{
    class ManagerLogger
    {
        private static ManagerLogger _instance;

        public static ManagerLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerLogger();
                }
                return _instance;
            }
        }

        private List<LogMessage> _logMessages;
        public event EventHandler<LogMessage> OnNewLogMessage;

        public ManagerLogger()
        {
            _logMessages = new List<LogMessage>();
        }

        public void AddLogMessage(LogMessage logMessage)
        {
            _logMessages.Add(logMessage);

            if (OnNewLogMessage != null)
            {
                OnNewLogMessage(this, logMessage);
            }
        }

        public void AddLogMessage(string id, string message, TypeLog type = TypeLog.INFO)
        {
            AddLogMessage(new LogMessage {
                Id = id,
                Message = message,
                Date = DateTime.Now,
                Type = type
            });
        }
    }
}
