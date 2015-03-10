using System;

namespace DefiningClassesPartI
{
    public class Call //problem 8
    {
        private DateTime date;
        private int duration;
        private string dialedPhone;

        public DateTime Date {
            get { return this.date; }
            private set { this.date = value; }
        }

        public int Duration {
            get { return this.duration; } 
            private set { this.duration = value; }
        }

        public string DialedPhone
        {
            get { return this.dialedPhone; }
            set { this.dialedPhone = value; }
        }

        public Call(DateTime callDateTime, int seconds, string phoneNumber)
        {
            this.Date = callDateTime;
            this.Duration = seconds;
            this.DialedPhone = phoneNumber;
        }

        public override string ToString()
        {
            return string.Format("Date and time: {0:G}; Duration: {1} seconds;\nDialed number: {2}",
                this.Date, this.Duration, this.DialedPhone);
        }
    }
}
