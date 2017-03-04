using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class Drink
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }
    }
}