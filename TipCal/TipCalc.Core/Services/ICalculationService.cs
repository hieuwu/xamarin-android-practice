﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalc.Core.Services
{
    interface ICalculationService   
    {
        double TipAmount(double subTotal, int generosity);
    }
}
