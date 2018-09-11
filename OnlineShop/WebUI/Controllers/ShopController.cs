using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Concrete.ProductEntities;
using WebUI.Models;
using WebUI.Models.PageModels;
using WebUI.Models.PageModels.ProductViews;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
          IShopRepository repository;

          public ShopController(IShopRepository repository)
          {
               this.repository = repository;
          }

          public ActionResult List(ProductViewModel model, string expression)
          {
               model.Products = ControllerHelper<Product>.GetFindList(repository, expression);

               model.FindExpression = expression;

               return View(model);
          }

          public ActionResult GetList(ProductViewModel model, int page = 1, int sortType = 1)
          {
               model.PageInfo.CurrentPage = page;
               model.SortTypeChange = sortType;

               return PartialView("ListPartialView", model);
          }

          public ActionResult GetAction(string targetAction, string productId, string productCategory, string returnUrl, string expression)
          {
               returnUrl = ControllerHelper<Product>.ProcessUrl(returnUrl, expression);

               return RedirectToAction("GetProduct", productCategory, new { targetAct = targetAction, id = productId, url = returnUrl });
          }

          public ActionResult GetSummary(Product product, string findExpression)
          {
               TempData["findExpression"] = findExpression;

               return PartialView("ProductSummary", product);
          }
          public ActionResult GetSummaryAdmin(Product product, string findExpression)
          {
               TempData["findExpression"] = findExpression;
               return PartialView("ProductSummaryAdmin", product);
          }
          public ActionResult GetFilterEdit(string updateTargetId, bool isAdministrator, string category)
          {
               var model = new FilterEditViewModel(updateTargetId, isAdministrator, category);

                return PartialView("FilterEditPartialView", model);
          }
          public ActionResult GetSortMenu(string category, string categoryName, int page, string updateTargetId)
          {
               var model = new SortMenuViewModel()
               {
                    Category = category,
                    CategoryName = categoryName,
                    Page = page,
                    UpdateTargetId = updateTargetId
               };

               return PartialView("SortMenuPartialView", model);
          }

          // GET: Shop
          public ActionResult Index()
          {
               return View();
          }
    }
}