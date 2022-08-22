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
    public partial class ManagerCode : Form
    {
        int MANAGER_CODE = 2020;

        public ManagerCode()
        {
            InitializeComponent();
            textBoxCode.PasswordChar = '*';
        }

        /// <summary>
        /// Checks manager code is right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            int code = 0;
            try
            {
                //Get code
                code = int.Parse(textBoxCode.Text);

                if (code == MANAGER_CODE)
                {
                    //Hides the login page form from user
                    this.Hide();
                    //Create a login Page object to change to
                    ManagerLogin login = new ManagerLogin();
                    //show the login page
                    login.ShowDialog();
                    //close the login page we are currently on
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong code. Please try again");
                    textBoxCode.Text = "";
                    textBoxCode.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Please enter in correct format.");
                textBoxCode.Text = "";
                textBoxCode.Focus();
            }
        }

        /// <summary>
        /// Goes back to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Hides the Menu page form from user
            this.Hide();
            //Create a Menu Page object to change to
            Menu menu = new Menu();
            //show the customer page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
