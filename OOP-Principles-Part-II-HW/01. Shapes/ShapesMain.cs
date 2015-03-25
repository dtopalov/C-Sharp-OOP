namespace _01.Shapes
{
    using System;

    class ShapesMain
    {
        static void Main()
        {
            Shape[] shapes = 
            {
                new Rectangle(3.5, 5.5),
                new Square(5),
                new Triangle(6.5, 3), 
                new Rectangle(8, 2),
                new Triangle(2, 2)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} area: {1}", shape.GetType().Name, shape.CalcArea());
            }
        }
    }
}
