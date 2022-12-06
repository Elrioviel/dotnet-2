using System;

namespace Task_10
{
    public class CountDownNotifierAnonymousMethods : ICountDownNotifier
    {
        private Timer.TimerHandler start = null;
        private Timer.TimerHandler onSecondPassed = null;
        private Timer.TimerHandler finished = null;
        private readonly Timer _timer;

        public CountDownNotifierAnonymousMethods(Timer timer)
        {
            _timer = timer;
        }

        public void Init()
        {
            _timer.Start += start;
            _timer.OnSecondPassed += onSecondPassed;
            _timer.Finished += finished;
        }

        public void Run()
        {
            _timer.Start += delegate(TimerEventArgs e) { Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name} has started for {_timer.Counter} seconds."); };
            _timer.OnSecondPassed += delegate(TimerEventArgs e) { Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name} {e.Counter} seconds remaining."); };
            _timer.Finished += delegate(TimerEventArgs e) { Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name} has finished."); };
            _timer.StartTimer();
        }

        public void Unsubscribe()
        {
            _timer.Start -= start;
            _timer.OnSecondPassed -= onSecondPassed;
            _timer.Finished -= finished;
        }
    }
}
