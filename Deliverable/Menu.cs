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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Goes to the manager login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonManager_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Manager Page object to change to
            ManagerCode manager = new ManagerCode();
            //show the manager page
            manager.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Goes to the customer login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Customer Page object to change to
            CustomerLogin customer = new CustomerLogin();
            //show the manager page
            customer.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
