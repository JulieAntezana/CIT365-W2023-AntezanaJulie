using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scripture.Data;
using Scripture.Models;

namespace Scripture.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly Scripture.Data.ScriptureContext _context;

        public IndexModel(Scripture.Data.ScriptureContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Scripture != null)
            {
                Scripture = await _context.Scripture.ToListAsync();
            }
        }
    }
}
