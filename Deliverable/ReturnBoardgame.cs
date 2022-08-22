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
    public partial class ReturnBoardgame : Form
    {
        string boardgame = "";

        public ReturnBoardgame()
        {
            InitializeComponent();

            comboBoxCondition.Items.Add("good");
            comboBoxCondition.Items.Add("average");
            comboBoxCondition.Items.Add("bad");

            //Setup customer combobox
            SQL.selectQuery("select * from manager order by username asc");
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    comboBoxManager.Items.Add(SQL.read[0]);
                }
            }
            else
            {
                MessageBox.Show("No managers have been registered.");
                return;
            }

            //Get customer data
            SQL.selectQuery("SELECT r.*, b.name FROM rental r, boardgame b where r.boardgameID = b.id order by r.id asc");

            DateTime one;
            DateTime two = DateTime.Now;
            string overdue;

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    one = Convert.ToDateTime(SQL.read[2].ToString());
                    double result = (one - two).TotalDays;

                    //Seeing if return date is within 7 days
                    if (SQL.read[5].ToString() == CustomerUsername.Username)
                    { 
                        if (result < 0)
                        {
                            overdue = "OVERDUE!";
                        }
                        else
                        {
                            overdue = "Due in " + (int)Math.Ceiling(result) + " days";
                        }
                        listBoxRentalData.Items.Add(SQL.read[0].ToString().PadRight(4) + SQL.read[1].ToString().PadRight(24) +
                        SQL.read[2].ToString().PadRight(24) + SQL.read[3].ToString().PadRight(10) + SQL.read[4].ToString().PadRight(14) +
                        SQL.read[5].ToString().PadRight(14) + SQL.read[6].ToString().PadRight(8) + SQL.read[7].ToString().PadRight(32) + overdue.PadRight(10));
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
            //Create a Customer Page object to change to
            CustomerMenu menu = new CustomerMenu();
            //show the customer page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        private void listBoxRentalData_SelectedIndexChanged(object sender, EventArgs e)
        {
            boardgame = listBoxRentalData.GetItemText(listBoxRentalData.SelectedItem);
        }

        /// <summary>
        /// Delete boardgame from rentals and change condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteARentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string condition = "";

            if (boardgame == "")
            {
                MessageBox.Show("No boardgame has been selected.");
                return;
            }

            //Check that the text boxes has something typed in it using a method
            bool hasText = checkTextBoxes();
            if (!hasText)
            {
                MessageBox.Show("Please make sure all textboxes have text.");
                return;
            }

            try
            {
                string[] split = boardgame.Split(' ');
                boardgame = "";
                string boardgameID = "";
                condition = comboBoxCondition.Text;

                //Find boardgame ID of rental
                SQL.selectQuery("SELECT * FROM rental");

                //If it returns some data, then put that data into the listbox
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        if (SQL.read[0].ToString() == split[0])
                        {
                            boardgameID = SQL.read[6].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is no boardgame data.");
                    return;
                }

                //Get rentals data
                SQL.selectQuery("SELECT * FROM rental");

                //If it returns some data, then put that data into the listbox
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        if (SQL.read[6].ToString() == boardgameID)
                        {
                            SQL.executeQuery("DELETE FROM rental WHERE boardgameID = '" + boardgameID + "'");
                            MessageBox.Show("Boardgame ID: " + boardgameID + " has been returned. Condition is " + condition);

                            //Set avaliable to yes
                            SQL.executeQuery("update boardgame set avaliable = 'yes' where id = '" + boardgameID + "'");

                            //Hides the login page form from user
                            this.Hide();
                            //Create a Return Page object to change to
                            ReturnBoardgame ret = new ReturnBoardgame();
                            //show the return page
                            ret.ShowDialog();
                            //close the login page we are currently on
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is no rental data.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("There has been an error. Please try again.");
            }
        }

        /// <summary>
        /// Checks if they textboxes have data in them
        /// </summary>
        /// <returns>TRUE if all hold text, but FALSE if at least one does not hold data</returns>
        private bool checkTextBoxes()
        {
            bool holdsData = true;
            //go through all of the controls
            foreach (Control c in this.Controls)
            {
                //if its a textbox
                if (c is TextBox)
                {
                    //If it is not the case that it is empty
                    if ("".Equals((c as TextBox).Text.Trim()))
                    {
                        //set boolean to false because on textbox is empty
                        holdsData = false;
                    }
                }
                //if its a combobox
                else if (c is ComboBox)
                {
                    //If it is not the case that it is empty
                    if ((c as ComboBox).SelectedItem == null)
                    {
                        //set boolean to false because on textbox is empty
                        holdsData = false;
                    }
                }
            }
            //returns true or false based on if data is in all text boxes or not
            return holdsData;
        }
    }
}
