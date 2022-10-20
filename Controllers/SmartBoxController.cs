using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{
    public class SmartBoxController : Controller
    {
        // GET: SmartBoxController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SmartBoxController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SmartBoxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmartBoxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SmartBoxController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SmartBoxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SmartBoxController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SmartBoxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
