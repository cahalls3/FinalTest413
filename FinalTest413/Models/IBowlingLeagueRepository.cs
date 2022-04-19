using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mission13.Models
{
    public interface IBowlingLeagueRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void Update(Bowler b);
        public void Add(Bowler b);
        public void Delete(Bowler b);
    }
}
