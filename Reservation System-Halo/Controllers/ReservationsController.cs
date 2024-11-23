using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL4.Controllers.Bases;
using BLL4.Services;
using BLL4.Models;

// Generated from Custom Template.

namespace Reservation_System_Halo.Controllers
{
    public class ReservationsController : MvcController
    {
        // Service injections:
        private readonly IReservationService _reservationService;
        private readonly ICustomerService _customerService;
        private readonly ITableService _tableService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public ReservationsController(
			IReservationService reservationService
            , ICustomerService customerService
            , ITableService tableService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _reservationService = reservationService;
            _customerService = customerService;
            _tableService = tableService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Reservations
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _reservationService.Query().ToList();
            return View(list);
        }

        // GET: Reservations/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _reservationService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["CustomerId"] = new SelectList(_customerService.Query().ToList(), "Record.Id", "Name");
            ViewData["TableId"] = new SelectList(_tableService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _reservationService.Create(reservation.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = reservation.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _reservationService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Reservations/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _reservationService.Update(reservation.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = reservation.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _reservationService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Reservations/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _reservationService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
