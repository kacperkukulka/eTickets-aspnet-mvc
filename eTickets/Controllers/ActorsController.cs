using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers {
    public class ActorsController : Controller {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageUrl, FullName, Bio")]Actor actor) {

            if (!ModelState.IsValid) {
                return View(actor);
            }

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id) {
            var actor = await _service.GetAsync(id);
            if (actor == null) return View("NotFound");
            return View(actor);
        }

        public async Task<IActionResult> Edit(int id) {
            var actor = await _service.GetAsync(id);
            if (actor == null) return View("NotFound");
            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ImageUrl, FullName, Bio")] Actor actor) {

            if (!ModelState.IsValid) {
                return View(actor);
            }

            await _service.EditAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id) {
            var actor = await _service.GetAsync(id);
            if (actor == null) return View("NotFound");
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var actor = await _service.GetAsync(id);
            if (actor == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
