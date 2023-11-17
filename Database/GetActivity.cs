using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class GetActivity : IGetActivity
    {
        public List<Activity> GetAllActivities()
        {
            List<Activity> MyActivity = new List<Activity>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM Activity";
            
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
                Activity readActivity = new Activity() {Id = rdr.GetString(0), ActivityType = rdr.GetString(1), Distance = rdr.GetString(2), DateCompleted = rdr.GetString(3), Pin = rdr.GetBoolean(4), Deleted = rdr.GetBoolean(5)};
                MyActivity.Add(readActivity);
            }

            con.Close();

            return MyActivity;

            

        }
    }
}