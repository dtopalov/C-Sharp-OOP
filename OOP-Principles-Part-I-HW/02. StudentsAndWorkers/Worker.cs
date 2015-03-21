namespace _02.StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private double weekSalary;
        private double workingHours;

        public Worker(string fName, string lName, double weekSalary, double workingHours) : base(fName, lName)
        {
            this.WeekSalary = weekSalary;
            this.workingHours = workingHours;
        }

        public double WeekSalary {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weekly Salary must be >= 0");
                }
                this.weekSalary = value;
            }
        }

        public double WorkingHours
        {
            get { return this.workingHours; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Working hours must be > 0");
                }
                this.workingHours = value;
            }
        }

        public double MoneyPerHour()
        {
            double moneyPerHour = this.WeekSalary/this.WorkingHours*5;
            return moneyPerHour;
        }
    }
}
