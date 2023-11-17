using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class EditActivity : IEditActivity
    {
        public void Edit(Activity myActivity) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE Activity SET id = @id, ActivityType = @ActivityType, Distance = @Distance, DateCompleted = @DateCompleted, Pin = @Pin, Deleted = @Deleted WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", myActivity.id);
            cmd.Parameters.AddWithValue("@ActivityType", myActivity.ActivityType);
            cmd.Parameters.AddWithValue("@Distance", myActivity.Distance);
            cmd.Parameters.AddWithValue("@DateCompleted", myActivity.DateCompleted);
            cmd.Parameters.AddWithValue("@Pin", myActivity.Pin);
            cmd.Parameters.AddWithValue("@Deleted", myActivity.Deleted);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}