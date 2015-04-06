namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class DoubleDamage : Specialty
    {

        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= 0)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                return currentDamage;
            }
            rounds--;
            return currentDamage*2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
