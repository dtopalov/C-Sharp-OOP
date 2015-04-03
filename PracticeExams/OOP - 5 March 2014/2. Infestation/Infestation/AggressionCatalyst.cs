namespace Infestation
{
    public class AggressionCatalyst:Supplement, ISupplement
    {
        private const int aggressionEffect = 3;

        public AggressionCatalyst() : base(aggression: aggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
