using System.Collections.Generic;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> GetAll();
        Drink Get(string drinkName);
        Drink Add(Drink drink);
        void Delete(string drinkName);
        void Update(Drink drink);
    }
}
