using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMyScriptureJournal.Models;

namespace RazorPagesMyScriptureJournal.Data
{
    public class RazorPagesMyScriptureJournalContext : DbContext
    {
        public RazorPagesMyScriptureJournalContext (DbContextOptions<RazorPagesMyScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMyScriptureJournal.Models.MyScriptureJournal> MyScriptureJournal { get; set; } = default!;
    }
}
