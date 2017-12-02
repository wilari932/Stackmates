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


        //Loginform Objects
        private Button LoginButton { get; set; }
        private TextBox UsernameTxtBox { get; set; }
        private TextBox PasswordTxtBox { get; set; }
        //END
        //RegisterForm Object
        private TextBox NewUserNameTxtBox { get; set; }
        private TextBox NewNameTxtBox { get; set; }
        private TextBox NewEmailTxtBox { get; set; }
        private TextBox NewPasswordTxtBox { get; set; }
        private TextBox NewConfirmPasswordTxtBox { get; set; }
        private Button RegisterButton { get; set; }
        //END
        //Other Classes Objects
        private DatabaseHandler Mysqldata = new DatabaseHandler();
        public TableLayoutPanel RootPanel { get; set; }
        private UserPage UserPage;
        private MainForm b;
        private string User;
        private string Password;
        //END
        public LoginForm(MainForm a)
        {
            b = a;
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
                RowCount = 7,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(28, 135, 202)



            };

            TableLayoutPanel EmptyPanel = new TableLayoutPanel
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
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),

            };
            UsernameTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Padding = new Padding(0, 0, 0, 0)

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
            Label RegisterLabel = new Label
            {
                ForeColor = Color.White,
                Text = "Click here to create a new account!",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 13, FontStyle.Regular),
                Cursor = Cursors.Hand,
            };
            RegisterLabel.Click += RegisterLabel_Click;
            RegisterLabel.MouseEnter += RegisterLabel_MouseEnter;
            RegisterLabel.MouseLeave += RegisterLabel_MouseLeave;

            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            RootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35));

            RootPanel.Controls.Add(EmptyPanel);
            RootPanel.Controls.Add(labelUsername);
            RootPanel.Controls.Add(UsernameTxtBox);
            RootPanel.Controls.Add(labelPassword);
            RootPanel.Controls.Add(PasswordTxtBox);
            RootPanel.Controls.Add(LoginButton);
            RootPanel.Controls.Add(RegisterLabel);


        }

        private void RegisterLabel_MouseLeave(object sender, EventArgs e)
        {
            Label a = (Label)sender;
            a.ForeColor = Color.White;
        }

        private void RegisterLabel_MouseEnter(object sender, EventArgs e)
        {
            Label a = (Label)sender;

            a.ForeColor = Color.Red;
        }

        private void CreateRegisterForm()
        {
            b.Controls.Clear();
            RootPanel.Controls.Clear();

            RootPanel = new TableLayoutPanel
            {
                RowCount = 12,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(28, 135, 202)



            };

            TableLayoutPanel EmptyPanel = new TableLayoutPanel
            {

                Dock = DockStyle.Fill,



            };


            RegisterButton = new Button
            {
                Text = "Register",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGreen,
                Size = new System.Drawing.Size(300, 50),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top)



            };
            RegisterButton.Click += RegisterButton_Click;
            Label labelUsername = new Label
            {
                ForeColor = Color.White,
                Text = "Username",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),

            };
            NewUserNameTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Padding = new Padding(0, 0, 0, 0)

            };
            Label labelName = new Label
            {
                ForeColor = Color.White,
                Text = "Name",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
            };
            NewNameTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top),



            };
            Label labelEmail = new Label
            {
                ForeColor = Color.White,
                Text = "Email",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
            };
            NewEmailTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top),



            };
            Label labelPassword = new Label
            {
                ForeColor = Color.White,
                Text = "Password",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
            };
            NewPasswordTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top),



            };
            Label labelPasswordConfirm = new Label
            {
                ForeColor = Color.White,
                Text = "Comfirm Password",
                Size = new System.Drawing.Size(300, 31),
                Anchor = (AnchorStyles.Top),
                Font = new Font("Arial", 20, FontStyle.Regular),
            };
            NewConfirmPasswordTxtBox = new TextBox
            {
                Size = new System.Drawing.Size(300, 80),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Anchor = (AnchorStyles.Top),



            };


            RootPanel.Controls.Add(EmptyPanel);
            RootPanel.Controls.Add(labelUsername);
            RootPanel.Controls.Add(NewUserNameTxtBox);
            RootPanel.Controls.Add(labelName);
            RootPanel.Controls.Add(NewNameTxtBox);
            RootPanel.Controls.Add(labelEmail);
            RootPanel.Controls.Add(NewEmailTxtBox);
            RootPanel.Controls.Add(labelPassword);
            RootPanel.Controls.Add(NewPasswordTxtBox);
            RootPanel.Controls.Add(labelPasswordConfirm);
            RootPanel.Controls.Add(NewConfirmPasswordTxtBox);
            RootPanel.Controls.Add(RegisterButton);
            b.Controls.Add(RootPanel);
            b.Height = 700;

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {


            if (Mysqldata.CreateUser(NewUserNameTxtBox.Text, NewNameTxtBox.Text, NewEmailTxtBox.Text, NewPasswordTxtBox.Text))
            {
                MessageBox.Show("användaren är Skapad");
                b.Controls.Clear();
                RootPanel.Controls.Clear();
                CreateLoginForm();
                b.Controls.Add(RootPanel);
                b.Size = new System.Drawing.Size(510, 510);
            }
            else
            {
                MessageBox.Show("Gick Inte att skapa");
            }

        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            CreateRegisterForm();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Mysqldata.UserLogin(UsernameTxtBox.Text, PasswordTxtBox.Text))
            {
                User = UsernameTxtBox.Text;
                Password = PasswordTxtBox.Text;
                UserPage = new UserPage(b, User, Password);


            }
            else
            {
                MessageBox.Show("Användaren Finns ej");

            }
        }
    }
}
