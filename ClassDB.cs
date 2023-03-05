using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Truong_Hoc_Lien_Cap
{
    internal class ClassDB
    {
        public string GetConnection()
        {
            string con = "Data Source=OTOMI;Initial Catalog=QLTruongLienCap;Integrated Security=True";
            return con;
        }
    }
}
