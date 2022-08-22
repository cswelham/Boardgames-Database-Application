using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable
{
    //Holds the current customer who is logged in
    static class SQLError
    {
        private static string error = "";

        public static string Error
        {
            get { return error; }
            set { error = value; }
        }
    }
}
