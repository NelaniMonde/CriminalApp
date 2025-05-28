using CriminalProject.Data;
using CriminalProject.Models;

namespace CriminalProject.UserActivityClasses
{
    public class UserActivityLogger : IUserActivityLogger
    {
        private readonly CriminalAppContext _appContext;

        public UserActivityLogger(CriminalAppContext appContext)
        {
            _appContext = appContext;
        }
        public void LogUserActivity(string userId, string action)
        {
            var log = new UserActivityLog
            {
                UserId = userId,
                Action = action,
                Timestamp = DateTime.UtcNow
            }; 

            _appContext.UserActivityLogs.Add(log);
            _appContext.SaveChanges();


        }
    }
}
