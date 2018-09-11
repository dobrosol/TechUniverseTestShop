using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Concrete.ProductEntities;
using WebUI.Models;
using WebUI.Models.PageModels;

namespace WebUI.Controllers
{
    public class ASCController : Controller
    {
          IProductRepository<ASC> repository;

          ControllerHelper<ASC> helper;

          public ASCController(IProductRepository<ASC> repository)
          {
               this.repository = repository;

               helper = new ControllerHelper<ASC>(repository);
          }

          // GET: ASC
          public ActionResult List(ASCViewModel model)
          {
               model.Company.Clear();
               model.FanDiameter.Clear();

               return View(model);
          }

          public PartialViewResult GetList(ASCViewModel model, string comp = null, int fanDiameter = 0, int page = 1, int sortType = 1)
          {
               model.Products = repository.Product.ToList();
               model.PageInfo.CurrentPage = page;
               model.SortTypeChange = sortType;

               if (comp != null)
               {
                    if (!model.Company.Contains(comp))
                         model.Company.Add(comp);
                    else
                         model.Company.Remove(comp);
               }
               if (fanDiameter != 0)
               {
                    if (!model.FanDiameter.Contains(fanDiameter))
                         model.FanDiameter.Add(fanDiameter);
                    else
                         model.FanDiameter.Remove(fanDiameter);
               }

               return PartialView("ListPartialView", model);
          }

          public ActionResult RefreshFilters(ASCViewModel model)
          {
               model.Company.Clear();
               model.FanDiameter.Clear();

               return RedirectToAction("GetList", new { sortType = model.SortTypeChange});
          }

          public ActionResult GetProduct(string targetAct, int id, string url)
          {
               var result = helper.GetProduct(id);

               TempData["returnUrl"] = url;

               return View(targetAct, result);
          }

          public FileContentResult GetImage(int id)
          {
               return helper.GetImage(id);
          }

          [ChildActionOnly]
          public ActionResult GetGroups(ASCViewModel model)
          {
               Dictionary<string, bool> filterCompanies = new Dictionary<string, bool>();

               foreach (var company in repository.Product.Select(a => a.Company).Distinct())
               {
                    if (model.Filters.Contains(company))
                         filterCompanies.Add(company, true);
                    else
                         filterCompanies.Add(company, false);
               }

               Dictionary<int, bool> filterFanDiameter = new Dictionary<int, bool>();

               foreach (var fanDiamater in repository.Product.Select(a => a.FanDiameter).Distinct())
               {
                    if (model.Filters.Contains(fanDiamater.ToString()))
                         filterFanDiameter.Add(fanDiamater, true);
                    else
                         filterFanDiameter.Add(fanDiamater, false);
               }
               
               ViewBag.Companies = filterCompanies;
               ViewBag.FanDiameters = filterFanDiameter;

               return PartialView("GroupMenu", model);         
          }

          public ActionResult AddProduct(Cart cart, int id)
          {
               helper.AddProduct(cart, id);

               return RedirectToAction("Summary", "Cart");
          }

          [Authorize(Roles = "Admin")]
          public ActionResult Edit(int id, string url)
          {
               var result = helper.GetProduct(id);

               TempData["returnUrl"] = url;

               return View(result);
          }

          [Authorize(Roles = "Admin")]
          [HttpPost]
          public ActionResult Edit(ASC product, string url, HttpPostedFileBase image = null)
          {
               TempData["returnUrl"] = url;

               if (ModelState.IsValid)
               {
                    helper.EditProduct(product, image);

                    return RedirectToAction("List");
               }
               else
                    return View(product);
          }

          public ActionResult Delete(int id)
          {
               helper.DeleteProduct(id);

               return RedirectToAction("List");
          }
     }
}

//Высококачественный черный вентилятор DeepCool.Низкая скорость вращения обеспечивает тихую работу.Оснащен сразу двумя разъемами для подключения (трехконтактным и четырехштырьковым «Molex»)