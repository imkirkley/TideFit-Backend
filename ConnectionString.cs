namespace api
{

    public class ConnectionString
    {

        public string cs{get; set;}

        public ConnectionString(){
            string server = "y6aj3qju8efqj0w1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "vz0vqqhofbpmamwe";
            string port = "3306";
            string userName = "j8zy51dclkshjxae";
            string password = "ocznf1h4qr89zjba";

            cs = $@"server={server};user={userName};database={database};port={port};password={password};";

            
        }

    

    }
}