﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace StackMates
{
    class UserPageGui
    {
        private string User;
        private string UserPassword;
        private TableLayoutPanel RootPanel { get; set; }
        private TableLayoutPanel UserPanel { get; set; }
        private TableLayoutPanel UserPanel2 { get; set; }
        private PictureBox UserPhoto { get; set; }
        private MainForm b;
        private Label labelAcoountSettings;
        private Label labelUsername;
        private DatabaseHandler Database = new DatabaseHandler();
        private Enkryption EEnkryption = new Enkryption();
       

        public UserPageGui(MainForm a, string user, string password)
        {
            User = user;
            UserPassword = password;
            b = a;
            b.Controls.Clear();
            b.Size = new Size(1300, 500);
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
           
         
             labelUsername = new Label
            {
                ForeColor = Color.Black,
                Text = "Name: ",
                Dock = DockStyle.Top,          
                Font = new Font("Arial", 20, FontStyle.Regular),
                Height = 40,
                Width = 20
            };
            Database.ReadUserData(User, UserPassword, labelUsername, UserPhoto);

             labelAcoountSettings = new Label
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
                RowCount = 4,
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

            TableLayoutPanel PostForm = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 1,
                Size = new Size(400,300),
                Anchor = AnchorStyles.Left| AnchorStyles.Right,
                BackColor = Color.Gray




            };

            RichTextBox PostRIchbox = new RichTextBox
            {
                ScrollBars = RichTextBoxScrollBars.Both,
                DetectUrls = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                Dock = DockStyle.Fill,
                
              EnableAutoDragDrop = true,
            };
            Button postbutton = new Button
            {
                Height = 45,
                Anchor = AnchorStyles.Right| AnchorStyles.Top| AnchorStyles.Bottom,
                Font = new Font("Arial", 12, FontStyle.Regular),
                Text = "Send",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightBlue,
                

            };
            //PostForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            //PostForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            //PostForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            PostForm.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            PostForm.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            //PostForm.Controls.Add(new TableLayoutPanel { Dock = DockStyle.Fill}, 0, 0);
            PostForm.Controls.Add(PostRIchbox, 1, 0);
            //PostForm.Controls.Add(new TableLayoutPanel { Dock = DockStyle.Fill }, 2, 0);
            //PostForm.Controls.Add(new TableLayoutPanel { Dock = DockStyle.Fill }, 0, 1);
            PostForm.Controls.Add(postbutton, 1, 1);
            //PostForm.Controls.Add(new TableLayoutPanel { Dock = DockStyle.Fill }, 2, 1);
            TableLayoutPanel rootNoticeform = new TableLayoutPanel
            {
              
                ColumnCount = 2,
                Size = new Size(400, 300),
                 Dock = DockStyle.Fill,
                BackColor = Color.Gray




            };

            TableLayoutPanel Noticeform = new TableLayoutPanel
            {

                
                Dock = DockStyle.Fill,
                BackColor = Color.Gray




            };

            TableLayoutPanel chatPanel = new TableLayoutPanel
            {

                Dock = DockStyle.Fill,
                BackColor = Color.Gray



            };




            UserPanel2.Controls.Add(SerchPanel);
            UserPanel2.Controls.Add(new TableLayoutPanel {  Dock = DockStyle.Fill });
            UserPanel2.Controls.Add(PostForm);
            UserPanel2.Controls.Add(rootNoticeform);
            UserPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            UserPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 2));
            UserPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            UserPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 73));



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
            string imgloc = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
             
               imgloc = openFileDialog1.FileName.ToString();
                UserPhoto.ImageLocation = imgloc;
            }
            if (imgloc != null)
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                Database.UpLoaddateImage(User, UserPassword, img);
            }
            //  //Ask user to select Image
            //  OpenFileDialog dlg = new OpenFileDialog();
            //  dlg.InitialDirectory = @"C:\\";
            //  dlg.Title = "Select Image File";

            //  dlg.Filter = "Image Files  (*.jpg ; *.jpeg ; *.png ; *.gif ; *.tiff ; *.nef) | *.jpg; *.jpeg; *.png; *.gif; *.tiff; *.nef";
            //   dlg.ShowDialog();

            //string  FileLocation = dlg.FileName;



            //  if (FileLocation != string.Empty && FileLocation != null)
            //  {

            //      if (File.Exists(FileLocation))
            //      {
            //          UserPhoto.Image = Image.FromFile(FileLocation);
            //          MemoryStream ms = new MemoryStream();
            //          UserPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //         byte[] a =  ms.ToArray();
            //          Database.UpLoaddateImage(User, UserPassword, a);
            //      }

            //  }

        }




























        //Image i= null;
        //int maxImageSize = 2097152;
        //Image img;
        //OpenFileDialog open = new OpenFileDialog();
        //open.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg|Png(*Png)|*.Png";
        //if (open.ShowDialog() == DialogResult.OK)
        //{
        //     img = new Bitmap(open.FileName);

        //    UserPhoto.Image = img.GetThumbnailImage(300, 300, null, new IntPtr());
        //    string FileLocation = open.FileName;

        //    if (FileLocation != string.Empty && FileLocation != null)
        //    {


        //       //Get file information and calculate the filesize
        //       FileInfo info = new FileInfo(FileLocation);
        //        long fileSize = info.Length;

        //        //reasign the filesize to calculated filesize
        //        maxImageSize = (Int32)fileSize;

        //        if (File.Exists(FileLocation))
        //        {
        //            //Retreave image from file and binary it to Object image
        //            using (FileStream stream = File.Open(FileLocation, FileMode.Open))
        //            {
        //                BinaryReader br = new BinaryReader(stream);
        //                byte[] data = br.ReadBytes(maxImageSize);
        //            i  = new Image(open.SafeFileName, data, fileSize);
        //            }
        //        }





    
     

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