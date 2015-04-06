namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Extended.Specialties;

    public class CyclopsKing : Creature
    {
        public CyclopsKing()
            :base (17, 13, 70, 18m)
        {
            AddSpecialty(new AddAttackWhenSkip(3));
            AddSpecialty(new DoubleAttackWhenAttacking(4));
            AddSpecialty(new DoubleDamage(1));
        }
    }
}
