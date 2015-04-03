using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Unit
    {
        const int QPower = 1;
        const int QAggression = 1;
        const int QHealth = 30;

        public Queen(string id) :
            base(id, UnitClassification.Psionic, Queen.QHealth, Queen.QPower, Queen.QAggression)
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
                if (unit.UnitClassification == UnitClassification.Mechanical || unit.UnitClassification == UnitClassification.Psionic)
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
