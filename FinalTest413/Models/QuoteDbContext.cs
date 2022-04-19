using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalTest413.Models
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base (options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Quote>().HasData(

                new Quote
                {
                    QuoteID = 1,
                    QuoteText = "Fortune Favors the Bold.",
                    Author = "Virgil",
                    Date = "19 B.C.",
                    Subject = "",
                    Citation = "",
                },
                new Quote
                {
                    QuoteID = 2,
                    QuoteText = "You must be the change you wish to see in the world.",
                    Author = "Mahatma Gandhi",
                    Date = "1913",
                    Subject = "",
                    Citation = "",
                },
                new Quote
                {
                    QuoteID = 3,
                    QuoteText = "I think, therefore I am.",
                    Author = "René Descartes",
                    Date = "1637",
                    Subject = "",
                    Citation = "",
                }
            );
        }
    }
}
