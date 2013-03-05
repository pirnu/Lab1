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
        public string ID;
        public Reports()
        {
            InitializeComponent();
            nameLabel.Visible = true;
            mealLabel.Visible = false;
            ID = "Name";
            sheet = "Attendance";
            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select Name,Timestamp from [Attendance$]", conn);
        //    myDataAdapter.Fill(myExcelData);

       //     dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            nameLabel.Visible = true;
            mealLabel.Visible = false;
            sheet = "Attendance";
            ID = "Name";
            disp_num_cadets();
        }

        private void cRadio_CheckedChanged(object sender, EventArgs e)
        {
            ID = "Name";
            nameLabel.Visible = true;
            mealLabel.Visible = false;
            query = "Select Name,Timestamp, Meal from [Attendance$]";
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
            nameLabel.Visible = false;
            mealLabel.Visible = true;
            query = "Select Meal,Date,Attendance from [Totals$]";
            sheet = "Totals";
            ID = "Meal";

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

        private void cadetBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void eRadio_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Visible = true;
            mealLabel.Visible = false;
            query = "Select Name, Excusal, Day from  [Excusals$]";
            sheet = "Excusals";
            ID = "Name";
            
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
            nameLabel.Visible = true;
            mealLabel.Visible = false;
            query = "Select Name, TimeStamp, Reason from [Multiples$]";
            sheet = "Multiples";
            ID = "Name";

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
                query = "Select * from [" + sheet + "$] Where "+ID+" = '"+cadet+"'";
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

            string date1 = m1+"/"+d1+"/"+y1;
            string date2 = m2+"/"+d2+"/"+y2;

            string cadet = nameText.Text;

            // AFTER RETRIEVING ALL INFO, WE NEED TO CONVERT INTO EXCEL AND GRAB ITS FORMATTED VERSION

            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            // string workbookpath = "C:\\Users\\Network Student\\Documents\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\Debug\\testdb"; //path//path for github
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            //string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //Path for Mac-210
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = sheet;                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            //input dates
            xlworksheet.Cells[2, 6] = date1;
            xlworksheet.Cells[3, 6] = date2;
            //change form
            xlworksheet.Cells[2, 6].NumberFormat = "General";
            xlworksheet.Cells[3, 6].NumberFormat = "General";
            //collect dates and store back into value
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("F2", "F2");    // store in xlcell
            date1 = xlcell.Value.ToString();                                          // store value in xlcell as a string
            xlcell = (Excel.Range)xlworksheet.get_Range("F3", "F3");    // store in xlcell
            date2 = xlcell.Value.ToString();

            //now we search it against those values... our database will need to autoadd the "excelform" column when we enroll cadets..i'll fix that soon.

            if (m1 == "" || m2 == "" || d1 == "" || d2 == "" || y1 == "" || y2 == "")
            {
                blank.Visible = true; // Put error message for blank
            }
            else
            {
                blank.Visible = false;
                if (nameText.Text == "")
                {
                    if (sheet == "Attendance")      //Cadet Lookup
                        query = "Select Name, TimeStamp from [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2;
                    else if (sheet == "Totals")     //Meal lookup
                        query = "Select Meal, Date, Attendance from [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2;
                    else if (sheet == "Excusals")   //Date Lookup on Excusal
                        query = "Select Name, Excusal, Day from  [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2;
                    else                            // Cadet Signed in Multiple Times
                        query = "Select Name, TimeStamp, Reason from [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2;
                }
                  
                else
                {
                    if (sheet == "Attendance")      //Cadet Lookup
                        query = "Select Name, Timestamp from [" + sheet + "$] Where excelform >= " + date1 + " And  excelform <= " + date2 + " And Name = '" + cadet + "'";
                    else if (sheet == "Totals")     //Meal lookup
                        query = "Select Meal, Date, Attendance from [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2 + " And Meal = '" + cadet + "'";
                    else if (sheet == "Excusals")   //Cadet Lookup on Excusal
                        query = "Select Name, Excusal, Day from  [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2 + " And Name = '" + cadet + "'";
                    else                            // Cadet Signed in Multiple Times
                        query = "Select Name, TimeStamp, Reason from [" + sheet + "$] Where excelform >= " + date1 + " And excelform <= " + date2 + " And Name = '" + cadet + "'";
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

                xlWorkBook.Save();
                xlWorkBook.Close();
            }
        }

        private void disp_num_cadets()
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            // string workbookpath = "C:\\Users\\Network Student\\Documents\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\Debug\\testdb"; //path//path for github
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            //string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //Path for Mac-210
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "CurrentMeal";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("E2", "E2");
            double cadetnumber = xlcell.Value;
            numcadets.Text = cadetnumber.ToString();

            xlWorkBook.Save();
            xlWorkBook.Close();
            
        }
    }
}
