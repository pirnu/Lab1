/*
 * Change Password Form for Lab 1
 * 
 * Allows admin to change the pin of a student who forgot theirs.
 * Note: username of student must already exist.
 * 
 * Objects: (Name - Description)
 * 
 * nameText - Textbox for username
 * pinText - Textbox for pin
 * Feedback - Label at bottom to tell admin if change was made or not
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
using Excel = Microsoft.Office.Interop.Excel;

namespace CG_SK_Lab1
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        public bool matchingpwds = false;
        System.Drawing.Image checkmark = CG_SK_Lab1.Properties.Resources.checkmark;
        System.Drawing.Image error = CG_SK_Lab1.Properties.Resources.error;
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            pstatus.Visible = false;
            nstatus.Visible = false;
            matchingpwds = false;
            this.ActiveControl = nameText;
        }

        private void nameText_Leave(object sender, EventArgs e)
        {
            check_database_name();
        }

        private void check_database_name() 
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            //string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";//path
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";
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
                    nstatus.Image = checkmark;
                    
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
            if (!match) // Admin Name was not found
            {
                nstatus.Visible = true;
                nstatus.Image = error;
               // this.ActiveControl = nameText;                                             // Put Cusor in admin username field
            }
        }

        private void verified_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_passwords();
                if (matchingpwds)
                {
                    updatepassword();
                    this.Close();
                }

            }
        }

        private void check_passwords()
        {
            if (pinText.Text == verified.Text)
            {
                pstatus.Visible = true;
                pstatus.Image = checkmark;
                matchingpwds = true;
            }
            else
            {
                pstatus.Visible = true;
                pstatus.Image = error;
                matchingpwds = false;
            }
        }
        private void updatepassword()
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            //string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";//path
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";
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
                    nstatus.Image = checkmark;
                    xlApp.Cells[i, 2] = verified.Text;                                         // set value to new attend
                    xlWorkBook.Save(); 

                }
                else // Cell is not name
                {
                    i++;                                                                    // Move down a row
                    cellname = "A" + i.ToString();                                          // Set next cell
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);        // Get name
                    if (xlcell.Value != null)                                               // if its not empty
                    name = xlcell.Value.ToString();                                         // set as a string
                }
            }
            if (!match) // Admin Name was not found
            {
                nstatus.Visible = true;
                nstatus.Image = error;
            }
        }

        private void verified_TextChanged(object sender, EventArgs e)
        {
            check_passwords();
        }

        private void commit_Click(object sender, EventArgs e)
        {
            check_passwords();
            if (matchingpwds)
            {
                updatepassword();
                this.Close();
            }
        }

    }
}
