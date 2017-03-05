using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using ShoppingList.Controllers;
using ShoppingList.Infrastructure;
using ShoppingList.Models;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingListTests
    {
        public IDrinkRepository MockDrinkRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var drinks = new List<Drink>()
            {
                new Drink { Name = "Water", Quantity = 3, Id = 1, Description = "Pure water"},
                new Drink { Name = "Beer", Quantity = 1, Id = 2, Description = "Best german beer"},
                new Drink { Name = "Tea", Quantity = 2, Id = 3, Description = "Green tea"},
                new Drink { Name = "Coca Cola", Quantity = 5, Id = 4, Description = "Best drink in the world"}
            };

            var mockDrinkRepository = new Mock<IDrinkRepository>();
            mockDrinkRepository.Setup(m => m.GetAll()).Returns(drinks);
            mockDrinkRepository.Setup(m => m.Get(It.Is<string>(s => s == "Coca Cola"))).Returns(drinks[3]);
            mockDrinkRepository.Setup(m => m.Get(It.Is<string>(s => s == "Water"))).Returns(drinks[0]);
            mockDrinkRepository.Setup(m => m.Get(It.Is<string>(s => s == "Beer"))).Returns(drinks[1]);
            mockDrinkRepository.Setup(m => m.Get(It.Is<string>(s => s == "Tea"))).Returns(drinks[2]);

            MockDrinkRepository = mockDrinkRepository.Object;
        }

        [TestMethod]
        public void GetAllDrinks()
        {
            var controller = new DrinksController(MockDrinkRepository) {Request = new HttpRequestMessage()};
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var result = controller.Get();
            var listDrinks = JsonConvert.DeserializeObject<List<Drink>>(result.Content.ReadAsStringAsync().Result);
            Assert.AreEqual("OK", result.ReasonPhrase);
            Assert.AreEqual(4, listDrinks.Count);
        }
    }
}
