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
    public partial class ManagerRegister : Form
    {
        public ManagerRegister()
        {
            InitializeComponent();
            //This line of code allows us to obscure the password visually and limit the max chars in textbox
            textBoxPassword.PasswordChar = '*';     //password character to hide password characters
            //max textbox character count
            textBoxUsername.MaxLength = 12;
            textBoxPassword.MaxLength = 12;
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
            //variables to be used
            string username = "", password = "";

            //Check that the text boxes has something typed in it using a method
            bool hasText = checkTextBoxes();
            if (!hasText)
            {
                MessageBox.Show("Please make sure all textboxes have text.");
                textBoxUsername.Focus();
                return;
            }

            //(1) GET the data from the textboxes and store into variables created above, good to put in a try catch with error message
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
                MessageBox.Show("Please make sure your text is in correct format.");
                return;
            }

            //(2) Execute the INSERT statement, making sure all quotes and commas are in the correct places.
            //      Practice first on SQL Server Management Studio to make sure it is entering the correct data and in the correct format,
            //      then copy across the statement and where there are string replace the actual text for the variables stored above.
            //Example query: " INSERT INTO Users VALUES ('jkc1', 'John', 'Middle', 'Carter', 'pass1') "
            try
            {
                //(2) SELECT statement getting all data from users, i.e. SELECT * FROM Users
                SQL.executeQuery("INSERT INTO Manager Values ('" + username + "', '" + password + "')");

                //success message for the user to know it worked
                MessageBox.Show("Successfully Registered. Your username is: " + username);

                //Go back to the login page since we registered successfully to let the user log in
                Hide();                                 //hides the register form
                ManagerLogin login = new ManagerLogin();      //creates the login page as an object
                login.ShowDialog();                     //shows the new login page form
                this.Close();                           //closes the register form that was hidden
            }
            catch
            {
                MessageBox.Show("Register attempt unsuccessful.  Check insert statement.  Could be a Username conflict too.");
                return;
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
            }
            //returns true or false based on if data is in all text boxs or not
            return holdsData;
        }

        /// <summary>
        /// Goes back to manager login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Go back to the login page since we registered successfully to let the user log in
            Hide();                                 //hides the register form
            ManagerLogin login = new ManagerLogin();      //creates the login page as an object
            login.ShowDialog();                     //shows the new login page form
            this.Close();                           //closes the register form that was hidden
        }
    }
}
