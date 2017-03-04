using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure
{
    public class DrinkRepository : IDrinkRepository
    {
        private static readonly List<Drink> drinks = new List<Drink>()
        {
            new Drink(){ Name = "Pepsi", Quantity = 2 },
            new Drink(){ Name = "Coca Cola", Quantity = 1 },
            new Drink(){ Name = "Evian", Quantity = 3 }
        };

        public IEnumerable<Drink> GetAll()
        {
            return drinks;
        }

        public Drink Get(string drinkName)
        {
            return drinks.Find(s => String.Equals(s.Name, drinkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Drink Add(Drink drink)
        {
            if (drinks.All(s => s.Name != drink.Name))
                drinks.Add(drink);
            else
                Update(drink);
            return Get(drink.Name);
        }

        public void Delete(string drinkName)
        {
            var drink = drinks.SingleOrDefault(d => String.Equals(d.Name, drinkName, StringComparison.InvariantCultureIgnoreCase));
            if (drink != null)
                drinks.Remove(drink);
        }

        public void Update(Drink drink)
        {
            var drinkTemp = drinks.FirstOrDefault(d => String.Equals(d.Name, drink.Name, StringComparison.InvariantCultureIgnoreCase));
            if (drinkTemp != null)
                drinkTemp.Quantity += drink.Quantity;
        }
    }
}