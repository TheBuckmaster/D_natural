namespace BensCRS
{
    partial class CourseParseForm
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
            this.cName = new System.Windows.Forms.TextBox();
            this.cTitle = new System.Windows.Forms.TextBox();
            this.cInst = new System.Windows.Forms.TextBox();
            this.cCred = new System.Windows.Forms.TextBox();
            this.cSeat = new System.Windows.Forms.TextBox();
            this.cNumTimes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cName
            // 
            this.cName.Location = new System.Drawing.Point(29, 42);
            this.cName.Name = "cName";
            this.cName.Size = new System.Drawing.Size(100, 20);
            this.cName.TabIndex = 0;
            // 
            // cTitle
            // 
            this.cTitle.Location = new System.Drawing.Point(135, 42);
            this.cTitle.Name = "cTitle";
            this.cTitle.Size = new System.Drawing.Size(100, 20);
            this.cTitle.TabIndex = 1;
            // 
            // cInst
            // 
            this.cInst.Location = new System.Drawing.Point(241, 42);
            this.cInst.Name = "cInst";
            this.cInst.Size = new System.Drawing.Size(100, 20);
            this.cInst.TabIndex = 2;
            // 
            // cCred
            // 
            this.cCred.Location = new System.Drawing.Point(29, 68);
            this.cCred.Name = "cCred";
            this.cCred.Size = new System.Drawing.Size(69, 20);
            this.cCred.TabIndex = 3;
            // 
            // cSeat
            // 
            this.cSeat.Location = new System.Drawing.Point(104, 68);
            this.cSeat.Name = "cSeat";
            this.cSeat.Size = new System.Drawing.Size(69, 20);
            this.cSeat.TabIndex = 4;
            // 
            // cNumTimes
            // 
            this.cNumTimes.Location = new System.Drawing.Point(179, 68);
            this.cNumTimes.Name = "cNumTimes";
            this.cNumTimes.Size = new System.Drawing.Size(69, 20);
            this.cNumTimes.TabIndex = 5;
            // 
            // CourseParseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 155);
            this.Controls.Add(this.cNumTimes);
            this.Controls.Add(this.cSeat);
            this.Controls.Add(this.cCred);
            this.Controls.Add(this.cInst);
            this.Controls.Add(this.cTitle);
            this.Controls.Add(this.cName);
            this.Name = "CourseParseForm";
            this.Text = "CourseParseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cName;
        private System.Windows.Forms.TextBox cTitle;
        private System.Windows.Forms.TextBox cInst;
        private System.Windows.Forms.TextBox cCred;
        private System.Windows.Forms.TextBox cSeat;
        private System.Windows.Forms.TextBox cNumTimes;
    }
}