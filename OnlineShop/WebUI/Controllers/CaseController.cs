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
    public class CaseController : Controller
    {
          IProductRepository<Case> repository;

          ControllerHelper<Case> helper;

          public CaseController(IProductRepository<Case> repository)
          {
               this.repository = repository;

               helper = new ControllerHelper<Case>(repository);
          }

          public ActionResult List(CaseViewModel model)
          {
               model.PSU.Clear();
               model.FormFactor.Clear();

               return View(model);
          }

          public PartialViewResult GetList(CaseViewModel model, string comp=null, string form = null, string psu = null, int page = 1, int sortType = 1)
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
               if (form != null)
               {
                    if (!model.FormFactor.Contains(form))
                         model.FormFactor.Add(form);
                    else
                         model.FormFactor.Remove(form);
               }
               if (psu != null)
               {
                    if (!model.PSU.Contains(psu))
                         model.PSU.Add(psu);
                    else
                         model.PSU.Remove(psu);
               }

               return PartialView("ListPartialView", model);
          }

          public ActionResult RefreshFilters(CaseViewModel model)
          {
               model.PSU.Clear();
               model.FormFactor.Clear();
               model.Company.Clear();

               return RedirectToAction("GetList", new { sortType = model.SortTypeChange });
          }

          public FileContentResult GetImage(int id)
          {
               return helper.GetImage(id);
          }

          public ActionResult GetProduct(string targetAct, int id, string url)
          {
               TempData["returnUrl"] = url;

               return View(targetAct, helper.GetProduct(id));
          }

          [ChildActionOnly]
          public ActionResult GetGroups(CaseViewModel model)
          {
               Dictionary<string, bool> filterCompanies = new Dictionary<string, bool>();

               foreach (var company in repository.Product.Select(a => a.Company).Distinct())
               {
                    if (model.Filters.Contains(company))
                         filterCompanies.Add(company, true);
                    else
                         filterCompanies.Add(company, false);
               }

               Dictionary<string, bool> filterPSU = new Dictionary<string, bool>();

               foreach (var PSU in repository.Product.Select(a => a.PSU).Distinct())
               {
                    if (model.PSU.Contains(PSU))
                         filterPSU.Add(PSU, true);
                    else
                         filterPSU.Add(PSU, false);
               }

               Dictionary<string, bool> filterFormFactor = new Dictionary<string, bool>();

               foreach (var formFactor in repository.Product.Select(a => a.FormFactor).Distinct())
               {
                    if (model.Filters.Contains(formFactor))
                         filterFormFactor.Add(formFactor, true);
                    else
                         filterFormFactor.Add(formFactor, false);
               }

               ViewBag.Companies = filterCompanies;
               ViewBag.PSUs = filterPSU;
               ViewBag.FormFactors = filterFormFactor;

               return PartialView("GroupMenu", model);
          }

          public ActionResult AddProduct(Cart cart, int id)
          {
               helper.AddProduct(cart, id);

               return RedirectToAction("Summary", "Cart");
          }

          [Authorize(Roles = "Admin")]
          [HttpPost]
          public ActionResult Edit(Case product, string url, HttpPostedFileBase image = null)
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