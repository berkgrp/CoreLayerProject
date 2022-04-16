using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class LogCreator : ILogCreator
    {
        private Log _log;
        public LogCreator(Log log)
        {
            _log = log;
        }
        public Log Logging(string logDescription, string logType, string tableID, string tableName, int createdUserId, string createdUserType)
        {
            _log = new Log
            {
                LogDescription = logDescription,
                LogType = logType,
                TableID = tableID,
                TableName = tableName,
                CreatedUserId = createdUserId,
                CreatedUserType = createdUserType,
                CreatedDate = DateTime.Now
            };
            return _log;
        }

        public Log LoggingAsNotification(string logDescription, string logType, string tableID, string tableName, int createdUserId, string createdUserType,
            bool isThatLog, bool isThatNotification)
        {
            _log = new Log
            {
                LogDescription = logDescription,
                LogType = logType,
                TableID = tableID,
                TableName = tableName,
                CreatedUserId = createdUserId,
                CreatedUserType = createdUserType,
                CreatedDate = DateTime.Now,
                IsThatLog = isThatLog,
                IsThatNotification = isThatNotification,
            };
            return _log;
        }
    }
}
