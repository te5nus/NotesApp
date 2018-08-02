using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Model;

namespace NotesApp.Pages
{
    public class MyNotesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Note> Notes { get; set; }
        public MyNotesModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public async Task OnGetAsync(IdentityUser user)
        {
            Notes = await _context.Notes.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostFilterByTitleAsync(string title)
        {
            var temp = from m in _context.Notes select m;
            if (!String.IsNullOrEmpty(title))
            {
                temp = temp.Where(s => s.Title.Contains(title));
            }
            Notes = await temp.ToListAsync();
            if (Notes == null)
            {
                return NotFound();
            }
            return Page();

        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}