/*
 * Display Predictions Form for Lab 1
 * 
 * Allows admin to display predictions for future meals
 * Admin can choose to predict by day, week or month in advance
 * Admin can export the results to excel.
 * 
 * Objects: (Name - Description)
 * 
 * day - radio button for admin to choose day
 * week - radio button for admin to choose week
 * month - radio button for admin to choose month
 * label1 thru 7 - labels for the predictions
 *               - text will change based on which radio button is selected
 *               - all 7 may not be visible
 * pred1 thru 7 - prediction values
 *              - all 7 may not be visible
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
    public partial class Predictions : Form
    {
        public Predictions()
        {
            InitializeComponent();
        }
    }
}
