using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try2Demo11032023.Data
{
    internal static class DataBaseManager
    {
        public static Model.Try2Demo11032023Entities DataBase = new Model.Try2Demo11032023Entities();

        public static Model.Employee CurrentUser { get; set; } 
    }
}
