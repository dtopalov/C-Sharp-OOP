namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class AncientBehemoth : Creature
    {
        public AncientBehemoth()
            : base(19, 19, 300, 40)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
