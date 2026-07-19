namespace WindowsFormsApp1
{
    partial class StudentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonviewattendence = new System.Windows.Forms.Button();
            this.buttonuploadassignment = new System.Windows.Forms.Button();
            this.buttonviewresult = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.namallogo;
            this.pictureBox1.Location = new System.Drawing.Point(120, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Interface";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.buttonviewresult);
            this.groupBox1.Controls.Add(this.buttonuploadassignment);
            this.groupBox1.Controls.Add(this.buttonviewattendence);
            this.groupBox1.Location = new System.Drawing.Point(212, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 221);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonviewattendence
            // 
            this.buttonviewattendence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonviewattendence.Location = new System.Drawing.Point(80, 25);
            this.buttonviewattendence.Name = "buttonviewattendence";
            this.buttonviewattendence.Size = new System.Drawing.Size(231, 39);
            this.buttonviewattendence.TabIndex = 3;
            this.buttonviewattendence.Text = "View Attendence";
            this.buttonviewattendence.UseVisualStyleBackColor = true;
            // 
            // buttonuploadassignment
            // 
            this.buttonuploadassignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonuploadassignment.Location = new System.Drawing.Point(78, 81);
            this.buttonuploadassignment.Name = "buttonuploadassignment";
            this.buttonuploadassignment.Size = new System.Drawing.Size(256, 39);
            this.buttonuploadassignment.TabIndex = 4;
            this.buttonuploadassignment.Text = "Upload Assignment";
            this.buttonuploadassignment.UseVisualStyleBackColor = true;
            // 
            // buttonviewresult
            // 
            this.buttonviewresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonviewresult.Location = new System.Drawing.Point(80, 148);
            this.buttonviewresult.Name = "buttonviewresult";
            this.buttonviewresult.Size = new System.Drawing.Size(231, 39);
            this.buttonviewresult.TabIndex = 5;
            this.buttonviewresult.Text = "ViewResult";
            this.buttonviewresult.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(220, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(436, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Student Management System";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonviewresult;
        private System.Windows.Forms.Button buttonuploadassignment;
        private System.Windows.Forms.Button buttonviewattendence;
        private System.Windows.Forms.Label label2;
    }
}