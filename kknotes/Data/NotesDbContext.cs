using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace kknotes.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
