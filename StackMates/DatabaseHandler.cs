using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.IO;

namespace StackMates
{
    
    class DatabaseHandler
    {
        //Properties för Databas Uppkopling.
       private static MySqlConnection Connector = null;
        private ITypeDescriptorContext jpegByteArray;

        private MySqlCommand Querry { get; set; }
        MySqlDataReader Reader { get; set; }
        // END
     public DatabaseHandler()
        {
            try
            {
                GetDBConnection();



            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

        }


        private static MySqlConnection GetDBConnection()
        {
            if (Connector == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                Connector = new MySqlConnection(connectionString);
            }
            return Connector;
        }

        public bool CreateUser(string Username, string Name, string Email, string Password)
        {
            try
            {
               // (AES_ENCRYPT(@UserName, 'key12346123')
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
        public void ReadUserData(string username, string password, Label name , PictureBox userimage)
        {
           if( UserLogin( username ,password))
            {
                Conection(true);
                string s = "SELECT * FROM user WHERE UserName = '" + username + "' and (Password = '" + password + "')";

                Querry = new MySqlCommand(s, Connector);
                Querry.ExecuteNonQuery();
                MySqlDataReader dataReader = Querry.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    name.Text = dataReader["UserName"].ToString();
                    try
                    {
                        byte[] data = (byte[])dataReader["UserImage"];
                        MemoryStream ms = new MemoryStream(data);
                        userimage.Image = Image.FromStream(ms);
                    }
                    catch
                    {
                        MessageBox.Show("Du äger ingen bild för tilfället");
                    }


                }
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
