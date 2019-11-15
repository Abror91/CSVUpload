using LINQtoCSV;
using SynelAppDemo.Context;
using SynelAppDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SynelAppDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortOrder = "", int effectedRows = 0)
        {
            ViewBag.SortParam = string.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.Rows = effectedRows;
            using (AppDbContext db = new AppDbContext())
            {
                var employees = new List<Employee>();
                if (sortOrder == "desc")
                {
                    employees = db.Employees.OrderByDescending(s => s.Surname).ToList();
                }
                else
                {
                    employees = db.Employees.OrderBy(s => s.Surname).ToList();
                }
                return View(employees);
            }
        }

        [HttpPost]
        public ActionResult UploadCsvFile(HttpPostedFileBase uploadedFile)
        {
            using (AppDbContext db = new AppDbContext())
            {
                CsvFileDescription csvFileDescriotion = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true
                };
                CsvContext csvContext = new CsvContext();
                StreamReader streamReader = new StreamReader(uploadedFile.InputStream);
                IEnumerable<Employee> employees = csvContext.Read<Employee>(streamReader, csvFileDescriotion);
                var rows = employees.Count();
                db.Employees.AddRange(employees);
                db.SaveChanges();
                return RedirectToAction("Index", new { effectedRows = rows });
            }
        }
    }
}