using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
namespace KittenView.Core.Services
{
     class DataService: IDataService
     {
        private SQLiteConnection _db;
        public DataService()
        {
            _db = new SQLiteConnection("Testing.db");
            _db.CreateTable<Kitten>();
        }

        public void AddKitten(Kitten kitten)
        {
            _db.Insert(new Kitten()
            {
                Name = "Hieu SQlite",
                Price = 12,
                ImageUrl = "link by sqlite",
            });
        }

        public List<Kitten> GetKittenList(){
            var kittens = _db.Query<Kitten>("SELECT * FROM Kittens");
            return kittens; 
        }
    }
}
