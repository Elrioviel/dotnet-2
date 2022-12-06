using System;
using System.Threading;

namespace Task_10
{
    public class Timer
    {
        const string invalidCounter = "Invalid counter value.";
        public string Name;
        public int Counter;
        public delegate void TimerHandler(TimerEventArgs e);
        public event TimerHandler Start;
        public event TimerHandler OnSecondPassed;
        public event TimerHandler Finished;

        private Timer(string name, int counter)
        {
            Name = name;
            Counter = counter;
        }

        public static Timer Create(string name, int counter)
        {
            if (counter > 0)
            {
                Timer timer = new(name, counter);
                return timer;
            }
            else
            {
                throw new ArgumentException(invalidCounter);
            }
        }

        public void StartTimer()
        {
            Start?.Invoke(new TimerEventArgs(Name, Counter));
            for (int i = Counter; i >= 0; i--)
            {
                OnSecondPassed?.Invoke(new TimerEventArgs(Name, i));
                Thread.Sleep(1000);
            }
            Finished?.Invoke(new TimerEventArgs(Name, Counter));;
        }
    }
}
