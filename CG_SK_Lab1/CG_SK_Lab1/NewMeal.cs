using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CG_SK_Lab1
{
    public partial class NewMeal : Form
    {
        public string meal;
        public NewMeal()
        {
            InitializeComponent();
        }

        private void BreakRadio_CheckedChanged(object sender, EventArgs e)
        {
            meal = "breakfast";
        }

        private void lunchRadio_CheckedChanged(object sender, EventArgs e)
        {
            meal = "lunch";
        }

        private void dinnerRadio_CheckedChanged(object sender, EventArgs e)
        {
            meal = "dinner";
        }

        private void start_Click(object sender, EventArgs e)
        {
            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            // string workbookpath = "C:\\Users\\Network Student\\Documents\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\Debug\\testdb"; //path//path for github
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            //string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //Path for Mac-210
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Attendance";                                             // Set current sheet to be Attendance
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("E2", "E2");            // store in xlcell
            string attendance = xlcell.Value.ToString();                                    // store value in xlcell as a string
            currentSheet = "Totals";
            xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet); 
            //http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/920180bf-1c84-40f7-b547-ba9532e309cd
            Excel.Range range = xlworksheet.get_Range("A2:E2", Type.Missing);
            range.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);

            xlworksheet.Cells[97, 1] = meal;
            xlworksheet.Cells[97, 2] = DateTime.Today;
            xlworksheet.Cells[97, 4] = DateTime.Today;
            xlworksheet.Cells[97, 4].NumberFormat = "General";
            xlworksheet.Cells[97, 5] = DateTime.Now.DayOfWeek.ToString();
            xlworksheet.Cells[96, 3] = attendance;

            xlWorkBook.Save();
            xlWorkBook.Close();
        }
    }
}
