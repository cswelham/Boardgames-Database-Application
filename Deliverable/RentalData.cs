using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deliverable
{
    public partial class RentalData : Form
    {
        public RentalData()
        {
            InitializeComponent();
            //Get customer data
            SQL.selectQuery("SELECT r.*, b.name FROM rental r, boardgame b where r.boardgameID = b.id order by returnDate desc");

            DateTime one;
            DateTime two = DateTime.Now;
            string overdue;

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    listBoxRentalData.Items.Add(SQL.read[0].ToString().PadRight(4) + SQL.read[1].ToString().PadRight(24) +
                        SQL.read[2].ToString().PadRight(24) + SQL.read[3].ToString().PadRight(10) + SQL.read[4].ToString().PadRight(14) +
                        SQL.read[5].ToString().PadRight(14) + SQL.read[6].ToString().PadRight(8) + SQL.read[7].ToString().PadRight(32));

                    one = Convert.ToDateTime(SQL.read[2].ToString());
                    double result = (one - two).TotalDays;

                    if (result <= 7)
                    {
                        if (result < 0)
                        {
                            overdue = "OVERDUE!";
                        }
                        else
                        {
                            overdue = "Due in " + (int)Math.Ceiling(result) + " days";
                        }
                        listBoxLate.Items.Add(SQL.read[0].ToString().PadRight(4) + SQL.read[1].ToString().PadRight(24) +
                        SQL.read[2].ToString().PadRight(24) + SQL.read[3].ToString().PadRight(10) + SQL.read[4].ToString().PadRight(14) +
                        SQL.read[5].ToString().PadRight(14) + SQL.read[6].ToString().PadRight(8) + SQL.read[7].ToString().PadRight(32)
                        + overdue.PadRight(10));
                    } 
                }
            }
            else
            {
                MessageBox.Show("There is no rental data.");
                return;
            }
        }

        /// <summary>
        /// Back To Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Manager Page object to change to
            ManagerMenu menu = new ManagerMenu();
            //show the manager page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
