using System;

namespace DefiningClassesPartI
{
    public class Display ////problems 1, 2, 4, 5
    {
        private double diagonal;
        private int numberOfColors;

        public double Diagonal
        {
            get { return this.diagonal; }
            private set
            {
                if (value == 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Display size should be > 0 and <= 10");
                }
                else
                {
                    this.diagonal = value;
                }
            }
        }

        public int NumberOfColors
        {
            get { return this.numberOfColors; }
            private set
            {
                if (value < 256 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Number of colors should be > 255 and <= int.MaxValue");
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }

        //Empty constructor, setting 3.5 and 256 as the
        //default values for the diagonal size and the number of colors
        public Display() : this(3.5, 256) {}

        //Constructor taking 1 parameter for the size only and setting
        //the number of colors to the default (256)
        public Display(double size) : this(size, 256) {}

        //Full constructor taking 2 parameters - size and number of colors
        public Display(double size, int colors)
        {
            this.Diagonal = size;
            this.NumberOfColors = colors;
        }

        public override string ToString()
        {
            return String.Format("Diagonal length: {0}, Number of colors: {1}",
                this.diagonal, this.numberOfColors);
        }
    }
}
