namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class Griffin : Creature
    {
        public Griffin()
            :base (8, 8, 25, 4.5m)
        {
            AddSpecialty(new DoubleDefenseWhenDefending(5));
            AddSpecialty(new AddDefenseWhenSkip(3));
            AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
