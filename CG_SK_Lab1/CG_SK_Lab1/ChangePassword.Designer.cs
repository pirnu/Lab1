namespace CG_SK_Lab1
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.feedback = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.pinText = new System.Windows.Forms.TextBox();
            this.verify = new System.Windows.Forms.Label();
            this.verified = new System.Windows.Forms.TextBox();
            this.commit = new System.Windows.Forms.Button();
            this.nstatus = new System.Windows.Forms.PictureBox();
            this.pstatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pstatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Pin:";
            // 
            // feedback
            // 
            this.feedback.AutoSize = true;
            this.feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedback.Location = new System.Drawing.Point(31, 15);
            this.feedback.Name = "feedback";
            this.feedback.Size = new System.Drawing.Size(277, 20);
            this.feedback.TabIndex = 2;
            this.feedback.Text = "Enter Existing Username and New Pin";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(153, 70);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(130, 20);
            this.nameText.TabIndex = 3;
            this.nameText.Leave += new System.EventHandler(this.nameText_Leave);
            // 
            // pinText
            // 
            this.pinText.Location = new System.Drawing.Point(153, 115);
            this.pinText.Name = "pinText";
            this.pinText.Size = new System.Drawing.Size(127, 20);
            this.pinText.TabIndex = 4;
            // 
            // verify
            // 
            this.verify.AutoSize = true;
            this.verify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verify.Location = new System.Drawing.Point(26, 156);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(114, 20);
            this.verify.TabIndex = 5;
            this.verify.Text = "Verify New Pin:";
            // 
            // verified
            // 
            this.verified.Location = new System.Drawing.Point(153, 156);
            this.verified.Name = "verified";
            this.verified.Size = new System.Drawing.Size(127, 20);
            this.verified.TabIndex = 6;
            this.verified.TextChanged += new System.EventHandler(this.verified_TextChanged);
            this.verified.KeyDown += new System.Windows.Forms.KeyEventHandler(this.verified_KeyDown);
            // 
            // commit
            // 
            this.commit.Location = new System.Drawing.Point(92, 206);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(142, 23);
            this.commit.TabIndex = 7;
            this.commit.Text = "Commit Changes";
            this.commit.UseVisualStyleBackColor = true;
            this.commit.Click += new System.EventHandler(this.commit_Click);
            // 
            // nstatus
            // 
            this.nstatus.Image = ((System.Drawing.Image)(resources.GetObject("nstatus.Image")));
            this.nstatus.InitialImage = null;
            this.nstatus.Location = new System.Drawing.Point(289, 70);
            this.nstatus.Name = "nstatus";
            this.nstatus.Size = new System.Drawing.Size(19, 19);
            this.nstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nstatus.TabIndex = 8;
            this.nstatus.TabStop = false;
            // 
            // pstatus
            // 
            this.pstatus.Image = ((System.Drawing.Image)(resources.GetObject("pstatus.Image")));
            this.pstatus.InitialImage = null;
            this.pstatus.Location = new System.Drawing.Point(289, 156);
            this.pstatus.Name = "pstatus";
            this.pstatus.Size = new System.Drawing.Size(19, 19);
            this.pstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pstatus.TabIndex = 9;
            this.pstatus.TabStop = false;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 246);
            this.Controls.Add(this.pstatus);
            this.Controls.Add(this.nstatus);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.verified);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.pinText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.feedback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pstatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label feedback;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox pinText;
        private System.Windows.Forms.Label verify;
        private System.Windows.Forms.TextBox verified;
        private System.Windows.Forms.Button commit;
        private System.Windows.Forms.PictureBox nstatus;
        private System.Windows.Forms.PictureBox pstatus;
    }
}