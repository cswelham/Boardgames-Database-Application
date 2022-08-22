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
    public partial class ManagerData : Form
    {
        //Global variable
        string manager = "";

        public ManagerData()
        {
            InitializeComponent();
            //Get manager data
            SQL.selectQuery("SELECT * FROM manager order by username asc");

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    listBoxManagerData.Items.Add(SQL.read[0].ToString().PadRight(14) + " ******** ");
                }
            }
            else
            {
                MessageBox.Show("There is no manager data.");
                return;
            }
        }

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

        /// <summary>
        /// Delete a manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manager == "")
            {
                MessageBox.Show("No manager has been selected.");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this manager? It will remove data from rental.", "Deleting A Manager",
                MessageBoxButtons.YesNo);

            //If user selected yes
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string[] split = manager.Split(' ');
                    manager = "";

                    //Change any rentals done by manager so boardgames now avaliable
                    SQL.executeQuery("update boardgame set avaliable = 'yes' where id in (select boardgameID from rental where managerUsername = '" + split[0] + "')");
                    //Delete the rentals done by the manager
                    SQL.executeQuery("DELETE FROM rental WHERE managerUsername = '" + split[0] + "'");

                    //Delete data from manager
                    SQL.selectQuery("SELECT * FROM manager");
                    if (SQL.read.HasRows)
                    {
                        while (SQL.read.Read())
                        {
                            if (SQL.read[0].ToString() == split[0])
                            {
                                SQL.executeQuery("DELETE FROM manager WHERE username = '" + split[0] + "'");
                                MessageBox.Show("Manager " + split[0] + " has been deleted.");

                                //Hides the login page form from user
                                this.Hide();
                                //Create a Manager Page object to change to
                                ManagerData manager = new ManagerData();
                                //show the manager page
                                manager.ShowDialog();
                                //close the login page we are currently on
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no manager data.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("There has been an error. Please try again.");
                }
            }
        }

        /// <summary>
        /// Get selected value from listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxManagerData_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager = listBoxManagerData.GetItemText(listBoxManagerData.SelectedItem);
        }
    }
}
