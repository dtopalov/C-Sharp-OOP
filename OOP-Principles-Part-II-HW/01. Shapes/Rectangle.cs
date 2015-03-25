namespace _01.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle (double width, double height)
            : base(width, height)
        {

        }

        public Rectangle (double width) : base (width)
        {
        }

        public override double CalcArea()
        {
            return (this.Width * this.Height);
        }
    }
}