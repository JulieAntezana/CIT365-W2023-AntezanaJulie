using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scripture.Models;

namespace Scripture.Data
{
    public class ScriptureContext : DbContext
    {
        public ScriptureContext (DbContextOptions<ScriptureContext> options)
            : base(options)
        {
        }

        public DbSet<Scripture.Models.Scripture> Scripture { get; set; } = default!;
    }
}
