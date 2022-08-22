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
    public partial class BoardgameData : Form
    {
        public BoardgameData()
        {
            InitializeComponent();
            //Get customer data
            SQL.selectQuery("SELECT * FROM boardgame order by name asc");

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    listBoxBoardgameData.Items.Add(SQL.read[0].ToString().PadRight(8) + SQL.read[1].ToString().PadRight(32) +
                        SQL.read[2].ToString().PadRight(10) + SQL.read[3].ToString().PadRight(12) + SQL.read[4].ToString().PadRight(8) +
                        SQL.read[5].ToString().PadRight(3) + SQL.read[6].ToString().PadRight(3) + SQL.read[7].ToString().PadRight(4) +
                        SQL.read[8].ToString().PadRight(8) + SQL.read[9].ToString().PadRight(4));
                }
            }
            else
            {
                MessageBox.Show("There is no boardgame data.");
                return;
            }
        }

        /// <summary>
        /// Back to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Manager Page object to change to
            CustomerMenu menu = new CustomerMenu();
            //show the manager page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
