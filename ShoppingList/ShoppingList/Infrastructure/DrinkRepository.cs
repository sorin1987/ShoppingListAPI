using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure
{
    public class DrinkRepository : IDrinkRepository
    {
        private List<ShoppingListItem> drinks = new List<ShoppingListItem>()
        {
            new ShoppingListItem(){Drink = new Drink(){Name = "Pepsi"}, Quantity = 2},
            new ShoppingListItem(){Drink = new Drink(){Name = "Coca Cola"}, Quantity = 1},
            new ShoppingListItem(){Drink = new Drink(){Name = "Evian"}, Quantity = 3}
        };

        public IEnumerable<ShoppingListItem> GetAll()
        {
            return drinks;
        }

        public ShoppingListItem Get(string drinkName)
        {
            return drinks.Find(s => String.Equals(s.Drink.Name, drinkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public void Add(ShoppingListItem drink)
        {
            if (drinks.All(s => s.Drink.Name != drink.Drink.Name))
                drinks.Add(drink);
            else
                Update(drink);
        }

        public void Delete(string drinkName)
        {
            var shoppingListItem = drinks.SingleOrDefault(d => String.Equals(d.Drink.Name, drinkName, StringComparison.InvariantCultureIgnoreCase));
            if (shoppingListItem != null)
                drinks.Remove(shoppingListItem);
        }

        public void Update(ShoppingListItem drink)
        {
            var shoppingListItem = drinks.FirstOrDefault(d => String.Equals(d.Drink.Name, drink.Drink.Name, StringComparison.InvariantCultureIgnoreCase));
            if (shoppingListItem != null)
                shoppingListItem.Quantity += drink.Quantity;
        }
    }
}