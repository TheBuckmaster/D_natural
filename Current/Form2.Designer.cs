namespace BensCRS
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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GPAtxtbox = new System.Windows.Forms.TextBox();
            this.CreditTxtBox = new System.Windows.Forms.TextBox();
            this.Credits = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(240, 248);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(163, 22);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.Text = "Add Selected Classes";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(409, 247);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(133, 23);
            this.ScheduleButton.TabIndex = 1;
            this.ScheduleButton.Text = "View Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(548, 247);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(142, 23);
            this.LogoutButton.TabIndex = 2;
            this.LogoutButton.Text = "Log Out";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(678, 229);
            this.dataGridView1.TabIndex = 3;
            // 
            // GPAtxtbox
            // 
            this.GPAtxtbox.Location = new System.Drawing.Point(84, 261);
            this.GPAtxtbox.Name = "GPAtxtbox";
            this.GPAtxtbox.Size = new System.Drawing.Size(58, 20);
            this.GPAtxtbox.TabIndex = 4;
            this.GPAtxtbox.Visible = false;
            // 
            // CreditTxtBox
            // 
            this.CreditTxtBox.Location = new System.Drawing.Point(12, 261);
            this.CreditTxtBox.Name = "CreditTxtBox";
            this.CreditTxtBox.Size = new System.Drawing.Size(66, 20);
            this.CreditTxtBox.TabIndex = 5;
            this.CreditTxtBox.Visible = false;
            // 
            // Credits
            // 
            this.Credits.AutoSize = true;
            this.Credits.Location = new System.Drawing.Point(22, 244);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(39, 13);
            this.Credits.TabIndex = 6;
            this.Credits.Text = "Credits";
            this.Credits.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "GPA";
            this.label1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.CreditTxtBox);
            this.Controls.Add(this.GPAtxtbox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.RegisterButton);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button ScheduleButton;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox GPAtxtbox;
        private System.Windows.Forms.TextBox CreditTxtBox;
        private System.Windows.Forms.Label Credits;
        private System.Windows.Forms.Label label1;

    }
}