using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDrinkMarket.Entity.Concrete;

namespace EDrinkMarket.MVCWebUI.Models
{
    public class HomeViewModel
    {
        public List<Drink> PreferredDrinks { get; set; }
    }
}
