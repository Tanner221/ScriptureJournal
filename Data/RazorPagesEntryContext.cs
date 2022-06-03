using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

    public class RazorPagesEntryContext : DbContext
    {
        public RazorPagesEntryContext (DbContextOptions<RazorPagesEntryContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournal.Models.Entry>? Entry { get; set; }
    }
