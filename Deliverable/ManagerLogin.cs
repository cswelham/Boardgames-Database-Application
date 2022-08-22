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
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
            //This line of code allows us to obscure the password visually and limit the max chars in textbox
            textBoxPassword.PasswordChar = '*';     //password character to hide password characters
            textBoxPassword.MaxLength = 20;         //max textbox character count
        }

        /// <summary>
        /// Clicked when user decides they are ready to log in, 
        /// Will get username and password, use that to query database and check that username and password are correct.
        /// A message box will be used to state whether or not we logged in successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Variables to be used: 1x bool, 4x string
            bool loggedIn = false;
            string username = "", password = "";

            //check if boxes are empty, the Trim removes white space in text from either side
            if ("".Equals(textBoxUsername.Text.Trim()) || "".Equals(textBoxPassword.Text.Trim()))
            {
                MessageBox.Show("Please make sure you enter a Username and Password");
                return;
            }

            //(1) GET the username and password from the text boxes, is good to put them in a try catch
            try
            {
                //Get the username
                username = textBoxUsername.Text.Trim();
                //Get the password
                password = textBoxPassword.Text.Trim();
            }
            catch
            {
                //Error message, more useful when you are storing numbers etc. into the database.
                MessageBox.Show("Username or Password given is in an incorrect format.");
                return;
            }

            //(2) SELECT statement getting all data from users, i.e. SELECT * FROM Users
            SQL.selectQuery("select * from manager");

            //(3) IF it returns some data, THEN check each username and password combination, ELSE There are no registered users
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    //Check username and password are in database
                    if (username.Equals(SQL.read[0].ToString()) && password.Equals(SQL.read[1].ToString()))
                    {
                        //Stop loop when logged on
                        loggedIn = true;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No managers have been registered.");
                return;
            }

            //if logged in display a success message
            if (loggedIn)
            {
                //message stating we logged in good
                MessageBox.Show("Successfully logged in as " + username);
                initialiseTextBoxes();

                //Set this manager to current one
                ManagerUsername.Username = username;

                //Hides the login page form from user
                this.Hide();
                //Create a Manager Page object to change to
                ManagerMenu manager = new ManagerMenu();
                //show the manager page
                manager.ShowDialog();
                //close the login page we are currently on
                this.Close();


            }
            else
            {
                //message stating we couldn't log in
                MessageBox.Show("Login attempt unsuccessful! Please check details");
                textBoxUsername.Focus();
                return;
            }
        }

        /// <summary>
        /// Initialises all textboxes to blank text
        /// Re focus to first text box
        /// </summary>
        public void initialiseTextBoxes()
        {
            //goes through and clears all of the textboxes
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Clear();
                }
                else if (c is ComboBox)
                {
                    (c as ComboBox).Text = "";
                }
            }
            //makes next place user types the text box
            textBoxUsername.Focus();
        }

        /// <summary>
        /// Clears the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            initialiseTextBoxes();
        }

        /// <summary>
        /// Go to register a manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Manager Page object to change to
            ManagerRegister manager = new ManagerRegister();
            //show the customer page
            manager.ShowDialog();
            //close the login page we are currently on
            this.Close();
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
