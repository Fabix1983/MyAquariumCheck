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
        public decimal PH { get; set; }
        public decimal GH { get; set; }
        public decimal KH { get; set; }
        public decimal NO2 { get; set; }
        public decimal NO3 { get; set; }

        public bool Eseguito { get; set; }
    }
}
