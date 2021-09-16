using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurseyBazar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JurseyBazar.Pages.JurseyList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Jursey Jursey { set; get; }
        public async Task OnGet(int id)
        {
            Jursey =  await _db.Jursey.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var jurseyFromDb = await _db.Jursey.FindAsync(Jursey.Id);

                jurseyFromDb.Name = Jursey.Name;
                jurseyFromDb.TeamsName = Jursey.TeamsName;
                jurseyFromDb.Price = Jursey.Price;
                jurseyFromDb.Quantity = Jursey.Quantity;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
