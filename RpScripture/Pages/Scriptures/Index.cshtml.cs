using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RpScripture.Data;
using RpScripture.Models;

namespace RpScripture.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly RpScripture.Data.RpScriptureContext _context;

        public IndexModel(RpScripture.Data.RpScriptureContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; } = default!;
 
        // Sorting
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        // Search functionality
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Book { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ScriptureBook { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;
            var entries = from m in _context.Scripture
                             select m;

            // sort
            BookSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    entries = entries.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    entries = entries.OrderBy(s => s.EntryDate);
                    break;
                case "date_desc":
                    entries = entries.OrderByDescending(s => s.EntryDate);
                    break;
                default:
                    entries = entries.OrderBy(s => s.Book);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                entries = entries.Where(x => x.Book == ScriptureBook);
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await entries.ToListAsync();
        }
    }
}

