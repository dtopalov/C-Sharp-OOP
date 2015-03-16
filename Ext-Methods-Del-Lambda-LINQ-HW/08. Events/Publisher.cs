namespace _08.Events
{
    using System;

    public class Publisher
    {
        public delegate void CustomEventHandler(object sender, SampleEvent e);

        public event CustomEventHandler RaiseCustomEvent;

        public void RaiseSampleEvent()
        {
            Console.WriteLine("An event will be raised");
            OnRaiseCustomEvent(new SampleEvent("This is the custom event"));
        }

        protected virtual void OnRaiseCustomEvent(SampleEvent e)
        {
            CustomEventHandler handler = RaiseCustomEvent;

            if (handler != null)
            {
                e.SampleMessage += String.Format(" at {0}", DateTime.Now);

                handler(this, e);
            }
        }
    }
}
