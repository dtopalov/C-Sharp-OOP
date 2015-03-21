namespace _01.School
{
    using System;

    public class Discipline : IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.NumberOfLectures = lectures;
            this.NumberOfExercises = exercises;
        }

        public string Name {
            get { return this.name; }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Discipline name must be at least 2 symbols long");
                }
                this.name = value;
            }
        }
        public int NumberOfLectures {
            get { return this.numberOfLectures; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of lectures cannot be negative");
                }
                this.numberOfLectures = value;
            }
        }
        public int NumberOfExercises
        {
            get { return this.numberOfExercises; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of exercises cannot be negative");
                }
                this.numberOfExercises = value;
            }
        }

        public string Comment{ get; private set; }

        public void MakeComment(string text)
        {
            this.Comment = text;
        }
    }
}
