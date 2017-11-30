using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace StackMates
{
    class LoginForm
    {
        private Button LoginButton { get; set; }
        private TextBox UsernameTxtBox { get; set; }
        private TextBox PasswordTxtBox { get; set; }
        private DatabaseHandler Mysqldata = new DatabaseHandler();
        public TableLayoutPanel RootPanel { get; set; }
      public  LoginForm()
        {
            InitializeComponent();

        }
        private void InitializeComponent()
        {
            CreateLoginForm();


        }
        private void CreateLoginForm()
        {
            RootPanel = new TableLayoutPanel
            {
                RowCount = 6,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(28, 135, 202)



            };

          TableLayoutPanel  EmptyPanel = new TableLayoutPanel
            {
                
                Dock = DockStyle.Fill,



            };


            LoginButton = new Button
            {
                Text = "Logga in",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGreen,
                Size = new System.Drawing.Size(300, 50),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top)



            };
            LoginButton.Click += LoginButton_Click;
            Label labelUsername = new Label
            {
                ForeColor = Color.White,
                Text = "Username",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top ),
                Font = new Font("Arial", 20, FontStyle.Regular),
                
            };
            UsernameTxtBox = new TextBox
            {
               Size = new System.Drawing.Size(300, 80),
                Anchor = (AnchorStyles.Top),
               Font = new Font("Arial", 20, FontStyle.Regular),
                Padding = new Padding(0,0,0,0)

            };
            Label labelPassword = new Label
            {
                ForeColor = Color.White,
                Text = "Password",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
            };
            PasswordTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top),
               PasswordChar = '*',
                

            };

            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35));
            
            RootPanel.Controls.Add(EmptyPanel);
            RootPanel.Controls.Add(labelUsername);
             RootPanel.Controls.Add(UsernameTxtBox);
            RootPanel.Controls.Add(labelPassword);
           RootPanel.Controls.Add(PasswordTxtBox);
            RootPanel.Controls.Add(LoginButton);


        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
           if( Mysqldata.UserLogin(UsernameTxtBox.Text, PasswordTxtBox.Text))
            {
                MessageBox.Show("Välkomen");
            }
            else
            {
                MessageBox.Show("Användaren Finns ej");

            }
        }
    }
}
