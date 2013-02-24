namespace CG_SK_Lab1
{
    partial class UEnter
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
            this.AButton = new System.Windows.Forms.Button();
            this.ANameText = new System.Windows.Forms.TextBox();
            this.APassText = new System.Windows.Forms.TextBox();
            this.ANameLabel = new System.Windows.Forms.Label();
            this.APassLabel = new System.Windows.Forms.Label();
            this.ALogin = new System.Windows.Forms.Button();
            this.UIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UNameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UPinText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ADispRep = new System.Windows.Forms.Button();
            this.ADispPred = new System.Windows.Forms.Button();
            this.AEnroll = new System.Windows.Forms.Button();
            this.AChangePass = new System.Windows.Forms.Button();
            this.AMenuLabel = new System.Windows.Forms.Label();
            this.access = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.adminaccess = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AButton
            // 
            this.AButton.Location = new System.Drawing.Point(12, 210);
            this.AButton.Name = "AButton";
            this.AButton.Size = new System.Drawing.Size(108, 32);
            this.AButton.TabIndex = 0;
            this.AButton.Text = "Admin Login";
            this.AButton.UseVisualStyleBackColor = true;
            this.AButton.Click += new System.EventHandler(this.AButton_Click);
            // 
            // ANameText
            // 
            this.ANameText.Location = new System.Drawing.Point(13, 269);
            this.ANameText.Name = "ANameText";
            this.ANameText.Size = new System.Drawing.Size(138, 20);
            this.ANameText.TabIndex = 1;
            this.ANameText.Visible = false;
            this.ANameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ANameText_KeyDown);
            // 
            // APassText
            // 
            this.APassText.Location = new System.Drawing.Point(13, 314);
            this.APassText.Name = "APassText";
            this.APassText.Size = new System.Drawing.Size(138, 20);
            this.APassText.TabIndex = 2;
            this.APassText.Visible = false;
            this.APassText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ANameText_KeyDown);
            // 
            // ANameLabel
            // 
            this.ANameLabel.AutoSize = true;
            this.ANameLabel.Location = new System.Drawing.Point(13, 249);
            this.ANameLabel.Name = "ANameLabel";
            this.ANameLabel.Size = new System.Drawing.Size(55, 13);
            this.ANameLabel.TabIndex = 3;
            this.ANameLabel.Text = "Username";
            this.ANameLabel.Visible = false;
            // 
            // APassLabel
            // 
            this.APassLabel.AutoSize = true;
            this.APassLabel.Location = new System.Drawing.Point(12, 296);
            this.APassLabel.Name = "APassLabel";
            this.APassLabel.Size = new System.Drawing.Size(53, 13);
            this.APassLabel.TabIndex = 4;
            this.APassLabel.Text = "Password";
            this.APassLabel.Visible = false;
            // 
            // ALogin
            // 
            this.ALogin.Location = new System.Drawing.Point(12, 344);
            this.ALogin.Name = "ALogin";
            this.ALogin.Size = new System.Drawing.Size(75, 23);
            this.ALogin.TabIndex = 5;
            this.ALogin.Text = "Log In";
            this.ALogin.UseVisualStyleBackColor = true;
            this.ALogin.Visible = false;
            this.ALogin.Click += new System.EventHandler(this.ALogin_Click);
            // 
            // UIDText
            // 
            this.UIDText.Location = new System.Drawing.Point(16, 55);
            this.UIDText.Name = "UIDText";
            this.UIDText.Size = new System.Drawing.Size(178, 20);
            this.UIDText.TabIndex = 6;
            this.UIDText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIDText_KeyDown);
            this.UIDText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UIDText_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Scan ID";
            // 
            // UNameText
            // 
            this.UNameText.Location = new System.Drawing.Point(273, 55);
            this.UNameText.Name = "UNameText";
            this.UNameText.Size = new System.Drawing.Size(138, 20);
            this.UNameText.TabIndex = 8;
            this.UNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UNameText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(273, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enter Username";
            // 
            // UPinText
            // 
            this.UPinText.Location = new System.Drawing.Point(273, 112);
            this.UPinText.Name = "UPinText";
            this.UPinText.Size = new System.Drawing.Size(138, 20);
            this.UPinText.TabIndex = 10;
            this.UPinText.TextChanged += new System.EventHandler(this.UPinText_TextChanged);
            this.UPinText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UPinText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(273, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter Pin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ADispRep
            // 
            this.ADispRep.Location = new System.Drawing.Point(273, 228);
            this.ADispRep.Name = "ADispRep";
            this.ADispRep.Size = new System.Drawing.Size(107, 23);
            this.ADispRep.TabIndex = 13;
            this.ADispRep.Text = "Display Reports";
            this.ADispRep.UseVisualStyleBackColor = true;
            this.ADispRep.Visible = false;
            this.ADispRep.Click += new System.EventHandler(this.ADispRep_Click);
            // 
            // ADispPred
            // 
            this.ADispPred.Location = new System.Drawing.Point(273, 269);
            this.ADispPred.Name = "ADispPred";
            this.ADispPred.Size = new System.Drawing.Size(107, 23);
            this.ADispPred.TabIndex = 14;
            this.ADispPred.Text = "Display Predictions";
            this.ADispPred.UseVisualStyleBackColor = true;
            this.ADispPred.Visible = false;
            this.ADispPred.Click += new System.EventHandler(this.ADispPred_Click);
            // 
            // AEnroll
            // 
            this.AEnroll.Location = new System.Drawing.Point(273, 311);
            this.AEnroll.Name = "AEnroll";
            this.AEnroll.Size = new System.Drawing.Size(107, 23);
            this.AEnroll.TabIndex = 15;
            this.AEnroll.Text = "Enroll New Cadet";
            this.AEnroll.UseVisualStyleBackColor = true;
            this.AEnroll.Visible = false;
            this.AEnroll.Click += new System.EventHandler(this.AEnroll_Click);
            // 
            // AChangePass
            // 
            this.AChangePass.Location = new System.Drawing.Point(273, 353);
            this.AChangePass.Name = "AChangePass";
            this.AChangePass.Size = new System.Drawing.Size(107, 23);
            this.AChangePass.TabIndex = 16;
            this.AChangePass.Text = "Change Password";
            this.AChangePass.UseVisualStyleBackColor = true;
            this.AChangePass.Visible = false;
            this.AChangePass.Click += new System.EventHandler(this.AChangePass_Click);
            // 
            // AMenuLabel
            // 
            this.AMenuLabel.AutoSize = true;
            this.AMenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AMenuLabel.Location = new System.Drawing.Point(273, 196);
            this.AMenuLabel.Name = "AMenuLabel";
            this.AMenuLabel.Size = new System.Drawing.Size(98, 20);
            this.AMenuLabel.TabIndex = 18;
            this.AMenuLabel.Text = "Admin Menu";
            this.AMenuLabel.Visible = false;
            // 
            // access
            // 
            this.access.AutoSize = true;
            this.access.Font = new System.Drawing.Font("Lucida Sans Typewriter", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.access.ForeColor = System.Drawing.Color.Black;
            this.access.Location = new System.Drawing.Point(25, 112);
            this.access.Name = "access";
            this.access.Size = new System.Drawing.Size(188, 37);
            this.access.TabIndex = 19;
            this.access.Text = "Scan Card";
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // adminaccess
            // 
            this.adminaccess.AutoSize = true;
            this.adminaccess.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminaccess.Location = new System.Drawing.Point(16, 387);
            this.adminaccess.Name = "adminaccess";
            this.adminaccess.Size = new System.Drawing.Size(178, 18);
            this.adminaccess.TabIndex = 20;
            this.adminaccess.Text = "Enter Credentials";
            this.adminaccess.Visible = false;
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(273, 387);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(107, 35);
            this.logout.TabIndex = 21;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Visible = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // UEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 426);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.adminaccess);
            this.Controls.Add(this.access);
            this.Controls.Add(this.AMenuLabel);
            this.Controls.Add(this.AChangePass);
            this.Controls.Add(this.AEnroll);
            this.Controls.Add(this.ADispPred);
            this.Controls.Add(this.ADispRep);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UPinText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UNameText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UIDText);
            this.Controls.Add(this.ALogin);
            this.Controls.Add(this.APassLabel);
            this.Controls.Add(this.ANameLabel);
            this.Controls.Add(this.APassText);
            this.Controls.Add(this.ANameText);
            this.Controls.Add(this.AButton);
            this.Name = "UEnter";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UEnter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AButton;
        private System.Windows.Forms.TextBox ANameText;
        private System.Windows.Forms.TextBox APassText;
        private System.Windows.Forms.Label ANameLabel;
        private System.Windows.Forms.Label APassLabel;
        private System.Windows.Forms.Button ALogin;
        private System.Windows.Forms.TextBox UIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UPinText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ADispRep;
        private System.Windows.Forms.Button ADispPred;
        private System.Windows.Forms.Button AEnroll;
        private System.Windows.Forms.Button AChangePass;
        private System.Windows.Forms.Label AMenuLabel;
        private System.Windows.Forms.Label access;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label adminaccess;
        private System.Windows.Forms.Button logout;
    }
}

