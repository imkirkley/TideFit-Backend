using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class SaveActivity 
    {

        public void CreateActivity(Activity myActivity)
        {
            if(myActivity == null)
            {
                Console.WriteLine("Activity is null.");
            }
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "INSERT INTO activity(id, ActivityType, Distance, DateCompleted, Pin, Deleted) VALUES (@id, @ActivityType, @Distance, @DateCompleted, @Pin, @Deleted);";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", myActivity.id);
            cmd.Parameters.AddWithValue("@ActivityType", myActivity.ActivityType);
            cmd.Parameters.AddWithValue("@Distance", myActivity.Distance);
            cmd.Parameters.AddWithValue("@DateCompleted", myActivity.DateCompleted);
            cmd.Parameters.AddWithValue("@Pin", myActivity.Pin);
            cmd.Parameters.AddWithValue("@Deleted", myActivity.Deleted);

            cmd.ExecuteNonQuery();

            con.Close();

        }
    }
}    
