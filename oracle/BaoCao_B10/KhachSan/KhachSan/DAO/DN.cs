using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DAO
{
    class DN
    {
        public static string url = "DATA SOURCE = localhost:1521/ORCL; USER ID = ";
        public static string name = "";
        public static string pass = "";

        public DN()
        {
        }


        public static string User { get => name; set => name = value; }
        public static string Pass { get => pass; set => pass = value; }
    }
}
