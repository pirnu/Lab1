namespace CG_SK_Lab1
{
    partial class NewMeal
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
            this.BreakRadio = new System.Windows.Forms.RadioButton();
            this.lunchRadio = new System.Windows.Forms.RadioButton();
            this.dinnerRadio = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BreakRadio
            // 
            this.BreakRadio.AutoSize = true;
            this.BreakRadio.Location = new System.Drawing.Point(43, 24);
            this.BreakRadio.Name = "BreakRadio";
            this.BreakRadio.Size = new System.Drawing.Size(70, 17);
            this.BreakRadio.TabIndex = 0;
            this.BreakRadio.TabStop = true;
            this.BreakRadio.Text = "Breakfast";
            this.BreakRadio.UseVisualStyleBackColor = true;
            this.BreakRadio.CheckedChanged += new System.EventHandler(this.BreakRadio_CheckedChanged);
            // 
            // lunchRadio
            // 
            this.lunchRadio.AutoSize = true;
            this.lunchRadio.Location = new System.Drawing.Point(43, 47);
            this.lunchRadio.Name = "lunchRadio";
            this.lunchRadio.Size = new System.Drawing.Size(55, 17);
            this.lunchRadio.TabIndex = 1;
            this.lunchRadio.TabStop = true;
            this.lunchRadio.Text = "Lunch";
            this.lunchRadio.UseVisualStyleBackColor = true;
            this.lunchRadio.CheckedChanged += new System.EventHandler(this.lunchRadio_CheckedChanged);
            // 
            // dinnerRadio
            // 
            this.dinnerRadio.AutoSize = true;
            this.dinnerRadio.Location = new System.Drawing.Point(43, 70);
            this.dinnerRadio.Name = "dinnerRadio";
            this.dinnerRadio.Size = new System.Drawing.Size(56, 17);
            this.dinnerRadio.TabIndex = 2;
            this.dinnerRadio.TabStop = true;
            this.dinnerRadio.Text = "Dinner";
            this.dinnerRadio.UseVisualStyleBackColor = true;
            this.dinnerRadio.CheckedChanged += new System.EventHandler(this.dinnerRadio_CheckedChanged);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(43, 128);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(146, 46);
            this.start.TabIndex = 3;
            this.start.Text = "Start Meal";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // NewMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.start);
            this.Controls.Add(this.dinnerRadio);
            this.Controls.Add(this.lunchRadio);
            this.Controls.Add(this.BreakRadio);
            this.Name = "NewMeal";
            this.Text = "NewMeal";
            this.Load += new System.EventHandler(this.NewMeal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton BreakRadio;
        private System.Windows.Forms.RadioButton lunchRadio;
        private System.Windows.Forms.RadioButton dinnerRadio;
        private System.Windows.Forms.Button start;
    }
}