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
                BackColor = Color.FromArgb(226, 226, 226),

                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset



            };

            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 305));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            UserPhoto = new PictureBox
            {

                Size = new System.Drawing.Size(300,300),
               
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand


            };
            UserPhoto.MouseEnter += UserPhoto_MouseEnter;
            UserPhoto.MouseLeave += UserPhoto_MouseLeave;
            UserPhoto.Click += UserPhoto_Click;
           
         
            Label labelUsername = new Label
            {
                ForeColor = Color.Black,
                Text = "Name: ",
                Dock = DockStyle.Top,          
                Font = new Font("Arial", 20, FontStyle.Regular),
                Height = 40,
                Width = 20
            };
            Database.ReadUserData(User, UserPassword, labelUsername, UserPhoto);

            Label labelAcoountSettings = new Label
            {
                ForeColor = Color.Black,
                Text = "Account Settings: ",
                Dock = DockStyle.Top,
                Font = new Font("Arial", 20, FontStyle.Regular),
                Height = 40,
                Width = 20

            };


            UserPanel = new TableLayoutPanel
            {
                RowCount = 3,
                Dock = DockStyle.Fill,
               


            };
            UserPanel.CellPaint += UserPanel_CellPaint;
            UserPanel.Controls.Add(UserPhoto);
            UserPanel.Controls.Add(labelUsername);
            UserPanel.Controls.Add(labelAcoountSettings);
            UserPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            UserPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize,0));
            UserPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize,0));



            UserPanel2 = new TableLayoutPanel
            {
                RowCount = 3,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(34, 34, 34),


            };
            TableLayoutPanel SerchPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                ColumnCount = 2,
                 BackColor = Color.FromArgb(221, 255, 221),
            };
            Label SerchLabertext = new Label
            {
              Text =  "Search Person", 
                Width =180,
                Anchor = AnchorStyles.Right,
                Font = new Font("Arial", 15, FontStyle.Regular)
            };
            TextBox SearchTextbox = new TextBox {

                Anchor = AnchorStyles.Left,
                Width = 500,
                Font = new Font("Arial", 20, FontStyle.Regular)

            };
            SerchPanel.Controls.Add(SerchLabertext);
            SerchPanel.Controls.Add(SearchTextbox);

            SerchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,20));
            SerchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));




            UserPanel2.Controls.Add(SerchPanel);


            RootPanel.Controls.Add(UserPanel);
            RootPanel.Controls.Add(UserPanel2);
            b.Controls.Add(RootPanel);

        }

        private void UserPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 && e.Column == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.CellBounds);
            }
        }

        private void CreateSaerchEngine()
        {

        }



        private void UserPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg|Png(*Png)|*.Png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);

                UserPhoto.Image = img.GetThumbnailImage(300, 300, null, new IntPtr());
                open.RestoreDirectory = true;
            }
        }

        private void UserPhoto_MouseLeave(object sender, EventArgs e)
        {
            PictureBox b = (PictureBox)sender;
            b.Controls.Clear();
        }

        private void UserPhoto_MouseEnter(object sender, EventArgs e)
        {
            Button AddNewPicture;




        UserPhoto.Controls.Add(AddNewPicture = new Button{ Text = "Add New Image", Dock = DockStyle.Bottom, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(200, Color.WhiteSmoke), Font = new Font("Arial", 20, FontStyle.Regular), Height = 50 , Enabled = false });
        }

        
    }
}
