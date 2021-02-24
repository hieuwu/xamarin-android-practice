using System;
using System.Collections.Generic;
using System.Text;

namespace KittenView.Core.Services
{
    interface IKittenGenesisService
    {
        Kitten CreatNewKitten(string extra = "");
    }
}
