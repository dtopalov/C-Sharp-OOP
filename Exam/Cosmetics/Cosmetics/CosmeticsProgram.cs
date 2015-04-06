using System.Globalization;
using System.Threading;
using Cosmetics.Engine;
namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // for local testing
            CosmeticsEngine.Instance.Start();
        }
    }
}
