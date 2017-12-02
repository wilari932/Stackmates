using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StackMates
{
    class UserPage
    {
        private string User;
        private string UserPassword;
        private TableLayoutPanel RootPanel { get; set; }
        private TableLayoutPanel UserPanel { get; set; }
        private TableLayoutPanel UserPanel2 { get; set; }
        private PictureBox UserPhoto { get; set; }
        private MainForm b;
        private DatabaseHandler Database = new DatabaseHandler();
        private Enkryption EEnkryption = new Enkryption();

        public UserPage(MainForm a, string user, string password)
        {
            User = user;
            UserPassword = password;
            b = a;
            b.Controls.Clear();
            b.Size = new Size(700, 510);
            UserControl();
            InitializeComponent();

        }

        private void UserControl()
        {
            if (!Database.UserLogin(User, UserPassword))
            {
                b.Close();
            }

        }

        private void InitializeComponent()
        {

            RootPanel = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(28, 135, 202),





            };

            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

            UserPhoto = new PictureBox
            {

                Size = new System.Drawing.Size(250, 250),
                BorderStyle = BorderStyle.Fixed3D,
                SizeMode = PictureBoxSizeMode.StretchImage,

            };
            Label labelUsername = new Label
            {
                ForeColor = Color.White,
                Text = "Name: ",
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
                Font = new Font("Arial", 20, FontStyle.Regular),
            };

            Label labelAcoountSettings = new Label
            {
                ForeColor = Color.White,
                Text = "Account Settings: ",
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
                Font = new Font("Arial", 20, FontStyle.Regular),
            };
            Database.ReadUserData(User, UserPassword, labelUsername, UserPhoto);

            UserPanel = new TableLayoutPanel
            {
                RowCount = 3,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(28, 135, 202),


            };

            UserPanel.Controls.Add(UserPhoto);
            UserPanel.Controls.Add(labelUsername);
            UserPanel.Controls.Add(labelAcoountSettings);
            UserPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            UserPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            UserPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5));

            UserPanel2 = new TableLayoutPanel
            {
                RowCount = 3,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(28, 135, 202),


            };





            RootPanel.Controls.Add(UserPanel);
            RootPanel.Controls.Add(UserPanel2);
            b.Controls.Add(RootPanel);

        }

    }
}
