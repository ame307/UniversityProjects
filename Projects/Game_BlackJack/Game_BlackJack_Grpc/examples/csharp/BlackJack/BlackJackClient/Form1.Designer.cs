using System.Windows.Forms;

namespace BlackJackClient
{
    partial class Form1
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
            this.pbDealer1 = new System.Windows.Forms.PictureBox();
            this.pbDealer2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer1 = new System.Windows.Forms.PictureBox();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnSurrender = new System.Windows.Forms.Button();
            this.btnDouble = new System.Windows.Forms.Button();
            this.lblDeal = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.udDeal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDealerAmount = new System.Windows.Forms.Label();
            this.lblPlayerAmount = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServerMsg = new System.Windows.Forms.Label();
            this.tbLoginUsername = new System.Windows.Forms.TextBox();
            this.tbLoginPassword = new System.Windows.Forms.TextBox();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.listBoxNames = new System.Windows.Forms.ListBox();
            this.listBoxMoneys = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDeal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 177);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbDealer1
            // 
            this.pbDealer1.Location = new System.Drawing.Point(258, 12);
            this.pbDealer1.Name = "pbDealer1";
            this.pbDealer1.Size = new System.Drawing.Size(138, 211);
            this.pbDealer1.TabIndex = 1;
            this.pbDealer1.TabStop = false;
            // 
            // pbDealer2
            // 
            this.pbDealer2.Location = new System.Drawing.Point(298, 12);
            this.pbDealer2.Name = "pbDealer2";
            this.pbDealer2.Size = new System.Drawing.Size(138, 211);
            this.pbDealer2.TabIndex = 2;
            this.pbDealer2.TabStop = false;
            // 
            // pbPlayer2
            // 
            this.pbPlayer2.Location = new System.Drawing.Point(298, 482);
            this.pbPlayer2.Name = "pbPlayer2";
            this.pbPlayer2.Size = new System.Drawing.Size(138, 211);
            this.pbPlayer2.TabIndex = 4;
            this.pbPlayer2.TabStop = false;
            // 
            // pbPlayer1
            // 
            this.pbPlayer1.Location = new System.Drawing.Point(258, 482);
            this.pbPlayer1.Name = "pbPlayer1";
            this.pbPlayer1.Size = new System.Drawing.Size(138, 211);
            this.pbPlayer1.TabIndex = 3;
            this.pbPlayer1.TabStop = false;
            // 
            // btnDeal
            // 
            this.btnDeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeal.Location = new System.Drawing.Point(118, 608);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(75, 23);
            this.btnDeal.TabIndex = 13;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btDeal_Click);
            // 
            // btnHit
            // 
            this.btnHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHit.Location = new System.Drawing.Point(21, 550);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(75, 23);
            this.btnHit.TabIndex = 8;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.btHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStand.Location = new System.Drawing.Point(21, 579);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(75, 23);
            this.btnStand.TabIndex = 9;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btStand_Click);
            // 
            // btnSurrender
            // 
            this.btnSurrender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSurrender.Location = new System.Drawing.Point(21, 637);
            this.btnSurrender.Name = "btnSurrender";
            this.btnSurrender.Size = new System.Drawing.Size(75, 23);
            this.btnSurrender.TabIndex = 11;
            this.btnSurrender.Text = "Surrender";
            this.btnSurrender.UseVisualStyleBackColor = true;
            this.btnSurrender.Click += new System.EventHandler(this.btSurrender_Click);
            // 
            // btnDouble
            // 
            this.btnDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDouble.Location = new System.Drawing.Point(21, 608);
            this.btnDouble.Name = "btnDouble";
            this.btnDouble.Size = new System.Drawing.Size(75, 23);
            this.btnDouble.TabIndex = 10;
            this.btnDouble.Text = "Double";
            this.btnDouble.UseVisualStyleBackColor = true;
            this.btnDouble.Click += new System.EventHandler(this.btDouble_Click);
            // 
            // lblDeal
            // 
            this.lblDeal.AutoSize = true;
            this.lblDeal.BackColor = System.Drawing.Color.Transparent;
            this.lblDeal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDeal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDeal.Location = new System.Drawing.Point(114, 553);
            this.lblDeal.Name = "lblDeal";
            this.lblDeal.Size = new System.Drawing.Size(63, 20);
            this.lblDeal.TabIndex = 12;
            this.lblDeal.Text = "Összeg";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblResult.Location = new System.Drawing.Point(25, 206);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(192, 39);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Sok sikert!";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAmount.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblAmount.Location = new System.Drawing.Point(68, 481);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 39);
            this.lblAmount.TabIndex = 15;
            // 
            // udDeal
            // 
            this.udDeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.udDeal.Location = new System.Drawing.Point(118, 579);
            this.udDeal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udDeal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDeal.Name = "udDeal";
            this.udDeal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.udDeal.Size = new System.Drawing.Size(79, 22);
            this.udDeal.TabIndex = 12;
            this.udDeal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udDeal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(42, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 39);
            this.label1.TabIndex = 17;
            this.label1.Text = "Pénzed:";
            // 
            // lblDealerAmount
            // 
            this.lblDealerAmount.AutoSize = true;
            this.lblDealerAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDealerAmount.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDealerAmount.Location = new System.Drawing.Point(229, 93);
            this.lblDealerAmount.Name = "lblDealerAmount";
            this.lblDealerAmount.Size = new System.Drawing.Size(0, 16);
            this.lblDealerAmount.TabIndex = 18;
            this.lblDealerAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerAmount
            // 
            this.lblPlayerAmount.AutoSize = true;
            this.lblPlayerAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPlayerAmount.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPlayerAmount.Location = new System.Drawing.Point(229, 579);
            this.lblPlayerAmount.Name = "lblPlayerAmount";
            this.lblPlayerAmount.Size = new System.Drawing.Size(0, 16);
            this.lblPlayerAmount.TabIndex = 19;
            this.lblPlayerAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(660, 355);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // lblServerMsg
            // 
            this.lblServerMsg.AutoSize = true;
            this.lblServerMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblServerMsg.ForeColor = System.Drawing.Color.White;
            this.lblServerMsg.Location = new System.Drawing.Point(550, 381);
            this.lblServerMsg.Name = "lblServerMsg";
            this.lblServerMsg.Size = new System.Drawing.Size(0, 16);
            this.lblServerMsg.TabIndex = 22;
            // 
            // tbLoginUsername
            // 
            this.tbLoginUsername.Location = new System.Drawing.Point(553, 326);
            this.tbLoginUsername.MaxLength = 20;
            this.tbLoginUsername.Name = "tbLoginUsername";
            this.tbLoginUsername.Size = new System.Drawing.Size(100, 20);
            this.tbLoginUsername.TabIndex = 1;
            // 
            // tbLoginPassword
            // 
            this.tbLoginPassword.Location = new System.Drawing.Point(660, 326);
            this.tbLoginPassword.MaxLength = 20;
            this.tbLoginPassword.Name = "tbLoginPassword";
            this.tbLoginPassword.PasswordChar = '*';
            this.tbLoginPassword.Size = new System.Drawing.Size(100, 20);
            this.tbLoginPassword.TabIndex = 2;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(553, 355);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(100, 23);
            this.btnRegistration.TabIndex = 3;
            this.btnRegistration.Text = "Registration";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(685, 697);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // listBoxNames
            // 
            this.listBoxNames.BackColor = System.Drawing.Color.Black;
            this.listBoxNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxNames.ForeColor = System.Drawing.Color.White;
            this.listBoxNames.FormattingEnabled = true;
            this.listBoxNames.ItemHeight = 16;
            this.listBoxNames.Location = new System.Drawing.Point(258, 276);
            this.listBoxNames.Name = "listBoxNames";
            this.listBoxNames.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxNames.Size = new System.Drawing.Size(168, 132);
            this.listBoxNames.TabIndex = 20;
            // 
            // listBoxMoneys
            // 
            this.listBoxMoneys.BackColor = System.Drawing.Color.Black;
            this.listBoxMoneys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxMoneys.ForeColor = System.Drawing.Color.White;
            this.listBoxMoneys.FormattingEnabled = true;
            this.listBoxMoneys.ItemHeight = 16;
            this.listBoxMoneys.Location = new System.Drawing.Point(424, 276);
            this.listBoxMoneys.Name = "listBoxMoneys";
            this.listBoxMoneys.Size = new System.Drawing.Size(95, 132);
            this.listBoxMoneys.TabIndex = 21;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(61, 258);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(132, 150);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblPlayerName.Location = new System.Drawing.Point(546, 326);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(0, 37);
            this.lblPlayerName.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::BlackJackClient.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(781, 732);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listBoxMoneys);
            this.Controls.Add(this.listBoxNames);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.tbLoginPassword);
            this.Controls.Add(this.tbLoginUsername);
            this.Controls.Add(this.lblServerMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPlayerAmount);
            this.Controls.Add(this.lblDealerAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udDeal);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblDeal);
            this.Controls.Add(this.btnDouble);
            this.Controls.Add(this.btnSurrender);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.pbPlayer2);
            this.Controls.Add(this.pbPlayer1);
            this.Controls.Add(this.pbDealer2);
            this.Controls.Add(this.pbDealer1);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(797, 771);
            this.MinimumSize = new System.Drawing.Size(797, 771);
            this.Name = "Form1";
            this.Text = "BlackJack";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDeal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbDealer1;
        private System.Windows.Forms.PictureBox pbDealer2;
        private System.Windows.Forms.PictureBox pbPlayer2;
        private System.Windows.Forms.PictureBox pbPlayer1;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnSurrender;
        private System.Windows.Forms.Button btnDouble;
        private System.Windows.Forms.Label lblDeal;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown udDeal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDealerAmount;
        private System.Windows.Forms.Label lblPlayerAmount;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServerMsg;
        private System.Windows.Forms.TextBox tbLoginUsername;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox listBoxNames;
        private System.Windows.Forms.ListBox listBoxMoneys;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Label lblPlayerName;
    }
}

