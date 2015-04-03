using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public class Parasite : Unit
    {
        const int ParPower = 1;
        const int ParAggression = 1;
        const int ParHealth = 1;

        public Parasite(string id) :
            base(id, UnitClassification.Biological, Parasite.ParHealth, Parasite.ParPower, Parasite.ParAggression)
        {
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //This method finds the unit with the least power and attacks it

            return attackableUnits.OrderBy(x => x.Health).FirstOrDefault();
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;
            if (this.Id != unit.Id)
            {
                if (this.UnitClassification == unit.UnitClassification)
                {
                    attackUnit = true;
                }
            }
            return attackUnit;
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }
    }
}
