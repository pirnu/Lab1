namespace CG_SK_Lab1
{
    partial class Already_Signed_In
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
            this.Title = new System.Windows.Forms.Label();
            this.Note = new System.Windows.Forms.Label();
            this.Accept = new System.Windows.Forms.Button();
            this.aoverride = new System.Windows.Forms.Button();
            this.aname = new System.Windows.Forms.Label();
            this.apass = new System.Windows.Forms.Label();
            this.ANameText = new System.Windows.Forms.TextBox();
            this.APassText = new System.Windows.Forms.TextBox();
            this.enter = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(23, 33);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(392, 20);
            this.Title.TabIndex = 0;
            this.Title.Text = "Whoops! It appears you have already signed in! ";
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.Location = new System.Drawing.Point(12, 66);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(415, 16);
            this.Note.TabIndex = 1;
            this.Note.Text = "If this was not you please find an administator to assist you.";
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(63, 105);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(117, 23);
            this.Accept.TabIndex = 2;
            this.Accept.Text = "It was me!";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // aoverride
            // 
            this.aoverride.Location = new System.Drawing.Point(255, 105);
            this.aoverride.Name = "aoverride";
            this.aoverride.Size = new System.Drawing.Size(117, 23);
            this.aoverride.TabIndex = 3;
            this.aoverride.Text = "Admin Overide";
            this.aoverride.UseVisualStyleBackColor = true;
            this.aoverride.Click += new System.EventHandler(this.aoverride_Click);
            // 
            // aname
            // 
            this.aname.AutoSize = true;
            this.aname.Location = new System.Drawing.Point(52, 152);
            this.aname.Name = "aname";
            this.aname.Size = new System.Drawing.Size(70, 13);
            this.aname.TabIndex = 4;
            this.aname.Text = "Admin Name:";
            // 
            // apass
            // 
            this.apass.AutoSize = true;
            this.apass.Location = new System.Drawing.Point(66, 183);
            this.apass.Name = "apass";
            this.apass.Size = new System.Drawing.Size(56, 13);
            this.apass.TabIndex = 5;
            this.apass.Text = "Password:";
            // 
            // ANameText
            // 
            this.ANameText.Location = new System.Drawing.Point(129, 152);
            this.ANameText.Name = "ANameText";
            this.ANameText.Size = new System.Drawing.Size(100, 20);
            this.ANameText.TabIndex = 6;
            this.ANameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ANameText_KeyDown);
            // 
            // APassText
            // 
            this.APassText.Location = new System.Drawing.Point(129, 183);
            this.APassText.Name = "APassText";
            this.APassText.PasswordChar = '*';
            this.APassText.Size = new System.Drawing.Size(100, 20);
            this.APassText.TabIndex = 7;
            this.APassText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.APassText_KeyDown);
            // 
            // enter
            // 
            this.enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enter.Location = new System.Drawing.Point(255, 152);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(117, 49);
            this.enter.TabIndex = 8;
            this.enter.Text = "Override";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.Red;
            this.status.Location = new System.Drawing.Point(85, 218);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(144, 16);
            this.status.TabIndex = 9;
            this.status.Text = "Username/Pin Error";
            this.status.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Already_Signed_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 252);
            this.Controls.Add(this.status);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.APassText);
            this.Controls.Add(this.ANameText);
            this.Controls.Add(this.apass);
            this.Controls.Add(this.aname);
            this.Controls.Add(this.aoverride);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.Title);
            this.Name = "Already_Signed_In";
            this.Text = "Already Signed In";
            this.Load += new System.EventHandler(this.Already_Signed_In_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Note;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button aoverride;
        private System.Windows.Forms.Label aname;
        private System.Windows.Forms.Label apass;
        private System.Windows.Forms.TextBox ANameText;
        private System.Windows.Forms.TextBox APassText;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer timer1;
    }
}