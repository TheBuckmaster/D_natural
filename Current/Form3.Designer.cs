namespace BensCRS
{
    partial class Form3
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
            this.Sbutton = new System.Windows.Forms.Button();
            this.LButton = new System.Windows.Forms.Button();
            this.AButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Sbutton
            // 
            this.Sbutton.Location = new System.Drawing.Point(451, 240);
            this.Sbutton.Name = "Sbutton";
            this.Sbutton.Size = new System.Drawing.Size(116, 23);
            this.Sbutton.TabIndex = 0;
            this.Sbutton.Text = "View Schedule";
            this.Sbutton.UseVisualStyleBackColor = true;
            this.Sbutton.Click += new System.EventHandler(this.Sbutton_Click);
            // 
            // LButton
            // 
            this.LButton.Location = new System.Drawing.Point(703, 240);
            this.LButton.Name = "LButton";
            this.LButton.Size = new System.Drawing.Size(88, 23);
            this.LButton.TabIndex = 1;
            this.LButton.Text = "Log Out";
            this.LButton.UseVisualStyleBackColor = true;
            this.LButton.Click += new System.EventHandler(this.LButton_Click);
            // 
            // AButton
            // 
            this.AButton.Location = new System.Drawing.Point(573, 240);
            this.AButton.Name = "AButton";
            this.AButton.Size = new System.Drawing.Size(124, 23);
            this.AButton.TabIndex = 2;
            this.AButton.Text = "Advising";
            this.AButton.UseVisualStyleBackColor = true;
            this.AButton.Click += new System.EventHandler(this.AButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(785, 227);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 275);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AButton);
            this.Controls.Add(this.LButton);
            this.Controls.Add(this.Sbutton);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Sbutton;
        private System.Windows.Forms.Button LButton;
        private System.Windows.Forms.Button AButton;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}