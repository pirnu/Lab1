namespace CG_SK_Lab1
{
    partial class EnrollCadet
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.bcText = new System.Windows.Forms.TextBox();
            this.pinText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CloseEnroll = new System.Windows.Forms.Button();
            this.addcadet = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.directions = new System.Windows.Forms.Label();
            this.nstatus = new System.Windows.Forms.PictureBox();
            this.bstatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bstatus)).BeginInit();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(144, 70);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(144, 20);
            this.nameText.TabIndex = 0;
            this.nameText.Leave += new System.EventHandler(this.nameText_Leave);
            // 
            // bcText
            // 
            this.bcText.Location = new System.Drawing.Point(144, 105);
            this.bcText.Name = "bcText";
            this.bcText.Size = new System.Drawing.Size(144, 20);
            this.bcText.TabIndex = 1;
            this.bcText.Leave += new System.EventHandler(this.bcText_Leave);
            // 
            // pinText
            // 
            this.pinText.Location = new System.Drawing.Point(144, 141);
            this.pinText.Name = "pinText";
            this.pinText.PasswordChar = '*';
            this.pinText.Size = new System.Drawing.Size(144, 20);
            this.pinText.TabIndex = 2;
            this.pinText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pinText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(55, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(69, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Barcode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(107, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pin:";
            // 
            // CloseEnroll
            // 
            this.CloseEnroll.Location = new System.Drawing.Point(178, 208);
            this.CloseEnroll.Name = "CloseEnroll";
            this.CloseEnroll.Size = new System.Drawing.Size(75, 23);
            this.CloseEnroll.TabIndex = 6;
            this.CloseEnroll.Text = "Cancel";
            this.CloseEnroll.UseVisualStyleBackColor = true;
            this.CloseEnroll.Click += new System.EventHandler(this.CloseEnroll_Click);
            // 
            // addcadet
            // 
            this.addcadet.Location = new System.Drawing.Point(144, 167);
            this.addcadet.Name = "addcadet";
            this.addcadet.Size = new System.Drawing.Size(144, 23);
            this.addcadet.TabIndex = 7;
            this.addcadet.Text = "Add Cadet";
            this.addcadet.UseVisualStyleBackColor = true;
            this.addcadet.Click += new System.EventHandler(this.addcadet_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(78, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(210, 26);
            this.title.TabIndex = 8;
            this.title.Text = "Enroll New Cadet";
            // 
            // directions
            // 
            this.directions.AutoSize = true;
            this.directions.Location = new System.Drawing.Point(91, 44);
            this.directions.Name = "directions";
            this.directions.Size = new System.Drawing.Size(197, 13);
            this.directions.TabIndex = 9;
            this.directions.Text = "Please Enter the Appropriate Information";
            // 
            // nstatus
            // 
            this.nstatus.Location = new System.Drawing.Point(294, 70);
            this.nstatus.Name = "nstatus";
            this.nstatus.Size = new System.Drawing.Size(22, 19);
            this.nstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nstatus.TabIndex = 10;
            this.nstatus.TabStop = false;
            this.nstatus.Visible = false;
            // 
            // bstatus
            // 
            this.bstatus.Location = new System.Drawing.Point(294, 106);
            this.bstatus.Name = "bstatus";
            this.bstatus.Size = new System.Drawing.Size(22, 19);
            this.bstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bstatus.TabIndex = 11;
            this.bstatus.TabStop = false;
            this.bstatus.Visible = false;
            // 
            // EnrollCadet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 253);
            this.Controls.Add(this.bstatus);
            this.Controls.Add(this.nstatus);
            this.Controls.Add(this.directions);
            this.Controls.Add(this.title);
            this.Controls.Add(this.addcadet);
            this.Controls.Add(this.CloseEnroll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pinText);
            this.Controls.Add(this.bcText);
            this.Controls.Add(this.nameText);
            this.Name = "EnrollCadet";
            this.Text = "EnrollCadet";
            this.Load += new System.EventHandler(this.EnrollCadet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bstatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox bcText;
        private System.Windows.Forms.TextBox pinText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CloseEnroll;
        private System.Windows.Forms.Button addcadet;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label directions;
        private System.Windows.Forms.PictureBox nstatus;
        private System.Windows.Forms.PictureBox bstatus;
    }
}