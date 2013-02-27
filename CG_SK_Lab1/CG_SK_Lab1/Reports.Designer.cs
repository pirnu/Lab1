namespace CG_SK_Lab1
{
    partial class Reports
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cRadio = new System.Windows.Forms.RadioButton();
            this.mRadio = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.eRadio = new System.Windows.Forms.RadioButton();
            this.multRadio = new System.Windows.Forms.RadioButton();
            this.nameText = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.month1 = new System.Windows.Forms.TextBox();
            this.day1 = new System.Windows.Forms.TextBox();
            this.year1 = new System.Windows.Forms.TextBox();
            this.month2 = new System.Windows.Forms.TextBox();
            this.day2 = new System.Windows.Forms.TextBox();
            this.year2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.blank = new System.Windows.Forms.Label();
            this.mealLabel = new System.Windows.Forms.Label();
            this.numcadets = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(621, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // cRadio
            // 
            this.cRadio.AutoSize = true;
            this.cRadio.Location = new System.Drawing.Point(24, 12);
            this.cRadio.Name = "cRadio";
            this.cRadio.Size = new System.Drawing.Size(53, 17);
            this.cRadio.TabIndex = 1;
            this.cRadio.TabStop = true;
            this.cRadio.Text = "Cadet";
            this.cRadio.UseVisualStyleBackColor = true;
            this.cRadio.CheckedChanged += new System.EventHandler(this.cRadio_CheckedChanged);
            // 
            // mRadio
            // 
            this.mRadio.AutoSize = true;
            this.mRadio.Location = new System.Drawing.Point(24, 30);
            this.mRadio.Name = "mRadio";
            this.mRadio.Size = new System.Drawing.Size(48, 17);
            this.mRadio.TabIndex = 2;
            this.mRadio.TabStop = true;
            this.mRadio.Text = "Meal";
            this.mRadio.UseVisualStyleBackColor = true;
            this.mRadio.CheckedChanged += new System.EventHandler(this.mRadio_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(532, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(472, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(472, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(416, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 18;
            // 
            // eRadio
            // 
            this.eRadio.AutoSize = true;
            this.eRadio.Location = new System.Drawing.Point(24, 53);
            this.eRadio.Name = "eRadio";
            this.eRadio.Size = new System.Drawing.Size(67, 17);
            this.eRadio.TabIndex = 32;
            this.eRadio.TabStop = true;
            this.eRadio.Text = "Excusals";
            this.eRadio.UseVisualStyleBackColor = true;
            this.eRadio.CheckedChanged += new System.EventHandler(this.eRadio_CheckedChanged);
            // 
            // multRadio
            // 
            this.multRadio.AutoSize = true;
            this.multRadio.Location = new System.Drawing.Point(24, 77);
            this.multRadio.Name = "multRadio";
            this.multRadio.Size = new System.Drawing.Size(102, 17);
            this.multRadio.TabIndex = 33;
            this.multRadio.TabStop = true;
            this.multRadio.Text = "Multiple Sign Ins";
            this.multRadio.UseVisualStyleBackColor = true;
            this.multRadio.CheckedChanged += new System.EventHandler(this.multRadio_CheckedChanged);
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(151, 30);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(100, 20);
            this.nameText.TabIndex = 34;
            this.nameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameText_Enter);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(157, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(94, 13);
            this.nameLabel.TabIndex = 35;
            this.nameLabel.Text = "Enter Cadet Name";
            this.nameLabel.Visible = false;
            // 
            // month1
            // 
            this.month1.Location = new System.Drawing.Point(273, 74);
            this.month1.Name = "month1";
            this.month1.Size = new System.Drawing.Size(20, 20);
            this.month1.TabIndex = 36;
            // 
            // day1
            // 
            this.day1.Location = new System.Drawing.Point(307, 76);
            this.day1.Name = "day1";
            this.day1.Size = new System.Drawing.Size(33, 20);
            this.day1.TabIndex = 37;
            // 
            // year1
            // 
            this.year1.Location = new System.Drawing.Point(358, 76);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(44, 20);
            this.year1.TabIndex = 38;
            // 
            // month2
            // 
            this.month2.Location = new System.Drawing.Point(419, 77);
            this.month2.Name = "month2";
            this.month2.Size = new System.Drawing.Size(22, 20);
            this.month2.TabIndex = 39;
            // 
            // day2
            // 
            this.day2.Location = new System.Drawing.Point(450, 76);
            this.day2.Name = "day2";
            this.day2.Size = new System.Drawing.Size(22, 20);
            this.day2.TabIndex = 40;
            // 
            // year2
            // 
            this.year2.Location = new System.Drawing.Point(478, 76);
            this.year2.Name = "year2";
            this.year2.Size = new System.Drawing.Size(44, 20);
            this.year2.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "From:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(420, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "To:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "MM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(304, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "DD";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(355, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "YYYY";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(418, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 47;
            this.label17.Text = "MM";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(449, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "DD";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(478, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "YYYY";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(307, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(230, 13);
            this.label20.TabIndex = 50;
            this.label20.Text = "Search Dates (Type month name all lowercase)";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(572, 55);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 47);
            this.search.TabIndex = 51;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // blank
            // 
            this.blank.AutoSize = true;
            this.blank.Location = new System.Drawing.Point(274, 99);
            this.blank.Name = "blank";
            this.blank.Size = new System.Drawing.Size(126, 13);
            this.blank.TabIndex = 52;
            this.blank.Text = "**Dates Cannot Be Blank";
            this.blank.Visible = false;
            // 
            // mealLabel
            // 
            this.mealLabel.AutoSize = true;
            this.mealLabel.Location = new System.Drawing.Point(157, 9);
            this.mealLabel.Name = "mealLabel";
            this.mealLabel.Size = new System.Drawing.Size(89, 13);
            this.mealLabel.TabIndex = 53;
            this.mealLabel.Text = "Enter Meal Name";
            // 
            // numcadets
            // 
            this.numcadets.AutoSize = true;
            this.numcadets.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numcadets.Location = new System.Drawing.Point(177, 76);
            this.numcadets.Name = "numcadets";
            this.numcadets.Size = new System.Drawing.Size(30, 31);
            this.numcadets.TabIndex = 54;
            this.numcadets.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "Total Signed In";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 280);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numcadets);
            this.Controls.Add(this.blank);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.year2);
            this.Controls.Add(this.day2);
            this.Controls.Add(this.month2);
            this.Controls.Add(this.year1);
            this.Controls.Add(this.day1);
            this.Controls.Add(this.month1);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.multRadio);
            this.Controls.Add(this.eRadio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mRadio);
            this.Controls.Add(this.cRadio);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mealLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton cRadio;
        private System.Windows.Forms.RadioButton mRadio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton eRadio;
        private System.Windows.Forms.RadioButton multRadio;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox month1;
        private System.Windows.Forms.TextBox day1;
        private System.Windows.Forms.TextBox year1;
        private System.Windows.Forms.TextBox month2;
        private System.Windows.Forms.TextBox day2;
        private System.Windows.Forms.TextBox year2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label blank;
        private System.Windows.Forms.Label mealLabel;
        private System.Windows.Forms.Label numcadets;
        private System.Windows.Forms.Label label2;

    }
}