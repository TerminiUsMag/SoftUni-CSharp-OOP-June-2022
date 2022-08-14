using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;
        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Name == name)
                {
                    return weapons[i];
                }
            }
            return null;
        }

        public bool Remove(IWeapon model)
        {
            if (weapons.Contains(model))
            {
                weapons.Remove(model);
                return true;
            }
            return false;
        }
    }
}
