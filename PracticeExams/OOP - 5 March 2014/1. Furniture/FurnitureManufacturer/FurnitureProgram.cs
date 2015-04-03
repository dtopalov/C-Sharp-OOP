using System.Globalization;
using System.Threading;

namespace FurnitureManufacturer
{
    using Engine;

    public class FurnitureProgram
    {
        
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            FurnitureManufacturerEngine.Instance.Start();
        }
    }
}
