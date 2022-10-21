using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize] // Qui entra la gente autorizzata
    public class SmartBoxController : Controller
    {
        private readonly ILogger<SmartBoxController> _logger;

        public SmartBoxController(ILogger<SmartBoxController> logger)
        {
            _logger = logger;
        }

        // db globale solo nel genitore 
        SmartBoxContext sbc = new SmartBoxContext();

        // GET: SmartBoxController -- Mostrai i dati tipo vetrina
        //public ActionResult Index()
        //{

        //    List<SmartBox> smartBox = sbc.smartBoxes.ToList();
        //    return View("Index", sbc);

        //}
        public async Task<IActionResult> Index()
        {
            return View(await sbc.smartBoxes.ToListAsync());
        }

        // GET: SmartBoxController/Details/5 -- Mostra solo i dati singoli "dettaglio"
        public ActionResult Detail(int id)
        {
            SmartBox smartBoxObj  = sbc.smartBoxes.Where(obj => obj.Id == id).FirstOrDefault();

            //Se la smartbox non viene trovata
            if (smartBoxObj == null)
            {
                return NotFound($"La smartbox con id {id} non è stata trovata");
            }
            else //Altrimenti viene passata alla vista 
            {
                return View("Detail", smartBoxObj);
            }
       
        }

        // GET: SmartBoxController/Create -- Mostra solo la pagina singola "creazione"
        public ActionResult Create()
        {
            SmartBox smartbox = new SmartBox();
            return View(smartbox);
        }

        // POST: SmartBoxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SmartBox formData)
        {
            if (!ModelState.IsValid)
            {
                //smartboxcontext aggiungi formdata dalla pagina
                sbc.Add(formData);
           
                return View("Create", formData);
            }
            //formData = new SmartBox();
            //formData = sbc.smartBoxes.FirstOrDefault();
            //sbc.smartBoxes.Add(formData);
            //sbc.SaveChanges();
            //return RedirectToAction("Index");
            {

                SmartBox smartbox = new SmartBox();

                smartbox.Name = formData.Name;
                smartbox.Description = formData.Description;
                smartbox.Image = formData.Image;
                smartbox.Price = formData.Price;

                sbc.smartBoxes.Add(smartbox);

                sbc.SaveChanges();

                return RedirectToAction("Index");
                
            }
        }

        // GET: SmartBoxController/Edit/5 -- Mostra solo la pagina singola "Modifica"
        public ActionResult Edit(int id)
        {
            SmartBox smartBoxEdit = sbc.smartBoxes.Where(obj => obj.Id == id).FirstOrDefault();
            if (smartBoxEdit == null)
            {
                return NotFound();
            }

            return View(smartBoxEdit);

        }

        // POST: SmartBoxController/Edit/5 -- Invia i dati compilati
        [HttpPost]
     
        public ActionResult Edit(int id, SmartBox formData)
        {
            if (!ModelState.IsValid)
            {
                //smartboxcontext aggiungi formdata dalla pagina
                sbc.Add(formData);
                sbc.SaveChanges();
                return View("Edit", formData);
            }
            formData.Id = id;
            sbc.smartBoxes.Update(formData);
            sbc.SaveChanges();
            return RedirectToAction("Index");
        }

       
        // POST: SmartBoxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            SmartBox smartBoxDelete = sbc.smartBoxes.Where(obj => obj.Id == id).FirstOrDefault();
            
            if (smartBoxDelete is null) return RedirectToAction("Index");
            
                sbc.smartBoxes.Remove(smartBoxDelete);
                sbc.SaveChanges();
                return RedirectToAction("Index");


        }
    }
}
