using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMyScriptureJournal.Data;
using RazorPagesMyScriptureJournal.Models;

namespace RazorPagesMyScriptureJournal.Pages.Scriptures
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext _context;

        public DeleteModel(RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MyScriptureJournal MyScriptureJournal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MyScriptureJournal == null)
            {
                return NotFound();
            }

            var myscripturejournal = await _context.MyScriptureJournal.FirstOrDefaultAsync(m => m.Id == id);

            if (myscripturejournal == null)
            {
                return NotFound();
            }
            else 
            {
                MyScriptureJournal = myscripturejournal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MyScriptureJournal == null)
            {
                return NotFound();
            }
            var myscripturejournal = await _context.MyScriptureJournal.FindAsync(id);

            if (myscripturejournal != null)
            {
                MyScriptureJournal = myscripturejournal;
                _context.MyScriptureJournal.Remove(MyScriptureJournal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
