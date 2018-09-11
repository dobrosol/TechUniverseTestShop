using System;
using System.Collections.Generic;
using Domain.Concrete.ProductEntities;
using Domain.Concrete;
using NUnit.Framework;

namespace Tests
{
     [TestFixture]
     public class CartUnitTest
     {
          Cart cart;
          Product product1, product2, product3;

          [SetUp]
          public void Initialize()
          {
               cart = new Cart();

               product1 = new ASC { Name = "ASC1", Price = 1 };
               product2 = new Case { Name = "Case1" , Price = 1.5m};
               product3 = new ASC { Name = "ASC2", Price = 2 };
          }
          [Test]
          public void CanAddItems()
          {
               cart.AddItem(product1 as Product, 1);
               cart.AddItem(product2 as Product, 1);

               List<CartLine> lines = cart.Lines as List<CartLine>;

               Assert.AreEqual(2, lines.Count);
          }
          [Test]
          public void CanRemoveItem()
          {
               cart.AddItem(product2 as Product, 2);
               cart.AddItem(product3 as Product, 1);

               cart.RemoveLine(product2.Name);

               Assert.AreEqual(1, cart.CalcTotalCount());
          }
          [Test]
          public void CanCalcTotalCount()
          {
               cart.AddItem(product1 as Product, 4);
               cart.AddItem(product2 as Product, 2);
               cart.AddItem(product3 as Product, 5);

               Assert.AreEqual(11, cart.CalcTotalCount());
          }
          [Test]
          public void CanCalcTotalPrice()
          {
               cart.AddItem(product1 as Product, 3);
               cart.AddItem(product2 as Product, 1);

               Assert.AreEqual(4.5, cart.CalcTotalPrice());
          }
          [Test]
          public void CanClear()
          {
               cart.AddItem(product1 as Product, 1);
               cart.AddItem(product2 as Product, 2);

               cart.Clear();

               List<CartLine> lines = cart.Lines as List<CartLine>;

               Assert.AreEqual(0, lines.Count);
          }
     }
}
