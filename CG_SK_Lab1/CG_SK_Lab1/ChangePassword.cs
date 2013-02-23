/*
 * Change Password Form for Lab 1
 * 
 * Allows admin to change the pin of a student who forgot theirs.
 * Note: username of student must already exist.
 * 
 * Objects: (Name - Description)
 * 
 * nameText - Textbox for username
 * pinText - Textbox for pin
 * Feedback - Label at bottom to tell admin if change was made or not
 * 
 * */

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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }


    }
}
