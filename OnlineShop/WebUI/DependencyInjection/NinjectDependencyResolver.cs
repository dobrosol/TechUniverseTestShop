using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Concrete.ProductEntities;
using Ninject;

namespace WebUI.DependencyInjection
{
     public class NinjectDependencyResolver: IDependencyResolver
     {
          IKernel kernel;

          public NinjectDependencyResolver(IKernel kernelParam)
          {
               kernel = kernelParam;

               AddBindings();
          }
          public object GetService(Type serviceType)
          {
               return kernel.Get(serviceType);
          }

          public IEnumerable<object> GetServices(Type serviceType)
          {
               return kernel.GetAll(serviceType);
          }

          private void AddBindings()
          {
               kernel.Bind<IShopRepository>().To<ShopRepository>();
               kernel.Bind<ICartRepository>().To<ShopRepository>();
               kernel.Bind<IOrderRepository>().To<ShopRepository>();
               kernel.Bind<IProductRepository<ASC>>().To<ShopRepository>();
               kernel.Bind<IProductRepository<Case>>().To<ShopRepository>();
          }
     }
}