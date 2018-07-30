﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task OnGetAsync()
        {
            Notes = await _context.Notes.AsNoTracking().ToListAsync();
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