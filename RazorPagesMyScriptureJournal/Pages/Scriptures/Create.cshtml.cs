using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMyScriptureJournal.Data;
using RazorPagesMyScriptureJournal.Models;

namespace RazorPagesMyScriptureJournal.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext _context;

        public CreateModel(RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyScriptureJournal MyScriptureJournal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MyScriptureJournal == null || MyScriptureJournal == null)
            {
                return Page();
            }

            _context.MyScriptureJournal.Add(MyScriptureJournal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
