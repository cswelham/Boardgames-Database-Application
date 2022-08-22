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
    public partial class ManagerMenu : Form
    {
        public ManagerMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// View all customers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAllCustomers_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Customer Page object to change to
            CustomerData customer = new CustomerData();
            //show the customer page
            customer.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// View all rentals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAllRentals_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Customer Page object to change to
            RentalData rental = new RentalData();
            //show the customer page
            rental.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// View all managers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAllManagers_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Manager Page object to change to
            ManagerData manager = new ManagerData();
            //show the customer page
            manager.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Back to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Menu Page object to change to
            Menu menu = new Menu();
            //show the menu page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
        /// <summary>
        /// Go to rent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRent_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Menu Page object to change to
            Rent rent = new Rent();
            //show the menu page
            rent.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to designs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDesigns_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Designs Page object to change to
            DesignerData design = new DesignerData();
            //show the designs page
            design.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to genres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenres_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Designs Page object to change to
            GenreHasData genre = new GenreHasData();
            //show the genre page
            genre.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Go to publishes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPublishes_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Publishes Page object to change to
            PublisherData publish = new PublisherData();
            //show the publishes page
            publish.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// Gets boardgame data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBoardgame_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Boardgame Page object to change to
            BoardgameData boardgame = new BoardgameData();
            //show the boardgame page
            boardgame.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        /// <summary>
        /// See reviews data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReviews_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Reviews Page object to change to
            ReviewData reviews = new ReviewData();
            //show the reviews page
            reviews.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
