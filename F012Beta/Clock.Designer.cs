namespace F012Beta
{
    partial class Clock
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
            this.pictureBoxAnalogClock = new System.Windows.Forms.PictureBox();
            this.buttonFlash = new System.Windows.Forms.Button();
            this.pictureBoxDigitalClock = new System.Windows.Forms.PictureBox();
            this.labelTest = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnalogClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDigitalClock)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAnalogClock
            // 
            this.pictureBoxAnalogClock.Location = new System.Drawing.Point(170, 10);
            this.pictureBoxAnalogClock.Name = "pictureBoxAnalogClock";
            this.pictureBoxAnalogClock.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxAnalogClock.TabIndex = 0;
            this.pictureBoxAnalogClock.TabStop = false;
            // 
            // buttonFlash
            // 
            this.buttonFlash.Location = new System.Drawing.Point(395, 320);
            this.buttonFlash.Name = "buttonFlash";
            this.buttonFlash.Size = new System.Drawing.Size(75, 23);
            this.buttonFlash.TabIndex = 2;
            this.buttonFlash.Text = "Alarm";
            this.buttonFlash.UseVisualStyleBackColor = true;
            this.buttonFlash.Click += new System.EventHandler(this.buttonFlash_Click);
            // 
            // pictureBoxDigitalClock
            // 
            this.pictureBoxDigitalClock.Location = new System.Drawing.Point(10, 139);
            this.pictureBoxDigitalClock.Name = "pictureBoxDigitalClock";
            this.pictureBoxDigitalClock.Size = new System.Drawing.Size(150, 50);
            this.pictureBoxDigitalClock.TabIndex = 3;
            this.pictureBoxDigitalClock.TabStop = false;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(58, 236);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(0, 13);
            this.labelTest.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(10, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormF012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 352);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.pictureBoxDigitalClock);
            this.Controls.Add(this.buttonFlash);
            this.Controls.Add(this.pictureBoxAnalogClock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormF012";
            this.Text = "FormF012";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnalogClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDigitalClock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAnalogClock;
        private System.Windows.Forms.Button buttonFlash;
        private System.Windows.Forms.PictureBox pictureBoxDigitalClock;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Button buttonCancel;
    }
}

