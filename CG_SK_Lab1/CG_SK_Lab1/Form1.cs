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
    public partial class UEnter : Form
    {
        //Link all other forms
        public NewMeal nm = new NewMeal();
        public ChangePassword change = new ChangePassword();
        public Reports reports = new Reports();
        public Predictions predict = new Predictions();
        public EnrollCadet enroll = new EnrollCadet();
        public Already_Signed_In asi = new Already_Signed_In();
        public bool AdminActive = false;
        public static string denied; // reason for denial to sign in
        System.Drawing.Image checkmark = CG_SK_Lab1.Properties.Resources.checkmark;
        System.Drawing.Image error = CG_SK_Lab1.Properties.Resources.error;
        //Initial-Conditions
        public UEnter()
        {
            InitializeComponent();
            this.ActiveControl = UIDText;
        }

        //When Admin-Login is clicked.
        private void AButton_Click(object sender, EventArgs e)
        {
            // Make admin login visible
            ANameLabel.Visible = true;
            ANameText.Visible = true;
            APassLabel.Visible = true;
            APassText.Visible = true;
            ALogin.Visible = true;
            adminaccess.Visible = true;
            this.ActiveControl = ANameText;
        }

        //When Log-in (for Admin credentials) is clicked
        private void ALogin_Click(object sender, EventArgs e)
        {
            // Validate admin
            check_database_admin();
            // Make admin menu visible
            if (AdminActive)
            {
                //de-activate sign in fields
                UNameText.ReadOnly = true;
                UPinText.ReadOnly = true;
                UIDText.ReadOnly = true;

                //Show Admin Options
                logout.Visible = true;
                AMenuLabel.Visible = true;
                ADispRep.Visible = true;
                ADispPred.Visible = true;
                AEnroll.Visible = true;
                AChangePass.Visible = true;
                newMeal.Visible = true;
            }

        }

        //When An ID is scanned
        private void UIDText_KeyDown(object sender, KeyEventArgs e)    
        {
            //The scanners last input is Enter, Check Database for Cadets Code
            if (e.KeyCode == Keys.Enter)
                check_database_code();
        }

        //When User presses Enter in name field
        private void UNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                check_database_np(); //checks user database with typed input
        }

        //When User presses Enter in pin field
        private void UPinText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                check_database_np(); //checks user database with typed input
        }

        //When Admin presses Enter in Name Field
        private void ANameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_admin(); //Check Admin Database
                // Make admin menu visible
                if (AdminActive)
                {
                    //Don't allow sign in input
                    UNameText.ReadOnly = true;
                    UPinText.ReadOnly = true;
                    UIDText.ReadOnly = true;
                    
                    //Show Admin Priviledges
                    logout.Visible = true;
                    AMenuLabel.Visible = true;
                    ADispRep.Visible = true;
                    ADispPred.Visible = true;
                    AEnroll.Visible = true;
                    AChangePass.Visible = true;
                    newMeal.Visible = true;
                }
            }
        }

        //When Timer Reaches Max
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Set text back to defaults
            access.Text = "Scan Card";
            adminaccess.Text = "";
            access.ForeColor = Color.Black;

            //Clear the Scan Bar Text
            UIDText.Text = "";
            timer1.Stop();
        }

        // Show Dialog whenever another form link is selected.
        private void ADispRep_Click(object sender, EventArgs e)
        {
            reports.ShowDialog();
        }

        private void ADispPred_Click(object sender, EventArgs e)
        {
            predict.ShowDialog();
        }

        private void AEnroll_Click(object sender, EventArgs e)
        {
            enroll.ShowDialog();
        }

        private void AChangePass_Click(object sender, EventArgs e)
        {
            change.ShowDialog();
        }

        // Check Database with Scanned ID
        private void check_database_code()
        {
            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Users";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            string cellname = "C2";                                                         // First cell with scanned ID #
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string code = xlcell.Value.ToString();                                          // store value in xlcell as a string
            bool match = false;                                                             // initialize match as not found
            int i = 2;      // current row is two
            string cadetname;
            while (xlcell.Value != null && !match)                                          // while its not the bottom of the db and a match has not been found
            {

                if (UIDText.Text == code)                                                   // check if code matches Value
                {
                    cellname = "A" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    cadetname = xlcell.Value;
                    cellname = "D" + i.ToString();                                          // change cell to check attendance
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    double attend = xlcell.Value;                                           // store in attend

                    bool excused = on_excusal(cadetname);
                    if (attend == 0)                                                        // if student has not yet signed in...
                    {
                        if (!excused)
                        {
                            access.Text = "Granted";                                            // Grant Access
                            access.ForeColor = Color.Green;
                            timer1.Start();                                                     // Only show for 1.5 seconds
                            match = true;                                                       // Match has been found

                            //update database
                            attend = attend + 1;                                                  // increase attend by 1
                            xlworksheet.Cells[i, 4] = attend;                                   // set value to new attend
                            xlWorkBook.Save();                                                  // save the change

                            //Sign into meal
                            sign_in_cadet(cadetname);
                            //reset form
                            UPinText.Text = "";
                            UNameText.Text = "";
                            this.ActiveControl = UIDText;                                       // Reset cursor to scan input
                        }
                        else
                        {
                            access.Text = "ON EXCUSAL";                                            // Grant Access
                            access.ForeColor = Color.Red;
                            timer1.Start();                                                     // Only show for 1.5 seconds
                            match = true;                                                       // Match has been found
                            denied = "excusal";
                            asi.ShowDialog();
                            if (asi.getstatus())                                                // If admin allowed override
                            {
                                attend = attend + 1;                                              // Increase attendance by one
                                xlworksheet.Cells[i, 4] = attend;                               // Put value in spreadsheet
                                xlWorkBook.Save();// Save value
                                //Sign into meal
                                sign_in_cadet(cadetname);
                                update_multiples(cadetname);
                                access.Text = "Overide Accepted";                               // Grant Access
                                access.ForeColor = Color.Green;
                                timer1.Start();                                                 // Only show for 1.5 seconds
                            }
                        }

                    }
                    else // if they have already signed in.
                    {
                        access.Text = "Denied";                                             // Deny Access
                        access.ForeColor = Color.Red;
                        timer1.Start();
                        match = true;                                                       // Cadet is in database
                        denied = "signedin";
                        asi.ShowDialog();                                                   // Show form that student has already signed in
                        if (asi.getstatus())                                                // If admin allowed override
                        {
                            attend = attend + 1;                                              // Increase attendance by one
                            xlworksheet.Cells[i, 4] = attend;                               // Put value in spreadsheet
                            xlWorkBook.Save();
                            //Sign into meal
                            sign_in_cadet(cadetname);// Save value
                            update_multiples(cadetname);
                            access.Text = "Overide Accepted";                               // Grant Access
                            access.ForeColor = Color.Green;
                            timer1.Start();                                                 // Only show for 1.5 seconds
                        }
                        UIDText.Text = "";
                        UNameText.Text = "";
                        UPinText.Text = "";
                        this.ActiveControl = UIDText;
                    }

                }
                else // If Current code did not match
                {
                    i++;                                                                    // Move down a row
                    cellname = "C" + i.ToString();                                          // Set next cell
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);        // Get code
                    if (xlcell.Value != null)                                               // if its not empty
                        code = xlcell.Value.ToString();                                     // set as a string
                }
            }
            if (!match) // If ID # was not found
            {
                access.Text = "User Does Not Exist";                                        // Display Why Denied
                access.ForeColor = Color.Red;
                timer1.Start();                                                             // Show for 1.5 seconds
            }
            xlWorkBook.Save();
            xlWorkBook.Close();
        }

        private void check_database_np() //check with name and pin
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Users";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            string cellname = "A2";                                                         // First cell with Cadet Name
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string name = xlcell.Value.ToString();                                          // store value in xlcell as a string
            bool match = false;                                                             // initialize match as not found
            int i = 2;                                                                      // current row is two
            while (xlcell.Value != null && !match)                                          // while its not the bottom of the db and a match has not been found
            {

                if (UNameText.Text == name)                                                 // check if name matches Value
                {
                    cellname = "B" + i.ToString();                                          // change cell to check Pin
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    string pin = xlcell.Value.ToString();                                   // store in pin
                    cellname = "D" + i.ToString();                                          // check attendance value
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    double attend = xlcell.Value;                                           // change cell to check attendance
                    bool excused = on_excusal(name);
                    if (UPinText.Text == pin)                                               // If Pins Match
                    {
                        if (attend == 0)                                                    // If Not Signed In
                        {
                            if (!excused)
                            {
                                access.Text = "Granted";                                        // Grant Access
                                access.ForeColor = Color.Green;
                                timer1.Start();
                                match = true;                                                   // Match has been Found
                                //update database
                                attend = attend + 1;                                            // Increase attendance by one
                                xlworksheet.Cells[i, 4] = attend;                                     // Put value in spreadsheet
                                xlWorkBook.Save();                                              // Save value
                                //Sign into meal
                                sign_in_cadet(name);
                                //reset form
                                UPinText.Text = "";
                                UNameText.Text = "";
                                this.ActiveControl = UIDText;                                   // Set cursor back to scan ID
                            }
                            else
                            {
                                access.Text = "ON EXCUSAL";                                            // Grant Access
                                access.ForeColor = Color.Red;
                                timer1.Start();                                                     // Only show for 1.5 seconds
                                match = true;                                                       // Match has been found
                                denied = "excusal";
                                asi.ShowDialog();
                                if (asi.getstatus())                                                // If admin allowed override
                                {
                                    attend = attend + 1;                                              // Increase attendance by one
                                    xlworksheet.Cells[i, 4] = attend;                               // Put value in spreadsheet
                                    xlWorkBook.Save();
                                    //Sign into meal
                                    sign_in_cadet(name);// Save value
                                    update_multiples(name);
                                    access.Text = "Overide Accepted";                               // Grant Access
                                    access.ForeColor = Color.Green;
                                    UPinText.Text = "";
                                    UNameText.Text = "";
                                    this.ActiveControl = UIDText;  
                                    timer1.Start();                                                 // Only show for 1.5 seconds
                                }
                            }

                        }
                        else // They already signed in
                        {
                            access.Text = "Denied";                                         // Deny Access
                            access.ForeColor = Color.Red;
                            timer1.Start();
                            match = true;                                                   // They were found
                            denied = "signedin";
                            asi.ShowDialog();                                               // Prompt for admin override
                            if (asi.getstatus())                                            // If admin overrides
                            {
                                attend = attend + 1;                                        // Increase attendance by one
                                xlworksheet.Cells[i, 4] = attend;                                 // Put value in spreadsheet
                                xlWorkBook.Save();                                          // Save value
                                //Sign into meal
                                sign_in_cadet(name);
                                update_multiples(name);
                                access.Text = "Overide Accepted";                           // Grant Access
                                access.ForeColor = Color.Green;
                                timer1.Start();                                             // Only show for 1.5 seconds
                            }
                            UIDText.Text = "";
                            UNameText.Text = "";
                            UPinText.Text = "";
                            this.ActiveControl = UIDText;
                        }

                    }
                    else // Pin Was Wrong
                    {
                        access.Text = "Incorrect Pin!";                                      // Tell them wrong pin
                        access.ForeColor = Color.Red;
                        timer1.Start();
                        match = true;                                                        // Their name was found
                        UPinText.Text = "";                                                  // Clear pin field
                        this.ActiveControl = UPinText;                                       // Set cursor to retype Pin
                    }
                }

                else // The current cell was not their name
                {
                    i++;                                                                    // Move down a row
                    cellname = "A" + i.ToString();                                          // Set next cell
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);        // Get name
                    if (xlcell.Value != null)                                               // if its not empty
                        name = xlcell.Value.ToString();                                     // set as a string
                }
            }

            if (!match) // Didn't find the name
            {
                access.Text = "User Does Not Exist";                                    // Inform of problem
                access.ForeColor = Color.Red;
                timer1.Start();
                UNameText.Text = "";                                                        // Clear Name and Pin
                UPinText.Text = "";
                this.ActiveControl = UNameText;                                             // Set up for re-entering name
            }
            xlWorkBook.Save();
            xlWorkBook.Close();
        }
        private void check_database_admin() //check with name and pin
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
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
                        adminaccess.Text = "Granted";                                       // Grant Admin Access
                        adminaccess.ForeColor = Color.Green;
                        timer1.Start(); 
                        match = true;                                                       // Admin has been found
                        APassText.Text = "";
                        ANameText.Text = "";
                        AdminActive = true;                                                 // Admin is Active
                    }
                    else //Wrong Pin
                    {
                        adminaccess.Text = "Incorrect Pin!";                                // Display Wrong Pin
                        adminaccess.ForeColor = Color.Red;
                        timer1.Start();                                                     
                        match = true;                                                       // Admin was found
                        APassText.Text = "";
                        this.ActiveControl = APassText;                                     // Put Cursor at cleared password field
                    }
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
                adminaccess.Text = "Admin Does Not Exist";                                  // Show Error
                adminaccess.ForeColor = Color.Red;
                timer1.Start();
                ANameText.Text = "";                                                        // Clear Username and Password fileds
                APassText.Text = "";
                this.ActiveControl = ANameText;                                             // Put Cusor in admin username field
            }
            xlWorkBook.Save();
            xlWorkBook.Close();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            // Admin is No Longer Signed in
            AdminActive = false;
            // Allow Sign-Ins
            UNameText.ReadOnly = false;
            UPinText.ReadOnly = false;
            UIDText.ReadOnly = false;

            // Hide Admin Priviledges
            logout.Visible = false;
            AMenuLabel.Visible = false;
            ADispRep.Visible = false;
            ADispPred.Visible = false;
            AEnroll.Visible = false;
            AChangePass.Visible = false;
            ANameLabel.Visible = false;
            ANameText.Visible = false;
            APassLabel.Visible = false;
            APassText.Visible = false;
            ALogin.Visible = false;
            adminaccess.Visible = false;
            newMeal.Visible = false;

            // Set Cursor back into the Scan Bar
            this.ActiveControl = UIDText;
        }

        //User clicks button with typed credentials
        private void button1_Click(object sender, EventArgs e)
        {
            check_database_np();
        }
        private void sign_in_cadet(string name)
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "CurrentMeal";                                             // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 
           
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("E2", "E2");    // E2 holds the number of cadets signed in

            double numsignedin = xlcell.Value;
            double rownum = numsignedin+2;

            Excel.Worksheet xlworksheet2 = (Excel.Worksheet)xlsheet.get_Item("Totals");
            Excel.Range xlcell2 = (Excel.Range)xlworksheet2.get_Range("A97", "A97");
            string currentmeal = xlcell2.Value.ToString();

            xlworksheet.Cells[rownum, 1] = name;
            xlworksheet.Cells[rownum, 2] = DateTime.Today;
            xlworksheet.Cells[rownum, 3] = DateTime.Today;
            xlworksheet.Cells[rownum, 3].NumberFormat = "General";
            xlworksheet.Cells[rownum, 4] = currentmeal;

            xlWorkBook.Save();
            xlWorkBook.Close();

        }
        private bool on_excusal(string name)
        {
            //Initializes Database
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Excusals";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet

            int i = 2;
            string cellname = "A" + i.ToString();
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);    // store in xlcell
            string xlname = name;
            bool match = false;
            if (xlcell.Value != null)
            {
                xlname = xlcell.Value.ToString();    // store value in xlcell as a string
            }

            while (xlcell.Value != null && !match)
            {
                if (xlname == name)
                    match = true;
                else
                {
                    i++;                                                                    // Move down a row
                    cellname = "A" + i.ToString();                                          // Set next cell
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);        // Get code
                }
                if (xlcell.Value != null)                                               // if its not empty
                    xlname = xlcell.Value.ToString();                                     // set as a string
            } 
            xlWorkBook.Save();
            xlWorkBook.Close();
            return match;
        }

        private void newMeal_Click(object sender, EventArgs e)
        {
            nm.ShowDialog();
        }
        private void update_multiples(string name)
        {
            Excel.Application xlApp = new Excel.Application(); //Create New Variable to hold Excel App
            string workbookpath = "C:\\Users\\Network Student\\Desktop\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\bin\\debug\\testdb"; //path for Mac-228
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); //How to access Spreadsheet
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;                                   // Variable to hold excel Sheets
            string currentSheet = "Multiples";                                                  // Set current sheet to be Cadet Users
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);  // Store users into xlworksheet 

            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range("E2", "E2");    // E2 holds the number of cadets signed in
            double numofmultiples = xlcell.Value;
            double rownum = numofmultiples + 2;

            // Put information in next row
            xlworksheet.Cells[rownum, 1] = name;
            xlworksheet.Cells[rownum, 2] = DateTime.Today;
            xlworksheet.Cells[rownum, 3] = denied;
            xlworksheet.Cells[rownum, 4] = DateTime.Today;
            xlworksheet.Cells[rownum, 4].NumberFormat = "General";
            xlWorkBook.Save();

            xlWorkBook.Save();
            xlWorkBook.Close();

        }
    }
}
