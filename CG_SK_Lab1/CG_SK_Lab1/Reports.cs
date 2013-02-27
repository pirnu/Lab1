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
        public string query;
        public string sheet;
        public Reports()
        {
            InitializeComponent();
            sheet = "Attendance";
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
            sheet = "Attendance";
        }

        private void cRadio_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            query = "Select * from [Attendance$]";
            sheet = "Attendance";

            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close();
        }

        private void mRadio_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;

        }

        private void cadetBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void eRadio_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            query = "Select * from [Excusals$]";
            sheet = "Excusals";
            
            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close();
        }

        private void multRadio_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            query = "Select * from [Multiples$]";
            sheet = "Multiples";

            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close();
        }

        private void nameText_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && nameText.Text != "")
            {
                string cadet = nameText.Text;
                // filename for database - must be in bin/debug folder
                string file = "testdb.xlsx";
                query = "Select * from [" + sheet + "$] Where Name = '"+cadet+"'";
                // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
                // received lots of help from this link
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
                DataSet myExcelData = new DataSet();

                conn.Open();

                //should be able to get this to change using radio buttons
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
                myDataAdapter.Fill(myExcelData);

                dataGridView1.DataSource = myExcelData.Tables[0];

                conn.Close();
            }       
        }

        private void search_Click(object sender, EventArgs e)
        {
            string m1 = month1.Text;
            string d1 = day1.Text;
            string y1 = year1.Text;

            string m2 = month2.Text;
            string d2 = day2.Text;
            string y2 = year2.Text;

            string date1 = m1+"/"+d1+"/"+y1+" 12:00:00 AM";
            string date2 = m2+"/"+d2+"/"+y2+" 12:00:00 AM";

            string cadet = nameText.Text;

            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            // string workbookpath = "C:\\Users\\Network Student\\Documents\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\Debug\\testdb"; //path//path for github
            string workbookpath = "C:\\Users\\Network Student\\Documents\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            //string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //Path for Mac-210
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Attendance";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            string cellname = "B2";                                                         // First cell with scanned ID #
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string code = xlcell.Value.ToString();

            if (m1 == "" || m2 == "" || d1 == "" || d2 == "" || y1 == "" || y2 == "")
            {
                //Put some sort of Error onto screen
            }
            else
            {
                if (nameText.Text == "")
                {
                    query = "Select * from [" + sheet + "$] Where TimeStamp Between " + date1 + " And " + date2 + " select ";
                }
                else
                {
                    query = "Select * from [" + sheet + "$] Where TimeStamp Between '" + date1 + "' And '" + date2 + "' And Name = '"+cadet+"'";
                }
                // filename for database - must be in bin/debug folder
                string file = "testdb.xlsx";
                // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
                // received lots of help from this link
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
                DataSet myExcelData = new DataSet();

                conn.Open();

                //should be able to get this to change using radio buttons
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
                myDataAdapter.Fill(myExcelData);

                dataGridView1.DataSource = myExcelData.Tables[0];

                conn.Close();
            }
        }
    }
}
