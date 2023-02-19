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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext _context;

        public DetailsModel(RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext context)
        {
            _context = context;
        }

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
    }
}
