using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class DeleteActivity : IDeleteActivity
    {
        public static void DropActivityTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS Activity";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        
        public void Delete(string id, Activity myActivity)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE Activity SET deleted = 1 WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", myActivity.ExerciseId);
            cmd.Parameters.AddWithValue("@ActivityType", myActivity.ActivityType);
            cmd.Parameters.AddWithValue("@Distance", myActivity.Distance);
            cmd.Parameters.AddWithValue("@DateCompleted", myActivity.DateCompleted);
            cmd.Parameters.AddWithValue("@Pin", myActivity.Pin);
            cmd.Parameters.AddWithValue("@Deleted", myActivity.Deleted);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}