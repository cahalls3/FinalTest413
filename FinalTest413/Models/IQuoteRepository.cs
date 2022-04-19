using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FinalTest413.Models
{
    public interface IQuoteRepository
    {
        IQueryable<Quote> Quotes { get; }

        public void Update(Quote q);
        public void Add(Quote q);
        public void Delete(Quote q);
    }
}
