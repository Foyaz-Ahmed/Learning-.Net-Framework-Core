using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurseyBazar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JurseyBazar.Pages.JurseyList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Jursey> Jurseys { set; get; }

        public async Task OnGet()
        {
            Jurseys = await _db.Jursey.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var jurseyFromDb = await _db.Jursey.FindAsync(id);

            if (jurseyFromDb == null)
            {
                return NotFound();
            }
            else
            {
                _db.Jursey.Remove(jurseyFromDb);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
        }
    }
}