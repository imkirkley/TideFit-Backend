using api.Models;

namespace api.Interfaces
{
    public interface IDeleteActivity
    {
        public void Delete(string id, Activity myActivity);
    }
}