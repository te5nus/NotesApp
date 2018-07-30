using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Data;
using NotesApp.Model;

namespace NotesApp.Pages.Notes
{
    public class NewNoteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Note Note { get; set; }
        public NewNoteModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(Note);
                await _context.SaveChangesAsync();
                return RedirectToPage("MyNotes");
            }
            return Page();
        }
    }
}