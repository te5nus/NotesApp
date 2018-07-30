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
    public class JustNoteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Note Note { get; set; }
        public JustNoteModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public async Task OnGetAsync(Guid id)
        {
            Note = await _context.Notes.FindAsync(id);
        }
    }
}