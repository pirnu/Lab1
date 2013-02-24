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
            aname.Visible = false;
            apass.Visible = false;
            ANameText.Visible = false;
            APassText.Visible = false;
            enter.Visible = false;

        }

        public bool overrode = false;

        public bool getstatus()
        {
            return overrode;
        }

        private void Already_Signed_In_Load(object sender, EventArgs e)
        {
            //Does nothing
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aoverride_Click(object sender, EventArgs e)
        {
            aname.Visible = true;
            apass.Visible = true;
            ANameText.Visible = true;
            APassText.Visible = true;
            enter.Visible = true;
        }


        private void ANameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_admin(); //checks database with typed input
            }
        }

        private void APassText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                check_database_admin(); //checks database with typed input
            }
        }

        private void enter_Click(object sender, EventArgs e)
        {
                check_database_admin(); //checks database with typed input
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
                        match = true;

                        overrode = true;
                        this.Close();
                    }
                    else
                    {
                        status.Text = "Incorrect Password";
                        status.ForeColor = Color.Red;
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
                status.Text = "User Does Not Exist";
                status.ForeColor = Color.Red;
                timer1.Start();
                ANameText.Text = "";
                APassText.Text = "";
                this.ActiveControl = ANameText;
            }
        }
    
    }

}
