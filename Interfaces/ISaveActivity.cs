using api.Models;

namespace api.Interfaces
{
    public interface ISaveActivity
    {
        public void CreateActivity(Activity myActivity);
        public void SaveActivity(Activity myActivity);
        
    }
}