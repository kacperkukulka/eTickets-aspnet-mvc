using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace eTickets.Controllers {
    public class ProducersController : Controller {

        private readonly IProducersService _service;

        public ProducersController(IProducersService service){
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //GET: producers/details/1
        public async Task<IActionResult> Details(int id) {
            var producer = await _service.GetAsync(id);
            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        //GET: producers/create
        public async Task<IActionResult> Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageUrl,FullName,Bio")]Producer producer) {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id) {
            var producer = await _service.GetAsync(id);
            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ImageUrl,FullName,Bio")] Producer producer) {
            if (!ModelState.IsValid) return View(producer);

            await _service.EditAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id) {
            var producer = await _service.GetAsync(id);
            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        [HttpPost, ActionName("Delete")] 
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (await _service.GetAsync(id) == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
