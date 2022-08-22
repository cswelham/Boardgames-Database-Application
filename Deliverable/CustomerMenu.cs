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
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// View all boardgames
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAllCustomers_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Boardgame Page object to change to
            BoardgameData boardgame = new BoardgameData();
            //show the manager page
            boardgame.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Review a boardgame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAllManagers_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Boardgame Page object to change to
            Review review = new Review();
            //show the manager page
            review.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Back to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Menu Page object to change to
            Menu menu = new Menu();
            //show the mamenunager page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenre_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Genre Page object to change to
            GenreLikesData likes = new GenreLikesData();
            //show the mamenunager page
            likes.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to return a boardgame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a return Page object to change to
            ReturnBoardgame ret = new ReturnBoardgame();
            //show the return page
            ret.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to add a genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddGenre_Click(object sender, EventArgs e)
        {
            //Hides the genre page form from user
            this.Hide();
            //Create a genre Page object to change to
            AddGenre add = new AddGenre();
            //show the genre page
            add.ShowDialog();
            //close the genre page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to rent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRent_Click(object sender, EventArgs e)
        {
            //Hides the geRentnre page form from user
            this.Hide();
            //Create a Rent Page object to change to
            Rent rent = new Rent();
            //show the Rent page
            rent.ShowDialog();
            //close the Rent page we are currently on
            this.Close();
        }
    }
}
