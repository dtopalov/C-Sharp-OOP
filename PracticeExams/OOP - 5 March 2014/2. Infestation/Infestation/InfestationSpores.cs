namespace Infestation
{
    public class InfestationSpores : Supplement, ISupplement
    {
        public InfestationSpores():base(aggression:20, power: -1)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.AggressionEffect = 0;
                this.PowerEffect = 0;
            }
        }
    }
}
