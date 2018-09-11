using System.Collections.Generic;
using System.Linq;
using Domain.Concrete.ProductEntities;

namespace Domain.Concrete
{
     public class Cart
     {
          List<CartLine> lines = new List<CartLine>();

          public void AddItem(Product product, int quantity)
          {
               CartLine line = lines.Where(l => l.Product.Name == product.Name).FirstOrDefault();

               if (line == null)
                    lines.Add(new CartLine()
                    {
                         Product = product,
                         Quantity = quantity
                    });
               else
                    line.Quantity += quantity;
          }

          public void RemoveLine(string name)
          {
               lines.RemoveAll(l => l.Product.Name == name);
          }

          public decimal CalcTotalPrice()
          {
               return lines.Sum(l => l.Product.Price * l.Quantity);
          }

          public decimal CalcTotalCount()
          {
               return lines.Sum(l => l.Quantity);
          }

          public void Clear()
          {
               lines.Clear();
          }

          public IEnumerable<CartLine> Lines
          {
               get { return lines; }
          }
     }

     public class CartLine
     {
          public Product Product { get; set; }

          public int Quantity { get; set; }
     }
}
