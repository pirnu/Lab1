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
    public partial class EnrollCadet : Form
    {
        System.Drawing.Image checkmark = CG_SK_Lab1.Properties.Resources.checkmark;
        System.Drawing.Image error = CG_SK_Lab1.Properties.Resources.error;
        public EnrollCadet()
        {
            InitializeComponent();
        }
        public bool newname = false;
        public bool newcode = false;
        public bool validpin = false;

        private void EnrollCadet_Load(object sender, EventArgs e)
        {
            newname = false;
            newcode = false;
            validpin = false;
        }

        private void nameText_Leave(object sender, EventArgs e)
        {
            newname = false;
            nstatus.Image = error;
            if (nameText.Text != "")
                check_for_name();
        }

        private void check_for_name()
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            //string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";//path for github
            //string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb"; //path for Mac-228
            string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb"; //Path for Mac-210
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Users";                                                  // Set current sheet to be Administrators
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            string cellname = "A2";                                                         // First cell with Cadet Name
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string name = xlcell.Value.ToString();                                          // store value in xlcell as a string
            bool match = false;                                                             // initialize match as not found
            int i = 2;                                                                      // current row is two
            while (xlcell.Value != null && !match)                                          // while its not the bottom of the db and a match has not been found
            {

                if (nameText.Text == name)                                                 // If cadet name is found
                {
                    match = true;
                    nstatus.Visible = true;
                    nstatus.Image = error;

                }
                else // Cell is not name
                {
                    i++;                                                                    // Move down a row
                    cellname = "A" + i.ToString();                                          // Set next cell
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);        // Get name
                    if (xlcell.Value != null)                                               // if its not empty
                        name = xlcell.Value.ToString();                                     // set as a string
                }
            }
            if (!match) // Cadet Name was not found
            {
                nstatus.Visible = true;
                nstatus.Image = checkmark;
                newname = true;
            }
        }

        private void bcText_Leave(object sender, EventArgs e)
        {
            newcode = false;
            bstatus.Image = error;
            if (bcText.Text != "")
                check_for_code();
        }

        private void check_for_code()
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            //string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";//path for github
            //string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb"; //path for Mac-228
            string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb"; //Path for Mac-210
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Users";                                                  // Set current sheet to be Administrators
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            string cellname = "C2";                                                         // First cell with Cadet Name
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string code = xlcell.Value.ToString();                                          // store value in xlcell as a string
            bool match = false;                                                             // initialize match as not found
            int i = 2;                                                                      // current row is two
            while (xlcell.Value != null && !match)                                          // while its not the bottom of the db and a match has not been found
            {

                if (bcText.Text == code)                                                 // If cadet name is found
                {
                    match = true;
                    bstatus.Visible = true;
                    bstatus.Image = error;

                }
                else // Cell is not name
                {
                    i++;                                                                    // Move down a row
                    cellname = "C" + i.ToString();                                          // Set next cell
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);        // Get name
                    if (xlcell.Value != null)                                               // if its not empty
                        code = xlcell.Value.ToString();                                     // set as a string
                }
            }
            if (!match) // Cadet Name was not found
            {
                bstatus.Visible = true;
                bstatus.Image = checkmark;
                newcode = true;
            }
        }

        private void pinText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (pinText.Text != "")
                    validpin = true;
                else
                    validpin = false;
                if (validpin && newcode && newname)
                {
                    //Add Cadet to file
                }
                else
                {
                    directions.Text = "Your Form is not Complete";
                    directions.ForeColor = Color.Red;
                }   
            }
        }

        private void CloseEnroll_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
