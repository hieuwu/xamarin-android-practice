using System;
using System.Collections.Generic;
using System.Text;

namespace KittenView.Core.Services
{
    class KittenGenesisService : IKittenGenesisService
    {
        private readonly List<string> _names = new List<string>()
        {
            "Kanye West", "Diddy", "Lil Pump", "6ix9ine", "Meek Mill", "Kendrick Lamar"
        };
        public Kitten CreatNewKitten(string extra = "")
        {
            return new Kitten()
            {
                Name = _names[Random(_names.Count)] + "",
                Price = RandomPrice(),
                ImageUrl = string.Format("http://placekitten.com/{0}/{0}", Random(20) + 300),
            };
        }

        private int RandomPrice()  
        {
            return 1;
        }

        private int Random(int count)
        {
            return new Random().Next(0,count-1);
        }
    }
}


