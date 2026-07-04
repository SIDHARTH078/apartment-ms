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
                _db.ownermaster.Add(abc);
                _db.SaveChanges();
                return RedirectToAction("createmenu");
            }
            return View();
        }

        public async Task<IActionResult> deletemenu(int? id)
        {
            if (id == null) return NotFound();

            var OwnerMaster = await _db.ownermaster.FirstOrDefaultAsync(m => m.OwnerID == id);
            if (OwnerMaster == null) return NotFound();

            return View(OwnerMaster);
        }

        // POST: OwnerMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deletemenu(int id)
        {
            var OwnerMaster = await _db.ownermaster.FindAsync(id);
            if (OwnerMaster != null)
            {
                _db.ownermaster.Remove(OwnerMaster);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _db.ownermaster.ToListAsync());
        }



    }
}
