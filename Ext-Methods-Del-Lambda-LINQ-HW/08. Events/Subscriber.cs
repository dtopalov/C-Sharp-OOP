namespace _08.Events
{
    using System;

    public class Subscriber
    {
        private string name;

        public Subscriber(string name, Publisher pub)
        {
            this.Name = name;
            
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        public string Name {
            get { return this.name; }
            private set { this.name = value; }
        }

        void HandleCustomEvent(object sender, SampleEvent e)
        {
            Console.WriteLine("\nThis is how the event is handled:\n");
            Console.WriteLine(this.name + " received this message: {0}", e.SampleMessage);
        }
    }
}
