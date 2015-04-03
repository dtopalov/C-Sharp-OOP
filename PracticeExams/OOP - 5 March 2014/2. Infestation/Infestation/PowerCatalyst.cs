namespace Infestation
{
    public class PowerCatalyst : Supplement, ISupplement
    {
        private const int powerEffect = 3;

        public PowerCatalyst() : base(powerEffect)
        {
        }



        public override void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
