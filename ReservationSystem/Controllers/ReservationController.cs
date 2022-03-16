using ReservationSystem.Models;
using ReservationSystem.Repositories;
using ReservationSystem.Services;
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
        private readonly ReservationService _service;

        public ReservationController(ReservationRepository repository, ReservationService service)
        {
            _repository = repository;
            _service = service;
        }




        // GET: Reservation
        public ActionResult Index()
        {
            var reservations = _repository.GetAll();
            
            return View(reservations);
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

       public async Task<ActionResult> Edit(int id)
        {

            var reservationById = await _repository.GetById(id);
            return View(reservationById);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit (int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                await _repository.Edit(reservation);
                return RedirectToAction("Index");
            }

            var reservationById = await _repository.GetById(id);
            return View(reservationById);

        }


        public async Task<ActionResult> Details(int id)
        {
            var reservationById = await _repository.GetById(id);
            return View(reservationById);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return HttpNotFound();
            }

            await _repository.Delete(id);
            return RedirectToAction("Index");   
        }
    }
}