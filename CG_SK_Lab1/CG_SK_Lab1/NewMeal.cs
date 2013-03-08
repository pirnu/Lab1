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
        public string workbookpath = UEnter.workbookpath;
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
            update_meal_log();
            update_long_term();
            this.Close();
        }

        private void update_meal_log()
        {
            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "CurrentMeal";                                             // Set current sheet to be Attendance
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("E2", "E2");            // store in xlcell
            string attendance = xlcell.Value.ToString();                                    // store value in xlcell as a string
            currentSheet = "Totals";
            xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);
            //http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/920180bf-1c84-40f7-b547-ba9532e309cd
            Excel.Range range1;
            Excel.Range range2;
            Excel.Range range3;
            Excel.Range range4;
            Excel.Range range5;

            string block1;
            string block2;
            string block3;
            string block4;
            string block5;
            int k;

            xlworksheet.Cells[97, 3] = attendance;

            for (int i = 2; i <= 96; i++)
            {
                k = i + 1;
                block1 = "A" + k.ToString();
                block2 = "B" + k.ToString();
                block3 = "C" + k.ToString();
                block4 = "D" + k.ToString();
                block5 = "E" + k.ToString();

                range1 = xlworksheet.get_Range(block1, block1);
                range2 = xlworksheet.get_Range(block2, block2);
                range3 = xlworksheet.get_Range(block3, block3);
                range4 = xlworksheet.get_Range(block4, block4);
                range5 = xlworksheet.get_Range(block5, block5);

                xlworksheet.Cells[i, 1] = range1.Value.ToString();
                xlworksheet.Cells[i, 2] = range2.Value.ToString();
                xlworksheet.Cells[i, 3] = range3.Value.ToString();
                xlworksheet.Cells[i, 4] = range4.Value.ToString();
                xlworksheet.Cells[i, 5] = range5.Value.ToString();

            }

            xlworksheet.Cells[97, 1] = meal;
            xlworksheet.Cells[97, 2] = DateTime.Today;
            xlworksheet.Cells[97, 3] = "To be determined";
            xlworksheet.Cells[97, 4] = DateTime.Today;
            xlworksheet.Cells[97, 4].NumberFormat = "General";
            xlworksheet.Cells[97, 5] = DateTime.Now.DayOfWeek.ToString();


            xlWorkBook.Save();
            xlWorkBook.Close();
        }
        public void update_long_term()
        {
            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "CurrentMeal";                                             // Set current sheet to be Attendance
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("E2", "E2");            // store in xlcell
            string attend = xlcell.Value.ToString();                                    // store value in xlcell as a string

            currentSheet = "Attendance";
            Excel.Worksheet xlworksheet2 = (Excel.Worksheet)xlsheet.get_Item(currentSheet);
            Excel.Range xlcell2 = (Excel.Range)xlworksheet2.get_Range("E2", "E2");            // store in xlcell

            double attendance = Convert.ToDouble(attend);


            string block1;
            string block2;
            string paste1;
            string paste2;

            // get first range of people
            block1 = "A2";
            block2 = "D" + (attendance+1).ToString();

            // find out how many people there are
            string allp = xlcell2.Value.ToString();
            double allpeople = Convert.ToDouble(allp) + 2;

            // get second range of people
            paste1 = "A" + allpeople.ToString();
            paste2 = "D" + (allpeople + attendance).ToString();

            // get entire range from currentMeal worksheet
            Excel.Range selCell1 = (Excel.Range)xlworksheet.get_Range(block1, block2);
            // past into long term attendance sheet
            Excel.Range selCell2 = (Excel.Range)xlworksheet2.get_Range(paste1, paste2);
            selCell1.Cut(selCell2);

            xlWorkBook.Save();
            xlWorkBook.Close();
        }

    }
}
