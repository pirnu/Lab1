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
    public partial class Already_Signed_In : Form
    {      
        public Already_Signed_In()
        {
            InitializeComponent();
            
            //Hide Admin Priviledges
            aname.Visible = false;
            apass.Visible = false;
            ANameText.Visible = false;
            APassText.Visible = false;
            enter.Visible = false;
            overrode = false;

        }

        public bool overrode = false; // Admin has not overridden the Error

        public bool getstatus()       //Check if Admin overrode error
        {
            return overrode;
        }

        private void Already_Signed_In_Load(object sender, EventArgs e)
        {
            // Show Admin Priviledges
            aname.Visible = false;
            apass.Visible = false;
            ANameText.Visible = false;
            APassText.Visible = false;
            enter.Visible = false;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            overrode = false;
            this.Close();
        }

        private void aoverride_Click(object sender, EventArgs e)
        {
            // Show Admin Priviledges
            aname.Visible = true;
            apass.Visible = true;
            ANameText.Visible = true;
            APassText.Visible = true;
            enter.Visible = true;
        }

        // Admin presses Enter in Name Field
        private void ANameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                check_database_admin(); //checks database with typed input
        }

        //Admin presses Enter in Password Field
        private void APassText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_admin(); //checks database with typed input
            }
        }

        // Admin Clicks Override
        private void enter_Click(object sender, EventArgs e)
        {
                check_database_admin(); //checks database with typed input
        }

        private void check_database_admin() //check with name and pin
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\CADET14297\\Documents\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\Debug\\testdb";//path
            //string workbookpath = "C:\\Users\\swkenney\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Admin";                                                  // Set current sheet to be Administrators
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            string cellname = "A2";                                                         // First cell with Admin Name
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string name = xlcell.Value.ToString();                                          // store value in xlcell as a string
            bool match = false;                                                             // initialize match as not found
            int i = 2;                                                                      // current row is two
            while (xlcell.Value != null && !match)                                          // while its not the bottom of the db and a match has not been found
            {

                if (ANameText.Text == name)                                                 // If admin name is found
                {
                    cellname = "B" + i.ToString();                                          // Change cell to check password
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    string pin = xlcell.Value.ToString();                                   // save Password to pin
                    if (APassText.Text == pin)                                              // If pin also matches
                    {
                        match = true;                                                       // Admin Found
                        overrode = true;                                                    // Set Overrode to true

                        // Hide Admin Priviledges
                        aname.Visible = false;
                        apass.Visible = false;
                        ANameText.Visible = false;
                        APassText.Visible = false;
                        enter.Visible = false;
                        ANameText.Text = "";                                                // Clear Credentials
                        APassText.Text = "";

                        this.Close();                                                       // Close Form
                    }
                    else // Wrong Password
                    {
                        
                        status.Text = "Incorrect Password";                                 // Show Error
                        status.Visible = true;
                        status.ForeColor = Color.Red;
                        timer1.Start();
                        match = true;                                                       // Admin Name Found
                        APassText.Text = "";                                                // Clear Password Field
                        this.ActiveControl = APassText;                                     // Put Cursor in the Password field
                    }
                }
                else // Not the Admin Name
                {
                    i++;                                                                    // Check Next Row
                    cellname = "A" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    if (xlcell.Value != null)                                               // If Cell isn't empty
                        name = xlcell.Value.ToString();                                     // Turn into string, set in name
                }
            }
            if (!match) // If name is never found
            {
                
                status.Text = "Admin Does Not Exist";                                        // Show Error
                status.Visible = true;
                status.ForeColor = Color.Red;
                timer1.Start();
                ANameText.Text = "";                                                         // Clear fields
                APassText.Text = "";
                this.ActiveControl = ANameText;                                              //Put Cursor in the username field
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Hide Error
            status.Visible = false;
            timer1.Stop();
        }
    
    }

}
