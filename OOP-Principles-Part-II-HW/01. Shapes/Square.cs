namespace _01.Shapes
{
    class Square : Rectangle
    {
        public Square(double width) : base (width)
        {
        }

        public override double CalcArea()
        {
            return this.Width*this.Width;
        }
    }
}
