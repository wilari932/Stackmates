namespace Stackmates._1._2
{
    partial class LogginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Loggin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_SingIn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TxtBox_Password = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtBox_Username = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stackmates._1._2.Properties.Resources.x1_close;
            this.pictureBox1.Location = new System.Drawing.Point(448, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
           
            // 
            // Button_Loggin
            // 
            this.Button_Loggin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Button_Loggin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Loggin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Loggin.ForeColor = System.Drawing.Color.Black;
            this.Button_Loggin.Location = new System.Drawing.Point(267, 315);
            this.Button_Loggin.Name = "Button_Loggin";
            this.Button_Loggin.Size = new System.Drawing.Size(167, 65);
            this.Button_Loggin.TabIndex = 10;
            this.Button_Loggin.Text = "Logg in";
            this.Button_Loggin.UseVisualStyleBackColor = false;
            this.Button_Loggin.Click += new System.EventHandler(this.Button_Loggin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 69);
            this.label1.TabIndex = 11;
            this.label1.Text = "StackMates";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(135, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 44);
            this.label2.TabIndex = 12;
            this.label2.Text = "Welcome";
            // 
            // Button_SingIn
            // 
            this.Button_SingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Button_SingIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_SingIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SingIn.ForeColor = System.Drawing.Color.Black;
            this.Button_SingIn.Location = new System.Drawing.Point(54, 315);
            this.Button_SingIn.Name = "Button_SingIn";
            this.Button_SingIn.Size = new System.Drawing.Size(167, 65);
            this.Button_SingIn.TabIndex = 13;
            this.Button_SingIn.Text = "Sing In";
            this.Button_SingIn.UseVisualStyleBackColor = false;
            this.Button_SingIn.Click += new System.EventHandler(this.Button_SingIn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.TxtBox_Password);
            this.panel5.Location = new System.Drawing.Point(54, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(389, 59);
            this.panel5.TabIndex = 15;
            // 
            // TxtBox_Password
            // 
            this.TxtBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtBox_Password.Location = new System.Drawing.Point(3, 12);
            this.TxtBox_Password.Name = "TxtBox_Password";
            this.TxtBox_Password.Size = new System.Drawing.Size(383, 34);
            this.TxtBox_Password.TabIndex = 0;
            this.TxtBox_Password.Text = "Password";
            this.TxtBox_Password.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.TxtBox_Username);
            this.panel1.Location = new System.Drawing.Point(54, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 59);
            this.panel1.TabIndex = 14;
            // 
            // TxtBox_Username
            // 
            this.TxtBox_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBox_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtBox_Username.Location = new System.Drawing.Point(6, 13);
            this.TxtBox_Username.Name = "TxtBox_Username";
            this.TxtBox_Username.Size = new System.Drawing.Size(380, 34);
            this.TxtBox_Username.TabIndex = 0;
            this.TxtBox_Username.Text = "Username";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(496, 442);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Button_SingIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Loggin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Button_Loggin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_SingIn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TxtBox_Password;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtBox_Username;
    }
}

