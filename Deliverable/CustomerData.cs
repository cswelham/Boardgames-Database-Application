using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deliverable
{
    public partial class CustomerData : Form
    {
        //global vairbale
        string customer = "";

        public CustomerData()
        {
            InitializeComponent();
            //Get customer data
            SQL.selectQuery("SELECT * FROM customer order by username asc");

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    listBoxCustomerData.Items.Add(SQL.read[0].ToString().PadRight(5) + SQL.read[1].ToString().PadRight(12) +
                        SQL.read[2].ToString().PadRight(12) + " ********* " + SQL.read[4].ToString().PadRight(10) +
                        SQL.read[5].ToString().PadRight(24) + SQL.read[6].ToString().PadRight(11) + SQL.read[7].ToString().PadRight(12) +
                        SQL.read[8].ToString().PadRight(6) + SQL.read[9].ToString().PadRight(24) + SQL.read[10].ToString().PadRight(24) +
                        SQL.read[11].ToString().PadRight(8) + SQL.read[12].ToString().PadRight(2));
                }
            }
            else
            {
                MessageBox.Show("There is no customer data.");
                return;
            }
        }

        /// <summary>
        /// Go back to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// Deletes a customer from the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customer == "")
            {
                MessageBox.Show("No customer has been selected.");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this customer? It will remove data from genre, rental and review.", "Deleting A Customer",
                MessageBoxButtons.YesNo);

            //If user selected yes
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string[] split = customer.Split(' ');
                    customer = "";

                    //Delete data from review
                    SQL.executeQuery("DELETE FROM reviews WHERE customerUsername = '" + split[0] + "'");

                    //Change any rentals done by manager so boardgames now avaliable
                    SQL.executeQuery("update boardgame set avaliable = 'yes' where id in (select boardgameID from rental where customerUsername = '" + split[0] + "')");
                    //Delete the rentals done by the customer
                    SQL.executeQuery("DELETE FROM rental WHERE customerUsername = '" + split[0] + "'");

                    //Delete data from genre
                    SQL.executeQuery("DELETE FROM likes WHERE customerUsername = '" + split[0] + "'");

                    //Delete data from customer
                    SQL.selectQuery("SELECT * FROM customer order by username asc");
                    if (SQL.read.HasRows)
                    {
                        while (SQL.read.Read())
                        {
                            if (SQL.read[0].ToString() == split[0])
                            {
                                SQL.executeQuery("DELETE FROM customer WHERE username = '" + split[0] + "'");
                                MessageBox.Show("Customer " + split[0] + " has been deleted.");

                                //Hides the login page form from user
                                this.Hide();
                                //Create a Customer Page object to change to
                                CustomerData customer = new CustomerData();
                                //show the customer page
                                customer.ShowDialog();
                                //close the login page we are currently on
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no customer data.");
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
        /// Get selected customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCustomerData_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = listBoxCustomerData.GetItemText(listBoxCustomerData.SelectedItem);
        }
    }
}
