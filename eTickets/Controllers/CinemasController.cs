using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers {
    public class CinemasController : Controller {

        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        public async Task<IActionResult> Details(int id) {
            var cinema = await _service.GetAsync(id);
            if (cinema == null)
                return RedirectToAction(nameof(Index));
            return View(cinema);
        }

        //GET: cinemas/create
        public async Task<IActionResult> Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageUrl,Name,Description")] Cinema cinema) {
            if (!ModelState.IsValid) return View(cinema);
            
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET: cinemas/edit/1
        public async Task<IActionResult> Edit(int id) {
            var cinema = await _service.GetAsync(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ImageUrl,Name,Description")] Cinema cinema) {
            if (!ModelState.IsValid) return View(cinema);

            await _service.EditAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET: cinemas/delete/1
        public async Task<IActionResult> Delete(int id) {
            var cinema = await _service.GetAsync(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id) {
            var cinema = await _service.GetAsync(id);
            if (cinema == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
