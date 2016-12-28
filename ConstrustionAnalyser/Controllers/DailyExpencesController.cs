using ConstrustionAnalyser.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstrustionAnalyser.Models;

namespace ConstrustionAnalyser.Controllers
{
    public class DailyExpencesController : Controller
    {
        // GET: DailyExpences
        public ActionResult GetExpences()
        {
            Rep_DailyExpences ExpRepo = new Rep_DailyExpences();
            ModelState.Clear();
            return View("GetAllDailyExpences", ExpRepo.GetAllExpences());
        }


        // GET: DailyExpences/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DailyExpences/Create
        public ActionResult Create()
        {
            return View("CreateExpences");
        }

        // POST: DailyExpences/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DailyExpences de = new DailyExpences();



                de.expenceDate = DateTime.Parse(Convert.ToString(Request.Form["expenceDate"]));
                de.expenceDescription = Convert.ToString(Request.Form["expenceDescription"]);
                de.expencesAmount = Convert.ToDouble(Request.Form["expencesAmount"]);
                de.remark = Convert.ToString(Request.Form["remark"]);

                Rep_DailyExpences expRepo = new Rep_DailyExpences();
                expRepo.AddDailyExpences(de);
                //return RedirectToAction("..//home//Index");
                return RedirectToAction("GetExpences");
            }
            catch
            {
                return View();
            }
        }


        // GET: DailyExpences/Edit/5
        public ActionResult Edit(int id)
        {
            // TODO: Add update logic here
            Rep_DailyExpences expRepo = new Rep_DailyExpences();
            return View("EditExpences", expRepo.GetExpence(id));
        }

        // POST: DailyExpences/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DailyExpences de = new DailyExpences();

                de.expenceDate = DateTime.Parse(Convert.ToString(Request.Form["expenceDate"]));
                de.expenceDescription = Convert.ToString(Request.Form["expenceDescription"]);
                de.expencesAmount = Convert.ToDouble(Request.Form["expencesAmount"]);
                de.remark = Convert.ToString(Request.Form["remark"]);
                de.DailyExpencesId = id;

                Rep_DailyExpences expRepo = new Rep_DailyExpences();
                expRepo.UpdateExpence(de);
                return RedirectToAction("GetExpences");
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetExpences");
            }
        }

        // GET: DailyExpences/Delete/5
        public ActionResult Delete(int id)
        {
            // TODO: Add update logic here
            Rep_DailyExpences expRepo = new Rep_DailyExpences();
            if (expRepo.DeleteExpence(id))
                return RedirectToAction("GetExpences");
            else
                return RedirectToAction("GetExpences");
        }

        // POST: DailyExpences/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
