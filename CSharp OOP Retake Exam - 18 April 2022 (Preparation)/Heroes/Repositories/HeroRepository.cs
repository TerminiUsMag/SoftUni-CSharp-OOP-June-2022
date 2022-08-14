
using System;
using System.Collections.Generic;

using Heroes.Repositories.Contracts;
using Heroes.Models.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly Dictionary<string, IHero> heroes;
        public HeroRepository()
        {
            this.heroes = new Dictionary<string, IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes.Values;

        public void Add(IHero model) => heroes.Add(model.Name, model);

        public IHero FindByName(string name)
        {
            if (heroes.ContainsKey(name))
                return heroes[name];
            else
                return null;
        }

        public bool Remove(IHero model)
        {
            if (heroes.ContainsKey((string)model.Name))
            {
                heroes.Remove((string)model.Name);
                return true;
            }
            else
                return false;
        }
    }
}
