using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAquariumCheck.Models
{
    internal class CheckItem
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public int Temperatura { get; set; }
        public string PH { get; set; }
        public string GH { get; set; }
        public string KH { get; set; }
        public string NO2 { get; set; }
        public string NO3 { get; set; }

        public bool Eseguito { get; set; }
    }
}
