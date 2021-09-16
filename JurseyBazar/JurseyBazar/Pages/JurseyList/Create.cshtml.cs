using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurseyBazar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JurseyBazar.Pages.JurseyList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Jursey Jursey {set; get;}
        public void OnGet()
        {
        }
        public async Task <IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Jursey.AddAsync(Jursey);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
