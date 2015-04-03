namespace Infestation
{
    public class HealthCatalyst : Supplement, ISupplement
    {
        private const int healthEffect = 3;

        public HealthCatalyst() : base(health:healthEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
