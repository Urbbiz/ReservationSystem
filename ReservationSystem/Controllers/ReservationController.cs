using ReservationSystem.Models;
using ReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ReservationSystem.Controllers
{
    public class ReservationController : Controller
    {

        private readonly ReservationRepository _repository;

        public ReservationController(ReservationRepository repository)
        {
            _repository = repository;
        }


        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Post(Reservation model)
        {
            if (ModelState.IsValid)
            {
                await _repository.Post(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}