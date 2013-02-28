namespace CG_SK_Lab1
{
    partial class Predictions
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
            this.day = new System.Windows.Forms.RadioButton();
            this.week = new System.Windows.Forms.RadioButton();
            this.month = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.Location = new System.Drawing.Point(12, 36);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(44, 17);
            this.day.TabIndex = 0;
            this.day.TabStop = true;
            this.day.Text = "Day";
            this.day.UseVisualStyleBackColor = true;
            this.day.CheckedChanged += new System.EventHandler(this.day_CheckedChanged);
            // 
            // week
            // 
            this.week.AutoSize = true;
            this.week.Location = new System.Drawing.Point(12, 59);
            this.week.Name = "week";
            this.week.Size = new System.Drawing.Size(54, 17);
            this.week.TabIndex = 1;
            this.week.TabStop = true;
            this.week.Text = "Week";
            this.week.UseVisualStyleBackColor = true;
            this.week.CheckedChanged += new System.EventHandler(this.week_CheckedChanged);
            // 
            // month
            // 
            this.month.AutoSize = true;
            this.month.Location = new System.Drawing.Point(12, 82);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(55, 17);
            this.month.TabIndex = 2;
            this.month.TabStop = true;
            this.month.Text = "Month";
            this.month.UseVisualStyleBackColor = true;
            this.month.CheckedChanged += new System.EventHandler(this.month_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(106, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(525, 186);
            this.dataGridView1.TabIndex = 19;
            // 
            // Predictions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 366);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.month);
            this.Controls.Add(this.week);
            this.Controls.Add(this.day);
            this.Name = "Predictions";
            this.Text = "Predictions";
            this.Load += new System.EventHandler(this.Predictions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton day;
        private System.Windows.Forms.RadioButton week;
        private System.Windows.Forms.RadioButton month;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}