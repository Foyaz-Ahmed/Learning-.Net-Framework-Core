using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurseyBazar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JurseyBazar.Pages.JurseyList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Jursey Jursey { set; get; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Jursey = new Jursey();
            if (id == null)
            {
                //create
                return Page();
            }
            else
            {   //update
                Jursey = await _db.Jursey.FirstOrDefaultAsync(e => e.Id == id);
                if (Jursey == null) {

                    return NotFound();
                }
                return Page();
            }
           
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Jursey.Id == 0)
                {
                    _db.Add(Jursey);
                }
                else
                {
                    _db.Jursey.Update(Jursey);
                }
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
