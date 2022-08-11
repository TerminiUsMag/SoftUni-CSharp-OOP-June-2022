using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly Dictionary<string, IRace> races;
        public RaceRepository()
        {
            races = new Dictionary<string, IRace>();
        }
        public IReadOnlyCollection<IRace> Models => races.Values;

        public void Add(IRace model) => races.Add(model.RaceName, model);

        public IRace FindByName(string name) => races.ContainsKey(name) ? races[name] : null;

        public bool Remove(IRace model)
        {
            if (races.ContainsKey(model.RaceName))
            {
                races.Remove(model.RaceName);
                return true;
            }
            return false;
        }
    }
}
