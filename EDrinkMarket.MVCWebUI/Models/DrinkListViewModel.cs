using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.MVCWebUI.Models
{
    public class DrinkListViewModel
    {
        public List<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
