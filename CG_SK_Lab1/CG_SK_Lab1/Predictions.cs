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
using Excel = Microsoft.Office.Interop.Excel;

namespace CG_SK_Lab1
{
    public partial class Predictions : Form
    {
        public Predictions()
        {
            InitializeComponent();
        }

        public string workbookpath = UEnter.workbookpath;

        private void Predictions_Load(object sender, EventArgs e)
        {
            makeday_prediction();
            makemonth_prediction();
        }

        private void makeday_prediction()
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Totals";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 
            Excel.Range meal = (Excel.Range)xlworksheet.get_Range("A97", "A97");
            string mealname = meal.Value;
            string Day = System.DateTime.Now.DayOfWeek.ToString();

            string mealname2;
            string mealname3;
            string Day2;
            string Day3;
            if (mealname == "breakfast")
            {
                mealname2 = "lunch";
                mealname3 = "dinner";
                Day2 = System.DateTime.Now.DayOfWeek.ToString();
                Day3 = System.DateTime.Now.DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                mealname2 = "dinner";
                mealname3 = "breakfast";
                Day2 = System.DateTime.Now.DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                mealname2 = "breakfast";
                mealname3 = "lunch";
                Day2 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
            }

            meal1.Text = mealname;
            meal2.Text = mealname2;
            meal3.Text = mealname3;

            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            string query;
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '"+ mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname2 + " FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname3 + " FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView1.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            Day = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
            if (mealname == "breakfast")
            {
                Day2 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                Day2 = System.DateTime.Now.AddDays(1).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                Day2 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
            }
            myExcelData = new DataSet();
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '" + mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance))  FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance))  FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView2.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            Day = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
            if (mealname == "breakfast")
            {
                Day2 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                Day2 = System.DateTime.Now.AddDays(2).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                Day2 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
            }
            myExcelData = new DataSet();
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '" + mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView3.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            Day = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
            if (mealname == "breakfast")
            {
                Day2 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                Day2 = System.DateTime.Now.AddDays(3).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                Day2 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
            }
            myExcelData = new DataSet();
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '" + mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname2 + " FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname3 + " FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView4.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            Day = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
            if (mealname == "breakfast")
            {
                Day2 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                Day2 = System.DateTime.Now.AddDays(4).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                Day2 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
            }
            myExcelData = new DataSet();
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '" + mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname2 + " FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname3 + " FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView5.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            Day = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
            if (mealname == "breakfast")
            {
                Day2 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                Day2 = System.DateTime.Now.AddDays(5).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                Day2 = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
            }
            myExcelData = new DataSet();
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '" + mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname2 + " FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname3 + " FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView6.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            Day = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
            if (mealname == "breakfast")
            {
                Day2 = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
            }
            else if (mealname == "lunch")
            {
                Day2 = System.DateTime.Now.AddDays(6).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(7).DayOfWeek.ToString();
            }
            else // (mealname == "dinner")
            {
                Day2 = System.DateTime.Now.AddDays(7).DayOfWeek.ToString();
                Day3 = System.DateTime.Now.AddDays(7).DayOfWeek.ToString();
            }
            myExcelData = new DataSet();
            query = "SELECT ROUND(AVG(Attendance)) AS " + Day + " FROM [Totals$] where Day = '" + Day + "' AND Meal = '" + mealname + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname2 + " FROM [Totals$] where Day = '" + Day2 + "' AND Meal = '" + mealname2 + "'" +
                    "UNION ALL SELECT ROUND(AVG(Attendance)) AS " + mealname3 + " FROM [Totals$] where Day = '" + Day3 + "' AND Meal = '" + mealname3 + "'";


            conn.Open();

            //should be able to get this to change using radio buttons
            myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView7.DataSource = myExcelData.Tables[0];
            conn.Close(); //scotty uncommented - needed to prevent it from staying open.. and becoming read only

            xlWorkBook.Save();
            xlWorkBook.Close();
        }

        private void makemonth_prediction()
        {
            string query;
            // filename for database - must be in bin/debug folder
            string file = "testdb.xlsx";

            //Month
            query = "SELECT ROUND(AVG(Attendance))*31 AS NextMonth FROM [Totals$]";
            // http://stackoverflow.com/questions/512143/error-could-not-find-installable-isam
            // received lots of help from this link
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + file + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"");
            DataSet myExcelData = new DataSet();

            conn.Open();

            //should be able to get this to change using radio buttons
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(query, conn);
            myDataAdapter.Fill(myExcelData);

            dataGridView8.DataSource = myExcelData.Tables[0];

            conn.Close();
        }


    }
}
