using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id) :
            base(id)
        {
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the least power and attacks it
            return attackableUnits.OrderByDescending(x => x.Health).FirstOrDefault();
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;
            if (this.Id != unit.Id)
            {
                if (this.Aggression >= unit.Power)
                {
                    attackUnit = true;
                }
            }
            return attackUnit;
        }
    }
}
