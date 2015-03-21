namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class SchoolClass : IComment
    {
        private string identifier;

        public SchoolClass(string identifier, List<Student> students, List<Teacher> teachers)
        {
            this.Identifier = identifier;
            this.Students = students;
            this.Teachers = teachers;
        }
        
        public string Comment { get; private set; }
        public string Identifier
        {
            get { return this.identifier; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Class identifier cannot be empty or null");
                }
                this.identifier = value;
            }
        }
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }

        public void MakeComment(string text)
        {
            this.Comment = text;
        }
    }
}
