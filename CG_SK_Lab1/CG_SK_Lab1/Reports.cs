/*
 * Display Reports Form for Lab 1
 * 
 * Allows admin to display old reports from database.
 * Admin can choose which meal to sort reports by time, cadet or meal
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
        public string query;    // string to query SQL
        public string sheet;    // current sheet being used
        public string ID;       // cadet or meal name
        public string workbookpath = UEnter.workbookpath;

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

            // Immediatly open the Name,Timestamp columns from the Attendance sheet
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select Name,Timestamp from [Attendance$]", conn);


            conn.Close();
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
            // connect to database
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

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

            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];

            conn.Close();

        }

        private void eRadio_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Visible = true;
            mealLabel.Visible = false;
            query = "Select Name, Excusal, Day from  [Excusals$]";
            sheet = "Excusals";
            ID = "Name";
            
            string file = "testdb.xlsx";

            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

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

            string file = "testdb.xlsx";
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

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
                string file = "testdb.xlsx";
                query = "Select * from [" + sheet + "$] Where "+ID+" = '"+cadet+"'";
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
                DataSet myExcelData = new DataSet();

                conn.Open();

                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
                myDataAdapter.Fill(myExcelData);

                dataGridView1.DataSource = myExcelData.Tables[0];

                conn.Close();
            }       
        }

        private void search_Click(object sender, EventArgs e)
        {
            // Get dates from text boxes
            string m1 = month1.Text;
            string d1 = day1.Text;
            string y1 = year1.Text;

            string m2 = month2.Text;
            string d2 = day2.Text;
            string y2 = year2.Text;

            string date1 = m1+"/"+d1+"/"+y1;
            string date2 = m2+"/"+d2+"/"+y2;

            // get cadet name if entered
            string cadet = nameText.Text;

            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
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

            // Display error message if any field is left blank
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

                string file = "testdb.xlsx";

                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
                DataSet myExcelData = new DataSet();

                conn.Open();

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

        private void fromCal_Click(object sender, EventArgs e)
        {
            // show appropriate calendar
            monthCal1.Visible = true;
            monthCal2.Visible = false;
        }

        private void monthCal2_DateChanged(object sender, DateRangeEventArgs e)
        {
            // put calendar day into appropriate text boxes
            day2.Text = monthCal2.SelectionRange.Start.Date.Day.ToString();
            month2.Text = monthCal2.SelectionRange.Start.Date.Month.ToString();
            year2.Text = monthCal2.SelectionRange.Start.Date.Year.ToString();
        }

        private void toCal_Click(object sender, EventArgs e)
        {
            monthCal2.Visible = true;
            monthCal1.Visible = false;
        }

        private void monthCal1_DateChanged(object sender, DateRangeEventArgs e)
        {
            day1.Text = monthCal1.SelectionRange.Start.Date.Day.ToString() ;
            month1.Text = monthCal1.SelectionRange.Start.Date.Month.ToString();
            year1.Text = monthCal1.SelectionRange.Start.Date.Year.ToString();
        }

        private void monthCal1_Leave(object sender, EventArgs e)
        {
            // turn calendars invisible when left
            monthCal1.Visible = false;
        }

        private void monthCal2_Leave(object sender, EventArgs e)
        {
            monthCal2.Visible = false;
        }

        private void Reports_Enter(object sender, EventArgs e)
        {
            // turn calendar invisible if something else is clicked
            monthCal1.Visible = false;
            monthCal2.Visible = false;
        }

    }
}
