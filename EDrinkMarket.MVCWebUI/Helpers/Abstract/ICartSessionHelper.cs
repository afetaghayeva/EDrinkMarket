﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDrinkMarket.Entity.Concrete.DomainModels;

namespace EDrinkMarket.MVCWebUI.Helpers.Abstract
{
    public interface ICartSessionHelper
    {
        Cart GetCart(string key);
        void SetCart(string key, Cart cart);
        void Clear();
    }
}