namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Human, IComment
    {
        private List<Discipline> disciplines;

        public Teacher(string name, List<Discipline> setOfDisciplines) : base(name)
        {
            this.Disciplines = setOfDisciplines;
        }

        public List<Discipline> Disciplines {
            get { return this.disciplines; }
            private set
            {
                if (value.Count < 1)
                {
                    throw new ArgumentOutOfRangeException("Disciplines must be > 0");
                }
                this.disciplines = value;
            }
        }
        public string Comment { get; private set; }

        public void MakeComment(string text)
        {
            this.Comment = text;
        }
    }
}
