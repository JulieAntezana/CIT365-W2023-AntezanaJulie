using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpScripture.Models;

namespace RpScripture.Data
{
    public class RpScriptureContext : DbContext
    {
        public RpScriptureContext (DbContextOptions<RpScriptureContext> options)
            : base(options)
        {
        }

        public DbSet<RpScripture.Models.Scripture> Scripture { get; set; } = default!;
    }
}
