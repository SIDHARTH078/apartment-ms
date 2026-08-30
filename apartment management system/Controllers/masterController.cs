using apartment_management_system.Data;
using apartment_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apartment_management_system.Controllers
{
    public class masterController :Controller
    {
       
        private readonly ApplicationDbContext _db;

        public masterController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult createmenu()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult createmenu(menu abc)
        {
            if (ModelState.IsValid)
            {
                _db.owner.Add(abc);
                _db.SaveChanges();
                return RedirectToAction("createmenu");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> deletemenu(int? id)
        {
            if (id == null) return NotFound();

            var owner = await _db.owner.FirstOrDefaultAsync(m => m.OwnerID == id);
            if (owner == null) return NotFound();

            return View(owner);
        }

        // POST: OwnerMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deletemenu(int id)
        {
            var owner = await _db.owner.FindAsync(id);
            if (owner != null)
            {
                _db.owner.Remove(owner);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _db.owner.ToListAsync());
        }



    }
}
