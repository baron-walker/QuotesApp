using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApp.Models
{
    public class QuoteListContext : DbContext
    {
        public QuoteListContext(DbContextOptions<QuoteListContext> options) : base(options) { }

        public DbSet<QuoteItem> Quotes { get; set; }
    }
}
