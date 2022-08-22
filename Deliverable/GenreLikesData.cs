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
    public partial class GenreLikesData : Form
    {
        //global vairbale
        string genre = "";

        public GenreLikesData()
        {
            InitializeComponent();
            //Get customer data
            SQL.selectQuery("Select c.username, g.name from customer c, genre g, likes l where c.username = l.customerUsername and g.name = l.genreName order by g.name asc");

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    if (SQL.read[0].ToString() == CustomerUsername.Username)
                    {
                        listBoxGenreData.Items.Add(SQL.read[1].ToString().PadRight(32));
                    }      
                }
            }
            else
            {
                MessageBox.Show("There is no genre data.");
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
            //Create a Customer Page object to change to
            CustomerMenu menu = new CustomerMenu();
            //show the customer page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        private void deleteACustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (genre == "")
            {
                MessageBox.Show("No genre has been selected.");
                return;
            }

            try
            {
                //Delete data from genre
                SQL.selectQuery("SELECT genreName FROM likes where customerUsername = '" + CustomerUsername.Username + "'");
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        if (SQL.read[0].ToString() == genre.Trim())
                        {
                            SQL.executeQuery("DELETE FROM likes WHERE genreName = '" + genre.Trim() + "'");
                            MessageBox.Show(genre.Trim() + " has been deleted from likes.");
                            genre = "";

                            //Hides the login page form from user
                            this.Hide();
                            //Create a GenreLikes Page object to change to
                            GenreLikesData likes = new GenreLikesData();
                            //show the GenreLikes page
                            likes.ShowDialog();
                            //close the login page we are currently on
                            this.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("There has been an error. Please try again.");
            }
        }

        /// <summary>
        /// Get selected genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxGenreData_SelectedIndexChanged(object sender, EventArgs e)
        {
            genre = listBoxGenreData.GetItemText(listBoxGenreData.SelectedItem);
        }
    }
}
