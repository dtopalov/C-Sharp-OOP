using System;
using System.Collections.Generic;
using System.Configuration;

namespace DefiningClassesPartI
{
    public class GSM
    {
        private static string iPhone4S; //problem 6
        private string manifacturer; //problem 1
        private string model; //problem 1
        private double price; //problem 1
        private string owner; //problem 1
        private Battery battery; //problem 1
        private Display display; //problem 1
        private List<Call> callHistory; //problem 9

        public static string IPhone4S //problem 6
        {
            get { return iPhone4S; }
            private set { iPhone4S = value; }
        }

        static GSM() //problem 6
        {
            IPhone4S = "Info about the IPhone4S:\nHalf the functionality, double the price";
        }

        //problem 5
        public string Manifacturer
        {
            get { return this.manifacturer; }
            private set
            {
                if (value.Length == 0 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Manifacturer name should be longer than 0 and shorter than 20 symbols");
                }
                else
                {
                    this.manifacturer = value;
                }
            }
        } 

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value.Length == 0 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Model name should be longer than 0 and shorter than 20 symbols");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public double Price
        {
            get { return this.price; }
            private set
            {
                if (value == 0 || value > 2000)
                {
                    throw new ArgumentOutOfRangeException("Price should be > 0 and <= 2000");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            private set
            {
                if (value.Length == 0 || value.Length > 30)
                {
                    throw new ArgumentOutOfRangeException("Owner name should be longer than 0 and shorter than 30 symbols");
                }
                else
                {
                    this.owner = value;
                }
            }
        }

        public Battery Battery
        {
            get { return this.battery; }

            private set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }

            private set { this.display = value; }
        }

        //problem 9
        public List<Call> CallHistory {
            get { return this.callHistory; }
            private set { this.callHistory = value; }
        }

        //problem 2
        //Constructor taking only manifacturer and model as parameters, setting all others to some default values
        public GSM(string manifacturer, string model)
            : this(manifacturer, model, 100.0, "Pesho", new Battery(), new Display(), new List<Call>())
        {
            this.Manifacturer = manifacturer;
            this.Model = model;
        }

        //full constructor
        public GSM(string manifacturer, string model, double price, string owner, Battery battery, Display display, List<Call> callHistory)
        {
            this.Manifacturer = manifacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new List<Call>();
        }

        //problem 4
        public override string ToString()
        {
            return String.Format("Manifacturer: {0}\n" +
                                 "Model: {1}\n" + 
                                 "Price: {2}\n" +
                                 "Owner: {3}\n" +
                                 "Battery: {4}\n" +
                                 "Display: {5}", 
                                 this.Manifacturer, this.Model, this.Price, this.Owner, 
                                 this.Battery.ToString(), this.Display.ToString());
        }

        //problem 10
        public List<Call> AddCalls(Call call)
        {
            this.CallHistory.Add(call);
            return this.CallHistory;
        }

        public List<Call> DeleteCalls(Call call)
        {
            this.CallHistory.Remove(call);
            return this.CallHistory;
        }

        public List<Call> ClearCallHistory()
        {
            this.CallHistory.Clear();
            return this.CallHistory;
        }

        //problem 11
        public decimal CalculateTotalCallsPrice(decimal price)
        {
            int totalDuration = 0;
            
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                totalDuration += callHistory[i].Duration;
            }

            decimal totalPrice = totalDuration*price;
            
            return totalPrice;
        }

        public string PrintCallHistory()
        {
            return string.Format("Calls history:\n{0}", string.Join(Environment.NewLine, this.callHistory));
        }
    }
}
