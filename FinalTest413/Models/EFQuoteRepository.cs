using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest413.Models
{
    public class EFQuoteRepository : IQuoteRepository
    {
        private QuoteDbContext _context { get; set; }

        public EFQuoteRepository (QuoteDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Quote> Quotes => _context.Quotes;

        public void Update(Quote q)
        {
            _context.Update(q);
            _context.SaveChanges();
        }

        public void Add(Quote q)
        {
            _context.Add(q);
            _context.SaveChanges();
        }

        public void Delete(Quote q)
        {
            _context.Remove(q);
            _context.SaveChanges();
        }
    }
}
