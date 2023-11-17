using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class SaveActivity : ISaveActivity
    {
        public static void CreateActivityTable() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE activity(id TEXT, ActivityType TEXT, Distance TEXT, DateCompleted TEXT, Pin BOOLEAN DEFAULT false, Deleted BOOLEAN DEFAULT false)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void CreateActivity(Activity myActivity)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "INSERT INTO activity (id, ActivityType, Distance, DateCompleted, Pin, Deleted) VALUES (@id, @ActivityType, @Distance, @DateCompleted, @Pin, @Deleted);";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", myActivity.ExerciseId);
            cmd.Parameters.AddWithValue("@ActivityType", myActivity.ActivityType);
            cmd.Parameters.AddWithValue("@Distance", myActivity.Distance);
            cmd.Parameters.AddWithValue("@DateCompleted", myActivity.DateCompleted);
            cmd.Parameters.AddWithValue("@Pin", myActivity.Pin);
            cmd.Parameters.AddWithValue("@Deleted", myActivity.Deleted);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();

            //do i neeed to close the connections? and do we need the prepare statement?
        }

        void ISaveActivity.SaveActivity(Activity myActivity)
        {
            throw new System.NotImplementedException();
        }
    }
}