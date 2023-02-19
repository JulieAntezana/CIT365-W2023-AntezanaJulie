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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext _context;

        public IndexModel(RazorPagesMyScriptureJournal.Data.RazorPagesMyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<MyScriptureJournal> MyScriptureJournal { get;set; } = default!;

        // Sorting
        //public string BookSort { get; set; }
        //public string DateSort { get; set; }
        //public string CurrentFilter { get; set; }
        //public string CurrentSort { get; set; }

        // Search functionality
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string SearchSelection { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            //order

            var entries = from m in _context.MyScriptureJournal
                          select m;

            //// sort
            //BookSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        entries = entries.OrderByDescending(s => s.Book);
            //        break;
            //    case "Date":
            //        entries = entries.OrderBy(s => s.EntryDate);
            //        break;
            //    case "date_desc":
            //        entries = entries.OrderByDescending(s => s.EntryDate);
            //        break;
            //    default:
            //        entries = entries.OrderBy(s => s.Book);
            //        break;
            //}

            // Search
            if (SearchString == "Book")
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    entries = entries.Where(s => s.Scripture.Contains(SearchString));
                }
            }
            //else if (SearchSelection == "Notes")
            //{
            //    if (!string.IsNullOrEmpty(SearchSelection))
            //    {
            //        entries = entries.Where(x => x.Notes.Contains(SearchString));
            //    }
            //}

            MyScriptureJournal = await entries.ToListAsync();
        }
    }
}
