namespace _01.Shapes
{
    public class Triangle : Shape
    {
        public Triangle (double width, double height) : base(width, height)
        {
            
        }

        public override double CalcArea()
        {
            return (this.Width * this.Height)/2;
        }
    }
}
