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
using System.Data.OleDb;

namespace CG_SK_Lab1
{
    public partial class Predictions : Form
    {
        public Predictions()
        {
            InitializeComponent();
        }

        private void Predictions_Load(object sender, EventArgs e)
        {
            make_prediction();
        }

        private void day_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label1.Text = "Breakfast";
            label2.Text = "Lunch";
            label3.Text = "Dinner";
            label4.Text = "Total";
        }

        private void week_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;

            label1.Text = "Sunday";
            label2.Text = "Monday";
            label3.Text = "Tuesday";
            label4.Text = "Wednesday";
            label1.Text = "Breakfast";
            label2.Text = "Lunch";
            label3.Text = "Dinner";
            label4.Text = "Total";
        }

        private void make_prediction()
        {
            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            string query;
            query = "SELECT AVG(Attendance where Day = 'Sunday' AND Meal = 'breakfast') AS Breakfast FROM [Totals$]";


            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only
        }

        private void button1_Click(object sender, EventArgs e)
        {
            make_prediction();
        }


    }
}
