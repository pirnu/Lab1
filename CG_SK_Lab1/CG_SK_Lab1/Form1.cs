using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CG_SK_Lab1
{
    public partial class UEnter : Form
    {
        public UEnter()
        {
            InitializeComponent();
            this.ActiveControl = UIDText;
            
        }

        

        private void AButton_Click(object sender, EventArgs e)
        {
            // Make admin login visible
            ANameLabel.Visible = true;
            ANameText.Visible = true;
            APassLabel.Visible = true;
            APassText.Visible = true;
            ALogin.Visible = true;
        }

        private void ALogin_Click(object sender, EventArgs e)
        {
            // Validate admin
            // Make admin menu visible
            AMenuLabel.Visible = true;
            ADispRep.Visible = true;
            ADispPred.Visible = true;
            AEnroll.Visible = true;
            AChangePass.Visible = true;
        }
    }
}
