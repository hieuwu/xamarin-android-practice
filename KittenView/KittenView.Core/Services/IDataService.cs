using System;
using System.Collections.Generic;
using System.Text;

namespace KittenView.Core.Services
{
    interface IDataService
    {
        void AddKitten(Kitten kitten);
        List<Kitten> GetKittenList();
    }
}
