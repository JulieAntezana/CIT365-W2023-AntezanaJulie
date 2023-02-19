using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMyScriptureJournal.Data;
using RazorPagesMyScriptureJournal.Models;

namespace RazorPagesMyScriptureJournal.Pages.Scriptures
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext _context;

        public EditModel(RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext context)
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

            var myscripturejournal =  await _context.MyScriptureJournal.FirstOrDefaultAsync(m => m.Id == id);
            if (myscripturejournal == null)
            {
                return NotFound();
            }
            MyScriptureJournal = myscripturejournal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MyScriptureJournal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyScriptureJournalExists(MyScriptureJournal.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MyScriptureJournalExists(int id)
        {
          return (_context.MyScriptureJournal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
