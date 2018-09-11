using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Concrete.Identity;
using Domain.Concrete.ProductEntities;

namespace Domain.Concrete
{
     public class ShopRepository: IShopRepository, ICartRepository, IOrderRepository, IProductRepository<ASC>, IProductRepository<Case>
     {
          ShopDBContext context = new ShopDBContext();

          public static ShopDBContext Shop()
          {
               return new ShopDBContext();
          }
                   
          public ShopDBContext Products
          {
               get { return context; }
          }

          #region Заказы, профили
          public IEnumerable<Order> Orders
          {
               get { return context.Orders; }
          }
          public IEnumerable<UserProfile> Profiles
          {
               get { return context.Profiles; }
          }

          public void SaveOrder(Order order)
          {
               context.Orders.Add(order);

               context.SaveChanges();
          }
          #endregion

          #region ASC
          IEnumerable<ASC> IProductRepository<ASC>.Product
          {
               get { return context.ASCs; }
          }

          void IProductRepository<ASC>.Save(ASC product)
          {
               product.Category = "ASC";

               if (product.Id == 0)
                    context.ASCs.Add(product);
               else
               {
                    ASC ascTemp = context.ASCs.Find(product.Id);

                    if (ascTemp != null)
                    {
                         ascTemp.Name = product.Name;
                         ascTemp.Category = product.Category;
                         ascTemp.Company = product.Company;
                         ascTemp.Description = product.Description;
                         ascTemp.FanDiameter = product.FanDiameter;
                         ascTemp.Price = product.Price;
                         ascTemp.ImageType = product.ImageType;
                         ascTemp.ImageData = product.ImageData;
                         ascTemp.Type = product.Type;
                    }
               }
               context.SaveChanges();
          }

          ASC IProductRepository<ASC>.Delete(int id)
          {
               ASC ascTemp = context.ASCs.Find(id);

               context.ASCs.Remove(ascTemp);

               context.SaveChanges();

               return ascTemp;
          }
          #endregion

          #region Case
          IEnumerable<Case> IProductRepository<Case>.Product
          {
               get { return context.Cases; }
          }

          void IProductRepository<Case>.Save(Case product)
          {
               product.Category = "Case";

               if (product.Id == 0)
                    context.Cases.Add(product);
               else
               {
                    Case caseTemp = context.Cases.Find(product.Id);

                    if (caseTemp != null)
                    {
                         caseTemp.Name = product.Name;
                         caseTemp.Category = product.Category;
                         caseTemp.Company = product.Company;
                         caseTemp.Description = product.Description;
                         caseTemp.PSU = product.PSU;
                         caseTemp.Price = product.Price;
                         caseTemp.ImageType = product.ImageType;
                         caseTemp.ImageData = product.ImageData;
                         caseTemp.FormFactor = product.FormFactor;
                    }
               }
               context.SaveChanges();
          }

          Case IProductRepository<Case>.Delete(int id)
          {
               Case caseTemp = context.Cases.Find(id);

               context.Cases.Remove(caseTemp);

               context.SaveChanges();

               return caseTemp;
          }
          #endregion
     }
}
