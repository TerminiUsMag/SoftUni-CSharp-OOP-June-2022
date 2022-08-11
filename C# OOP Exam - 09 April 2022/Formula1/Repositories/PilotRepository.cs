using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly Dictionary<string, IPilot> pilots;
        public PilotRepository()
        {
            pilots = new Dictionary<string, IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots.Values;

        public void Add(IPilot model) => pilots.Add(model.FullName, model);

        public IPilot FindByName(string name) => pilots.ContainsKey(name) ? pilots[name] : null;

        public bool Remove(IPilot model)
        {
            if (pilots.ContainsKey(model.FullName))
            {
                pilots.Remove(model.FullName);
                return true;
            }
            return false;
        }
    }
}
