using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace StackMates
{
    
    class DatabaseHandler
    {
        //Properties för Databas Uppkopling.
       private static string server = "sql146.main-hosting.eu";
       private static string database = "u930023931_mydb ";
       private static string uid = "u930023931_wili";
       private static string password = "TEKnick2017?";
       private  string connectionString = @"Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";" + "protocol = tcp; pooling = false;" + "port = 3306;";
       private MySqlConnection Connector { get; set; }
       private MySqlCommand Querry { get; set; }
        // END
     public DatabaseHandler()
        {
            try
            {

                Connector = new MySqlConnection(connectionString);
               
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

         public bool UserLogin(string Username, string Password)
        {
            Conection(true);
            Querry = new MySqlCommand("SELECT UserName,Password FROM user where UserName=@UserName and Password=@Password", Connector);

                Querry.Parameters.AddWithValue("@UserName", Username);

                Querry.Parameters.AddWithValue("@Password", Password);

                MySqlDataReader read = Querry.ExecuteReader();
           
            if (read.Read())
                {
                Conection(false);
                return true;
                   

            }
                else
                {
                Conection(false);
                return false;
               
            }
           
        }

        private void Conection(bool Isopen)
        {
            if (Isopen)
            {
                Connector.Open();
            }
            else if(Isopen== false)
            {
                Connector.Close();
            }

        }



    }
}
