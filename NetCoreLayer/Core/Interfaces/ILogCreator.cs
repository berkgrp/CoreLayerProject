using Core.Models;

namespace Core.Interfaces
{
    public interface ILogCreator
    {
        Log Logging(string logDescription, string logType, string tableID, string tableName, int createdUserId, string createdUserType);
        Log LoggingAsNotification(string logDescription, string logType, string tableID, string tableName, int createdUserId, string createdUserType,
            bool isThatLog, bool isThatNotification);
    }
}
