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
        public ChangePassword change = new ChangePassword();
        public Reports reports = new Reports();
        public Predictions predict = new Predictions();
        public EnrollCadet enroll = new EnrollCadet();
        public Already_Signed_In asi = new Already_Signed_In();
        public bool AdminActive = false;
        public UEnter()
        {
            InitializeComponent();
            this.ActiveControl = UIDText;
        }

        private void AButton_Click(object sender, EventArgs e)
        {
            // Make admin login visible
            
            ANameLabel.Visible = true;
            ANameText.Visible = true;
            APassLabel.Visible = true;
            APassText.Visible = true;
            ALogin.Visible = true;
            adminaccess.Visible = true;
        }

        private void ALogin_Click(object sender, EventArgs e)
        {
            // Validate admin
            check_database_admin();
            // Make admin menu visible
            if (AdminActive)
            {
                UNameText.ReadOnly = true;
                UPinText.ReadOnly = true;
                UIDText.ReadOnly = true;
                logout.Visible = true;
                AMenuLabel.Visible = true;
                ADispRep.Visible = true;
                ADispPred.Visible = true;
                AEnroll.Visible = true;
                AChangePass.Visible = true;
            }

        }




        private void UEnter_Load(object sender, EventArgs e)
        {

        }

        private void UIDText_KeyDown(object sender, KeyEventArgs e)
        
    {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_code();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            access.Text = "Scan Card";
            adminaccess.Text = "";
            access.ForeColor = Color.Black;
            UIDText.Text = "";
            timer1.Stop();
        }

        private void UPinText_TextChanged(object sender, EventArgs e)
        {
            //Does nothing
        } // Find  a way to remove...without breaking everything

        private void UNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_np(); //checks database with typed input
            }
        }

        private void UPinText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_np(); //checks database with typed input
            }
          
        }

        private void ANameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_admin();
                // Make admin menu visible
                if (AdminActive)
                {
                    UNameText.ReadOnly = true;
                    UPinText.ReadOnly = true;
                    UIDText.ReadOnly = true;
                    logout.Visible = true;
                    AMenuLabel.Visible = true;
                    ADispRep.Visible = true;
                    ADispPred.Visible = true;
                    AEnroll.Visible = true;
                    AChangePass.Visible = true;
                }
            }
        }

        private void UIDText_KeyPress(object sender, KeyPressEventArgs e)
        {
           //Does nothing
        }

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


        private void check_database_code()
        {
            //Initializes Database
            Excel.Application xlApp = new Excel.Application();
            string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;
            string currentSheet = "Users";
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);

            string cellname = "C2";
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
            Excel.AllowEditRange testin;
            string code = xlcell.Value.ToString();
            bool match = false;
            int i = 2;
            while (xlcell.Value != null && !match)
            {

                if (UIDText.Text == code)
                {
                    cellname = "D" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    double attend = xlcell.Value;
                    if (attend == 0)
                    {
                        access.Text = "Granted";
                        access.ForeColor = Color.Green;
                        timer1.Start();
                        match = true;
                        //update database
                        attend = attend+1;
                        xlApp.Cells[i, 4] = attend;
                        xlWorkBook.Save();
                        //reset form
                        UPinText.Text = "";
                        UNameText.Text = "";
                        this.ActiveControl = UIDText;

                    }
                    else
                    {
                        access.Text = "Denied";
                        access.ForeColor = Color.Red;
                        timer1.Start();
                        match = true;
                        asi.ShowDialog();
                        if (asi.getstatus())
                        {
                            attend = attend+1;
                            xlApp.Cells[i, 4] = attend;
                            xlWorkBook.Save();
                        }
                    }

                }
                else
                {
                    i++;
                    cellname = "C" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    if (xlcell.Value != null)
                        code = xlcell.Value.ToString();
                }
            }
            if (!match)
            {
                access.Text = "User Does Not Exist";
                access.ForeColor = Color.Red;
                timer1.Start();
            }
        }

        private void check_database_np() //check with name and pin
        {
            Excel.Application xlApp = new Excel.Application();
            string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;
            string currentSheet = "Users";
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);

            string cellname = "A2";
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
            Excel.AllowEditRange test;
            string code = xlcell.Value.ToString();
            bool match = false;
            int i = 2;
            while (xlcell.Value != null && !match)
            {

                if (UNameText.Text == code)
                {
                    cellname = "B" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    string pin = xlcell.Value.ToString();
                    cellname = "D" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    double attend = xlcell.Value;
                    if (UPinText.Text == pin)
                    {
                        if (attend == 0)
                        {
                            access.Text = "Granted";
                            access.ForeColor = Color.Green;
                            timer1.Start();
                            match = true;
                            //update database
                            attend = attend+1;
                            xlApp.Cells[i, 4] = attend;
                            xlWorkBook.Save();
                            //reset form
                            UPinText.Text = "";
                            UNameText.Text = "";
                            this.ActiveControl = UIDText;
                            
                        }
                        else
                        {
                            access.Text = "Denied";
                            access.ForeColor = Color.Red;
                            timer1.Start();
                            match = true;
                            asi.ShowDialog();
                            if (asi.getstatus())
                            {
                                attend = attend+1;
                                xlApp.Cells[i, 4] = attend;
                                xlWorkBook.Save();
                            }
                        }

                    }
                    else
                    {
                        access.Text = "Incorrect Pin!";
                        access.ForeColor = Color.Red;
                        timer1.Start();
                        match = true;
                        UPinText.Text = "";
                        this.ActiveControl = UPinText;
                    }
                }
                else
                {
                    i++;
                    cellname = "A" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    if (xlcell.Value != null)
                        code = xlcell.Value.ToString();
                }
            }
            if (!match)
            {
                access.Text = "User Does Not Exist";
                access.ForeColor = Color.Red;
                timer1.Start();
                UNameText.Text = "";
                UPinText.Text = "";
                this.ActiveControl = UNameText;
            }
        }
        private void check_database_admin() //check with name and pin
        {
            Excel.Application xlApp = new Excel.Application();
            string workbookpath = "C:\\Users\\Network Student\\Documents\\GitHub\\Lab1\\CG_SK_Lab1\\CG_SK_Lab1\\testdb";
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(workbookpath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets xlsheet = xlWorkBook.Worksheets;
            string currentSheet = "Admin";
            Excel.Worksheet xlworksheet = (Excel.Worksheet)xlsheet.get_Item(currentSheet);

            string cellname = "A2";
            Excel.Range xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
            string code = xlcell.Value.ToString();
            bool match = false;
            int i = 2;
            while (xlcell.Value != null && !match)
            {

                if (ANameText.Text == code)
                {
                    cellname = "B" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    string pin = xlcell.Value.ToString();
                    if (APassText.Text == pin)
                    {
                        adminaccess.Text = "Granted";
                        adminaccess.ForeColor = Color.Green;
                        timer1.Start();
                        match = true;
                        APassText.Text = "";
                        ANameText.Text = "";
                        this.ActiveControl = UIDText;
                        AdminActive = true;
                    }
                    else
                    {
                        adminaccess.Text = "Incorrect Pin!";
                        adminaccess.ForeColor = Color.Red;
                        timer1.Start();
                        match = true;
                        APassText.Text = "";
                        this.ActiveControl = APassText;
                    }
                }
                else
                {
                    i++;
                    cellname = "A" + i.ToString();
                    xlcell = (Excel.Range)xlworksheet.get_Range(cellname, cellname);
                    if (xlcell.Value != null)
                        code = xlcell.Value.ToString();
                }
            }
            if (!match)
            {
                adminaccess.Text = "User Does Not Exist";
                adminaccess.ForeColor = Color.Red;
                timer1.Start();
                ANameText.Text = "";
                APassText.Text = "";
                this.ActiveControl = ANameText;
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            AdminActive = false;
            UNameText.ReadOnly = false;
            UPinText.ReadOnly = false;
            UIDText.ReadOnly = false;
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
            this.ActiveControl = UIDText;
        }

        
        /*public void update_cell(string cellnumber, double val)
        {
  
               this.range[cellnumber, cellnumber].Value2 = val;
        }*/
    }
}
