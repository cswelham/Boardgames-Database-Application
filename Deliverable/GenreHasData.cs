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
    public partial class GenreHasData : Form
    {
        public GenreHasData()
        {
            InitializeComponent();
            //Get customer data
            SQL.selectQuery("Select b.name, g.name from boardgame b, genre g, has h where b.id = h.boardgameID and g.name = h.genreName order by b.name asc");

            //If it returns some data, then put that data into the listbox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    listBoxGenreData.Items.Add(SQL.read[0].ToString().PadRight(32) + SQL.read[1].ToString().PadRight(32));
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
            //Create a Manager Page object to change to
            ManagerMenu menu = new ManagerMenu();
            //show the manager page
            menu.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }
    }
}
