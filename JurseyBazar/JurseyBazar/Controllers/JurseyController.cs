using JurseyBazar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurseyBazar.Controllers
{
    [Route("api/Jursey")]
    [ApiController]
    public class JurseyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public JurseyController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Jursey.ToListAsync()});
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var jurseyFromDb = await _db.Jursey.FirstOrDefaultAsync(e => e.Id == id);
            
            if(jurseyFromDb == null)
            {
                return Json(new { success = false, message = "error occurs when attempt to download" });
            }
            _db.Jursey.Remove(jurseyFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted Successfully done"});
        }
    }
}
