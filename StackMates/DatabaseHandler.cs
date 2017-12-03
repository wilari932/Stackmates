using System;
using MySql.Data.MySqlClient;

using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace StackMates
{

    class DatabaseHandler
    {
        //Properties för Databas Uppkopling.
        private static MySqlConnection Connector = null;
        private MySqlCommand Querry { get; set; }
       private MySqlDataReader Reader { get; set; }
        private Enkryption EEnkryption = new Enkryption();
        // END
        public DatabaseHandler()
        {
            

            try
            {
                GetDBConnection(EEnkryption.DecryptFromFile(@"Resources\ReadOnly.txt"));

                

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

        }


        private static MySqlConnection GetDBConnection(string db)
        {
            if (Connector == null)
            {
                
                Connector = new MySqlConnection(db);
                
            }
            return Connector;
        }

        public bool CreateUser(string Username, string Name, string Email, string Password)
        {
            try
            {
                Username = EEnkryption.Encrypt(Username);
                Password = EEnkryption.Encrypt(Password);
                Name = EEnkryption.Encrypt(Name);
                Email = EEnkryption.Encrypt(Email);


                Conection(true);
                Querry = new MySqlCommand("INSERT INTO user (UserName,Name,Email,Password) VALUES (@UserName,@Name,@Email,@Password)", Connector);

                MySqlParameter[] param = new MySqlParameter[4] ;

                for(int i= 0; i< param.Length; i++)
                {
                    param[i] = new MySqlParameter();
                }
                param[0] = new MySqlParameter();
                param[0].ParameterName = "@UserName";
                param[0].Value = Username;
                param[1].ParameterName = "@Name";
                param[1].Value = Name;
                param[2].ParameterName = "@Email";
                param[2].Value = Email;
                param[3].ParameterName = "@Password";
                param[3].Value = Password;

                foreach (MySqlParameter s in param)
                {
                 
                    Querry.Parameters.Add(s);
                }
              
                Querry.ExecuteReader();
                System.Windows.Forms.MessageBox.Show("Det gick");
                Conection(false);
                return true;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Gick EJ" + e.ToString());
                Conection(false);
                return false;

            }

        }

        public bool UserLogin(string Username, string Password)
        {
            try
            {

                Username = EEnkryption.Encrypt(Username);
                Password = EEnkryption.Encrypt(Password);
                Conection(true);
                Querry = new MySqlCommand("SELECT UserName,Password FROM user where UserName=@UserName and Password=@Password", Connector);

                MySqlParameter[] param = new MySqlParameter[2];

                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new MySqlParameter();
                }


                param[0].ParameterName = "@UserName";
                param[0].Value = Username;
                param[1].ParameterName = "@Password";
                param[1].Value = Password;
                foreach (MySqlParameter s in param)
                {

                    Querry.Parameters.Add(s);
                }





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
            catch(Exception e)
            {
                Conection(false);
                MessageBox.Show(e.ToString());
                return false;
            }
            
          


        }

        public bool UpLoaddateImage(string username, string password, byte[]file)
        {
            if (UserLogin(username, password))
            {
              
                username = EEnkryption.Encrypt(username);
                password = EEnkryption.Encrypt(password);
                Conection(true);
                string s = "SELECT * FROM user WHERE UserName = '" + username + "' and (Password = '" + password + "')";
                Querry = new MySqlCommand(s, Connector);
                Reader = Querry.ExecuteReader();


                if (Reader.Read())
                {

                    Conection(false);
                    Conection(true);
                    string s2 = "UPDATE user SET UserImage=@UserImage WHERE UserName=@UserName ";


                    Querry = new MySqlCommand(s2, Connector);

                    Querry.Parameters.Add(new MySqlParameter("@UserImage", file));
                    Querry.Parameters.Add(new MySqlParameter("@UserName", username));

                    Querry.ExecuteReader();
                    Conection(false);




                }


            }
            
            Conection(false);
            return false;


        }

        public void ReadUserData(string username, string password, Label name, PictureBox userimage)
        {
         

            if (UserLogin(username,password))
            {
                username = EEnkryption.Encrypt(username);
                password = EEnkryption.Encrypt(password);
                Conection(true);
                string s = "SELECT * FROM user WHERE UserName = '" + username + "' and (Password = '" + password + "')";

                Querry = new MySqlCommand(s, Connector);
                Querry.ExecuteNonQuery();
                 Reader = Querry.ExecuteReader();

               if(Reader.HasRows)
                    Reader.Read();
                    name.Text = Reader["UserName"].ToString();
                     name.Text = EEnkryption.Decrypt(name.Text);
                    try
                    {
                        byte[] data = (byte[])Reader["UserImage"];
                        MemoryStream ms = new MemoryStream(data);
                        userimage.Image = Image.FromStream(ms);
                    }
                    catch
                    {
                        MessageBox.Show("Du äger ingen bild för tilfället");
                        Conection(false);
                }

                Conection(false);
                
            }
            Conection(false);

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
