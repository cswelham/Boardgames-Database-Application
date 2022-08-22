using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable
{
    //Holds the current customer who is logged in
    static class CustomerUsername
    {
        private static string username = "";

        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
