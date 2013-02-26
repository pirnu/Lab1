/*
 * Display Reports Form for Lab 1
 * 
 * Allows admin to display old reports from database.
 * Admin can choose which meal to sort reports by time, cadet or meal
 * 
 * Objects: (Name - Description)
 * 
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
using Excel = Microsoft.Office.Interop.Excel;

namespace CG_SK_Lab1
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [Attendance$]", conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void cRadio_CheckedChanged(object sender, EventArgs e)
        {
            cadetBox.Visible = true;
            mealBox.Visible = false;
            dataGridView1.Visible = true;
        }

        private void mRadio_CheckedChanged(object sender, EventArgs e)
        {
            cadetBox.Visible = false;
            mealBox.Visible = true;
            dataGridView1.Visible = false;
        }

        private void cadetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cadetBox.Text == "Week")
            {
                
            }
            else if (cadetBox.Text == "Month")
            {
            }
            else
            {
            }
        }


    }
}
