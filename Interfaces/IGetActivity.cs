using api.Models;

namespace api.Interfaces
{
    public interface IGetActivity
    {
        public List<Activity> GetAllActivities();
    }
}