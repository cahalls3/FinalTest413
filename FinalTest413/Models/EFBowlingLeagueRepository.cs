using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlingLeagueRepository : IBowlingLeagueRepository
    {
        private BowlingLeagueDbContext _context { get; set; }

        public EFBowlingLeagueRepository (BowlingLeagueDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void Update(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void Add(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void Delete(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
