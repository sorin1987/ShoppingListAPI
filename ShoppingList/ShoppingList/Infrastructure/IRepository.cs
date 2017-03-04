using System.Collections.Generic;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure
{
    public interface IDrinkRepository
    {
        IEnumerable<ShoppingListItem> GetAll();
        ShoppingListItem Get(string drinkName);
        void Add(ShoppingListItem drink);
        void Delete(string drinkName);
        void Update(ShoppingListItem drink);
    }
}
