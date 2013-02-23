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

            //To Remove 'Ding' On Enter
           // AcceptButton = new Button();
           // CancelButton = new Button();

            
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



        private void UEnter_Load(object sender, EventArgs e)
        {

        }

        private void UIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                access.Text = "Granted Son!";
                access.ForeColor = Color.Green;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            access.Text = "Scan Card";
            access.ForeColor = Color.Black;
            UIDText.Text = "";
            timer1.Stop();
        }

        private void UPinText_TextChanged(object sender, EventArgs e)
        {

        }

        private void UPinText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                access.Text = "Granted";
                access.ForeColor = Color.Green;
                timer1.Start();
            }
            else
                e.Handled = true;

        }


        private void UNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                access.Text = "Granted";
                access.ForeColor = Color.Green;
                timer1.Start();
            }
        }

        private void UIDText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        

    }
}
