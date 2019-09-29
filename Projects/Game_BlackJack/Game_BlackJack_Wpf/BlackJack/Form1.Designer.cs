using System.Drawing;

namespace BlackJack
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
            this.btDeal = new System.Windows.Forms.Button();
            this.btHit = new System.Windows.Forms.Button();
            this.btStand = new System.Windows.Forms.Button();
            this.btSurrender = new System.Windows.Forms.Button();
            this.btDouble = new System.Windows.Forms.Button();
            this.lblDeal = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.udDeal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDealerAmount = new System.Windows.Forms.Label();
            this.lblPlayerAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDeal)).BeginInit();
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
            // btDeal
            // 
            this.btDeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btDeal.Location = new System.Drawing.Point(118, 608);
            this.btDeal.Name = "btDeal";
            this.btDeal.Size = new System.Drawing.Size(75, 23);
            this.btDeal.TabIndex = 5;
            this.btDeal.Text = "Deal";
            this.btDeal.UseVisualStyleBackColor = true;
            this.btDeal.Click += new System.EventHandler(this.btDeal_Click);
            // 
            // btHit
            // 
            this.btHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btHit.Location = new System.Drawing.Point(21, 550);
            this.btHit.Name = "btHit";
            this.btHit.Size = new System.Drawing.Size(75, 23);
            this.btHit.TabIndex = 6;
            this.btHit.Text = "Hit";
            this.btHit.UseVisualStyleBackColor = true;
            this.btHit.Click += new System.EventHandler(this.btHit_Click);
            // 
            // btStand
            // 
            this.btStand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btStand.Location = new System.Drawing.Point(21, 608);
            this.btStand.Name = "btStand";
            this.btStand.Size = new System.Drawing.Size(75, 23);
            this.btStand.TabIndex = 7;
            this.btStand.Text = "Stand";
            this.btStand.UseVisualStyleBackColor = true;
            this.btStand.Click += new System.EventHandler(this.btStand_Click);
            // 
            // btSurrender
            // 
            this.btSurrender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btSurrender.Location = new System.Drawing.Point(21, 579);
            this.btSurrender.Name = "btSurrender";
            this.btSurrender.Size = new System.Drawing.Size(75, 23);
            this.btSurrender.TabIndex = 8;
            this.btSurrender.Text = "Surrender";
            this.btSurrender.UseVisualStyleBackColor = true;
            this.btSurrender.Click += new System.EventHandler(this.btSurrender_Click);
            // 
            // btDouble
            // 
            this.btDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btDouble.Location = new System.Drawing.Point(21, 637);
            this.btDouble.Name = "btDouble";
            this.btDouble.Size = new System.Drawing.Size(75, 23);
            this.btDouble.TabIndex = 10;
            this.btDouble.Text = "Double";
            this.btDouble.UseVisualStyleBackColor = true;
            this.btDouble.Click += new System.EventHandler(this.btDouble_Click);
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
            this.lblAmount.Size = new System.Drawing.Size(97, 39);
            this.lblAmount.TabIndex = 15;
            this.lblAmount.Text = "1000";
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
            this.udDeal.TabIndex = 16;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::BlackJack.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(817, 729);
            this.Controls.Add(this.lblPlayerAmount);
            this.Controls.Add(this.lblDealerAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udDeal);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblDeal);
            this.Controls.Add(this.btDouble);
            this.Controls.Add(this.btSurrender);
            this.Controls.Add(this.btStand);
            this.Controls.Add(this.btHit);
            this.Controls.Add(this.btDeal);
            this.Controls.Add(this.pbPlayer2);
            this.Controls.Add(this.pbPlayer1);
            this.Controls.Add(this.pbDealer2);
            this.Controls.Add(this.pbDealer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDealer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDeal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbDealer1;
        private System.Windows.Forms.PictureBox pbDealer2;
        private System.Windows.Forms.PictureBox pbPlayer2;
        private System.Windows.Forms.PictureBox pbPlayer1;
        private System.Windows.Forms.Button btDeal;
        private System.Windows.Forms.Button btHit;
        private System.Windows.Forms.Button btStand;
        private System.Windows.Forms.Button btSurrender;
        private System.Windows.Forms.Button btDouble;
        private System.Windows.Forms.Label lblDeal;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown udDeal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDealerAmount;
        private System.Windows.Forms.Label lblPlayerAmount;
    }
}

