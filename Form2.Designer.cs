namespace HCI_GAME
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.StartGame = new System.Windows.Forms.Button();
            this.RecTangleBtn = new System.Windows.Forms.Button();
            this.TriangleBtn = new System.Windows.Forms.Button();
            this.CircleBtn = new System.Windows.Forms.Button();
            this.CameraBox = new Emgu.CV.UI.ImageBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Font = new System.Drawing.Font("Mistral", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGame.Location = new System.Drawing.Point(638, 353);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(98, 35);
            this.StartGame.TabIndex = 7;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // RecTangleBtn
            // 
            this.RecTangleBtn.BackColor = System.Drawing.Color.Transparent;
            this.RecTangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.Rectangle;
            this.RecTangleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RecTangleBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RecTangleBtn.Location = new System.Drawing.Point(638, 237);
            this.RecTangleBtn.Name = "RecTangleBtn";
            this.RecTangleBtn.Size = new System.Drawing.Size(98, 82);
            this.RecTangleBtn.TabIndex = 6;
            this.RecTangleBtn.UseVisualStyleBackColor = false;
            this.RecTangleBtn.Click += new System.EventHandler(this.RectangleBtn_Click);
            // 
            // TriangleBtn
            // 
            this.TriangleBtn.BackColor = System.Drawing.Color.Transparent;
            this.TriangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.triangle;
            this.TriangleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TriangleBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TriangleBtn.Location = new System.Drawing.Point(638, 125);
            this.TriangleBtn.Name = "TriangleBtn";
            this.TriangleBtn.Size = new System.Drawing.Size(98, 82);
            this.TriangleBtn.TabIndex = 5;
            this.TriangleBtn.UseVisualStyleBackColor = false;
            this.TriangleBtn.Click += new System.EventHandler(this.TriangleBtn_Click);
            // 
            // CircleBtn
            // 
            this.CircleBtn.BackColor = System.Drawing.Color.Transparent;
            this.CircleBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CircleBtn.BackgroundImage")));
            this.CircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CircleBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CircleBtn.Location = new System.Drawing.Point(638, 12);
            this.CircleBtn.Name = "CircleBtn";
            this.CircleBtn.Size = new System.Drawing.Size(98, 82);
            this.CircleBtn.TabIndex = 4;
            this.CircleBtn.UseVisualStyleBackColor = false;
            this.CircleBtn.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // CameraBox
            // 
            this.CameraBox.BackColor = System.Drawing.Color.Transparent;
            this.CameraBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CameraBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.CameraBox.Location = new System.Drawing.Point(38, 40);
            this.CameraBox.Name = "CameraBox";
            this.CameraBox.Size = new System.Drawing.Size(523, 323);
            this.CameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraBox.TabIndex = 2;
            this.CameraBox.TabStop = false;
            this.CameraBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.CameraBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.CameraBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close_button.CausesValidation = false;
            this.close_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_button.Location = new System.Drawing.Point(576, 1);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(25, 25);
            this.close_button.TabIndex = 8;
            this.close_button.Text = "X";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(776, 400);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.RecTangleBtn);
            this.Controls.Add(this.TriangleBtn);
            this.Controls.Add(this.CircleBtn);
            this.Controls.Add(this.CameraBox);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Shape Detection";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox CameraBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CircleBtn;
        private System.Windows.Forms.Button TriangleBtn;
        private System.Windows.Forms.Button RecTangleBtn;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button close_button;
    }
}