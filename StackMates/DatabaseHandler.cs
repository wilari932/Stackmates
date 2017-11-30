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
        MySqlDataReader Reader { get; set; }
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

        public bool CreateUser(string Username, string Name, string Email, string Password)
        {
            try
            {
                Conection(true);
                Querry = new MySqlCommand("INSERT INTO user (UserName,Name,Email,Password) VALUES (@UserName,@Name,@Email,@Password)", Connector);

                Querry.Parameters.AddWithValue("@UserName", Username);
                Querry.Parameters.AddWithValue("@Name", Name);
                Querry.Parameters.AddWithValue("@Email", Email);
                Querry.Parameters.AddWithValue("@Password", Password);
                Querry.ExecuteReader();
                System.Windows.Forms.MessageBox.Show("Det gick");
                Conection(false);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Gick EJ");
                Conection(false);
                return false;
               
            }

        }

        public bool UserLogin(string Username, string Password)
        {
           Conection(true);
            Querry = new MySqlCommand("SELECT UserName,Password FROM user where UserName=@UserName and Password=@Password", Connector);

                Querry.Parameters.AddWithValue("@UserName", Username);

                Querry.Parameters.AddWithValue("@Password", Password);

                Reader = Querry.ExecuteReader();
           
            if (Reader.Read())
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
            else if (Isopen == false)
            {
                Connector.Close();
            }

        }



    }
}
