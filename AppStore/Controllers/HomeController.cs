using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AppStore.Models;
using AppContext = AppStore.Models.AppContext;

namespace AppStore.Controllers
{
    public class HomeController : Controller
    {
        AppContext db = new AppContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Employee);

            return View(products.ToList());
        }

        public ActionResult FirstProduct()
        {
            var firstProduct = db.Products.FirstOrDefault();

            return View(firstProduct);
        }

        public ActionResult PageView(int page = 1)
        {
            var products = db.Products.Include(p => p.Employee).ToList();
            int pageSize = 5;
            IEnumerable<Product> productsOnPage = products.Skip((page - 1) * pageSize).Take(pageSize);
            var pagingModel = new PagingModel { PageNumber = page, PageSize = pageSize, TotalProducts = products.Count };
            var viewProducts = new ViewProducts { Products = productsOnPage, PagingModel = pagingModel };

            return View(viewProducts);
        }

        public ActionResult FilterView(int? employeeId)
        {
            var products = db.Products.Include(p => p.Employee);
            if (employeeId != null && employeeId != 0)
            {
                products = products.Where(e => e.EmployeeId == employeeId);
            }
            var employees = db.Employees.ToList();
            employees.Insert(0, new Employee { Surname = "Все сотрудники", Id = 0 });
            ProductFilterList productFilterList = new ProductFilterList
            {
                Products = products.ToList(),
                Employees = new SelectList(employees, "Id", "Surname")
            };

            return View(productFilterList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList employees = new SelectList(db.Employees, "Id", "Surname");
            ViewBag.Employees = employees;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                 SelectList employees = new SelectList(db.Employees, "Id", "Surname", product.EmployeeId);
                 ViewBag.Employees = employees;

                return View(product);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                Employee employee = db.Employees.Find(product.EmployeeId);
                ViewBag.Employee = employee;

                return View(product);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}