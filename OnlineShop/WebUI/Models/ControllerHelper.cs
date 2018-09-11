using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Concrete.ProductEntities;

namespace WebUI.Models
{
     public class ControllerHelper<T> where T:Product
     {
          IProductRepository<T> repository;

          public ControllerHelper(IProductRepository<T> repository)
          {
               this.repository = repository;
          }

          public static string ProcessUrl(string returnUrl, string findExpression)
          {
               if (returnUrl.ToLower().Contains("shop/list"))
                    returnUrl = string.Format("/Shop/List?expression={0}", findExpression);

               if (returnUrl.ToLower().Contains("getlist"))
                    returnUrl = returnUrl.Replace("GetList", "List");

               return returnUrl;
          }

          public static List<Product> GetFindList<U>(U repository, string expression) where U:IShopRepository
          {
               var ASCResult = repository.Products.ASCs.Where(p => p.Name.ToLower().Contains(expression.ToLower()))
                    .Concat(repository.Products.ASCs.Where(p => p.Company.ToLower().Contains(expression.ToLower()))) as IEnumerable<Product>;
               var CaseResult = repository.Products.Cases.Where(p => p.Name.ToLower().Contains(expression.ToLower()))
                    .Concat(repository.Products.Cases.Where(p => p.Company.ToLower().Contains(expression.ToLower()))) as IEnumerable<Product>;

               var result = ASCResult.Concat(CaseResult);

               return result.Distinct().ToList();
          }

          public T GetProduct(int id)
          {
               return repository.Product.FirstOrDefault(a => a.Id == id);
          }

          public FileContentResult GetImage(int id)
          {
               var product = repository.Product.FirstOrDefault(a => a.Id == id);

               if (product != null)
                    return new FileContentResult(product.ImageData, product.ImageType);
               else
                    return null;
          }

          public void DeleteProduct(int id)
          {
               repository.Delete(id);
          }

          public void EditProduct(T product, HttpPostedFileBase image)
          {
               if (image != null)
               {
                    product.ImageType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];

                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
               }

               repository.Save(product);
          }

          public void AddProduct(Cart cart, int id)
          {
               var product = repository.Product.FirstOrDefault(a => a.Id == id);

               cart.AddItem(product, 1);
          }
     }
}