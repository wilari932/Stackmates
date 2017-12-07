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
        /*
        private Button LoginButton { get; set; }
        private TextBox UsernameTxtBox { get; set; }
        private TextBox PasswordTxtBox { get; set; }
        */
        //New LogInForm Objects
        private Label UserNameLoginText { get; set; }
        private Label PasswordText { get; set; }
        private Button LogInButton { get; set; }
        private RichTextBox UsernameTextBox { get; set; }
        private RichTextBox PasswordTextBox { get; set; }
        private Label NewAccountLabel { get; set; }
        private Button CloseButton { get; set; }
        //END
        //RegisterForm Object
        private TextBox NewUserNameTxtBox { get; set; }
        private TextBox NewNameTxtBox { get; set; }
        private TextBox NewEmailTxtBox { get; set; }
        private TextBox NewPasswordTxtBox { get; set; }
        private TextBox NewConfirmPasswordTxtBox { get; set; }
        private Button RegisterButton { get; set; }
        //END

        private DatabaseHandler Mysqldata = new DatabaseHandler();
        public TableLayoutPanel RootPanel { get; set; }
        private MainForm b;

        public LoginForm(MainForm a)
        {
            b = a;
            InitializeComponent();
        }
        private void InitializeComponent( )
        {
            CreateLoginForm();
        }

        private void CreateLoginForm()
        {
            RootPanel = new TableLayoutPanel
            {
                BackColor = Color.DimGray,
                Name = "MainForm",
                ClientSize = new Size(470, 470),
            };

            TableLayoutPanel  EmptyPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
            };

            LogInButton = new Button
            {
                BackColor = Color.Green,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(67, 258),
                Name = "LogInButton",
                Size = new Size(75, 40),
                TabIndex = 5,
                Text = "Log In",
                UseVisualStyleBackColor = false,
            };
            LogInButton.FlatAppearance.BorderSize = 0;
            LogInButton.Click += LoginButton_Click;

            Label UserNameLoginText = new Label
            {
                Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(62, 79),
                Name = "UserNameLoginText",
                Size = new Size(133, 30),
                Text = "Username",
            };
            UsernameTextBox = new RichTextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(67, 112),
                Name = "UsernameTextBox",
                Size = new Size(250, 30),
                TabIndex = 6,
                Text = "",
            };
            Label PasswordText = new Label
            {
                AutoSize = true,
                Font = new Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(62, 169),
                Name = "PasswordText",
                Size = new Size(122, 30),
                TabIndex = 3,
                Text = "Password",
            };
            PasswordTextBox = new RichTextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(67, 202),
                Name = "PasswordTextBox",
                Size = new Size(250, 30),
                TabIndex = 7,
                Text = "",
            };
            Label NewAccountLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(320, 444),
                Name = "NewAccountLabel",
                Size = new Size(137, 17),
                TabIndex = 8,
                Text = "New to this service?",
            };
            NewAccountLabel.Click += RegisterLabel_Click;
            NewAccountLabel.MouseEnter += RegisterLabel_MouseEnter;
            NewAccountLabel.MouseLeave += RegisterLabel_MouseLeave;
            
            RootPanel.Controls.Add(EmptyPanel);
            RootPanel.Controls.Add(UserNameLoginText);
            RootPanel.Controls.Add(UsernameTextBox);
            RootPanel.Controls.Add(PasswordText);
            RootPanel.Controls.Add(PasswordTextBox);
            RootPanel.Controls.Add(LogInButton);
            RootPanel.Controls.Add(NewAccountLabel);
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
                BackColor = Color.DimGray,
                //ClientSize = new Size(470, 470),
                Name = "MainForm",
            };
            //RootPanel.Controls.FormBorderStyle = FormBorderStyle.None,
           
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
            NewConfirmPasswordTxtBox =  new TextBox
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
           if( Mysqldata.UserLogin(UsernameTextBox.Text, PasswordTextBox.Text))
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
