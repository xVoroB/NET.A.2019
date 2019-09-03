using System;
using System.Timers;

namespace HomeWork12
{
    public class TimerEvents
    {
        private Timer timer;
        private bool isAlreadyTimed;
        public int seconds { get; private set; }
        public delegate void TimerEventHandler(string message);
        public event TimerEventHandler CountDown;

        /// <summary>
        /// Timer's handler
        /// </summary>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CountDown(seconds + " seconds have passed");
            isAlreadyTimed = false;
        }

        /// <summary>
        /// My event handler
        /// </summary>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Sets timer
        /// </summary>
        /// <param name="sec"> Seconds to count </param>
        public void SetTimer(string sec)
        {
            if (isAlreadyTimed)
            {
                timer.Dispose();
            }

            int.TryParse(sec, out int secInt);

            if (secInt < 0)
            {
                throw new ArgumentException("Set seconds more than zero");
            }
            else
            {
                seconds = secInt;
            }

            timer = new Timer(seconds * 1000);

            timer.Elapsed += OnTimedEvent;
            CountDown += ShowMessage;
            timer.AutoReset = false;
            timer.Enabled = true;
            isAlreadyTimed = true;
        }
    }
}
