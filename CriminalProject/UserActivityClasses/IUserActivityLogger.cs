namespace CriminalProject.UserActivityClasses
{
    public interface IUserActivityLogger
    {
        void LogUserActivity(string userId, string action);
    }
}
