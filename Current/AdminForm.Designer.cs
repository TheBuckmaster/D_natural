namespace BensCRS
{
    partial class AdminForm
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
            this.logoutBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.StudentButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.FastRegButton = new System.Windows.Forms.Button();
            this.AdvisorButton = new System.Windows.Forms.Button();
            this.DetailBox = new System.Windows.Forms.TextBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.ActualRegButton = new System.Windows.Forms.Button();
            this.killButton = new System.Windows.Forms.Button();
            this.NoButton2 = new System.Windows.Forms.Button();
            this.YesButton2 = new System.Windows.Forms.Button();
            this.DetailBox2 = new System.Windows.Forms.TextBox();
            this.TrueNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(578, 409);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(97, 23);
            this.logoutBtn.TabIndex = 0;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dataGridView1.Location = new System.Drawing.Point(12, 164);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(320, 239);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "View Courses";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StudentButton
            // 
            this.StudentButton.Location = new System.Drawing.Point(12, 12);
            this.StudentButton.Name = "StudentButton";
            this.StudentButton.Size = new System.Drawing.Size(209, 146);
            this.StudentButton.TabIndex = 3;
            this.StudentButton.Text = "Modify Student";
            this.StudentButton.UseVisualStyleBackColor = true;
            this.StudentButton.Click += new System.EventHandler(this.ViewStudents);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(227, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 146);
            this.button3.TabIndex = 4;
            this.button3.Text = "Modify Faculty";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(439, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(236, 146);
            this.button4.TabIndex = 5;
            this.button4.Text = "Modify Course";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dataGridView2.Location = new System.Drawing.Point(339, 164);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(335, 238);
            this.dataGridView2.TabIndex = 6;
            // 
            // FastRegButton
            // 
            this.FastRegButton.Location = new System.Drawing.Point(339, 409);
            this.FastRegButton.Name = "FastRegButton";
            this.FastRegButton.Size = new System.Drawing.Size(123, 23);
            this.FastRegButton.TabIndex = 7;
            this.FastRegButton.Text = "Add Student to Course";
            this.FastRegButton.UseVisualStyleBackColor = true;
            this.FastRegButton.Click += new System.EventHandler(this.FastRegButton_Click);
            // 
            // AdvisorButton
            // 
            this.AdvisorButton.Location = new System.Drawing.Point(215, 409);
            this.AdvisorButton.Name = "AdvisorButton";
            this.AdvisorButton.Size = new System.Drawing.Size(117, 23);
            this.AdvisorButton.TabIndex = 8;
            this.AdvisorButton.Text = "View Advisor";
            this.AdvisorButton.UseVisualStyleBackColor = true;
            this.AdvisorButton.Click += new System.EventHandler(this.AdvisorButton_Click);
            // 
            // DetailBox
            // 
            this.DetailBox.Location = new System.Drawing.Point(385, 197);
            this.DetailBox.Name = "DetailBox";
            this.DetailBox.Size = new System.Drawing.Size(241, 20);
            this.DetailBox.TabIndex = 9;
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(385, 223);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(116, 26);
            this.YesButton.TabIndex = 10;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.Location = new System.Drawing.Point(507, 223);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(119, 26);
            this.NoButton.TabIndex = 11;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // ActualRegButton
            // 
            this.ActualRegButton.Location = new System.Drawing.Point(466, 409);
            this.ActualRegButton.Name = "ActualRegButton";
            this.ActualRegButton.Size = new System.Drawing.Size(112, 23);
            this.ActualRegButton.TabIndex = 12;
            this.ActualRegButton.Text = "Register";
            this.ActualRegButton.UseVisualStyleBackColor = true;
            this.ActualRegButton.Click += new System.EventHandler(this.ActualRegButton_Click);
            // 
            // killButton
            // 
            this.killButton.Location = new System.Drawing.Point(12, 409);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(83, 23);
            this.killButton.TabIndex = 13;
            this.killButton.Text = "Delete";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // NoButton2
            // 
            this.NoButton2.Location = new System.Drawing.Point(507, 313);
            this.NoButton2.Name = "NoButton2";
            this.NoButton2.Size = new System.Drawing.Size(119, 26);
            this.NoButton2.TabIndex = 17;
            this.NoButton2.Text = "Abort Changes";
            this.NoButton2.UseVisualStyleBackColor = true;
            this.NoButton2.Click += new System.EventHandler(this.NoButton2_Click);
            // 
            // YesButton2
            // 
            this.YesButton2.Location = new System.Drawing.Point(385, 313);
            this.YesButton2.Name = "YesButton2";
            this.YesButton2.Size = new System.Drawing.Size(116, 26);
            this.YesButton2.TabIndex = 16;
            this.YesButton2.Text = "Yes";
            this.YesButton2.UseVisualStyleBackColor = true;
            this.YesButton2.Click += new System.EventHandler(this.YesButton2_Click);
            // 
            // DetailBox2
            // 
            this.DetailBox2.Location = new System.Drawing.Point(385, 287);
            this.DetailBox2.Name = "DetailBox2";
            this.DetailBox2.Size = new System.Drawing.Size(241, 20);
            this.DetailBox2.TabIndex = 15;
            // 
            // TrueNo
            // 
            this.TrueNo.Location = new System.Drawing.Point(385, 246);
            this.TrueNo.Name = "TrueNo";
            this.TrueNo.Size = new System.Drawing.Size(116, 26);
            this.TrueNo.TabIndex = 18;
            this.TrueNo.Text = "No";
            this.TrueNo.UseVisualStyleBackColor = true;
            this.TrueNo.Click += new System.EventHandler(this.TrueNo_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 441);
            this.Controls.Add(this.TrueNo);
            this.Controls.Add(this.NoButton2);
            this.Controls.Add(this.YesButton2);
            this.Controls.Add(this.DetailBox2);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.ActualRegButton);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.DetailBox);
            this.Controls.Add(this.AdvisorButton);
            this.Controls.Add(this.FastRegButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.StudentButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.logoutBtn);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button StudentButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button FastRegButton;
        private System.Windows.Forms.Button AdvisorButton;
        private System.Windows.Forms.TextBox DetailBox;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Button ActualRegButton;
        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.Button NoButton2;
        private System.Windows.Forms.Button YesButton2;
        private System.Windows.Forms.TextBox DetailBox2;
        private System.Windows.Forms.Button TrueNo;
    }
}