using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KittenView.Core.Services
{
    class Kitten
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
