using System;

namespace Task_10
{
    public class CountDownNotifierMethods : ICountDownNotifier
    {
        private Timer.TimerHandler start = null;
        private Timer.TimerHandler finished = null;
        private readonly Timer _timer;

        public CountDownNotifierMethods(Timer timer)
        {
            _timer = timer;
        }

        public void Init()
        {
            _timer.Start += new Timer.TimerHandler(OnStart);
            _timer.OnSecondPassed += new Timer.TimerHandler(OnSecondPass);
            _timer.Finished += new Timer.TimerHandler(OnFinished);
        }

        public void Run()
        {
            _timer.StartTimer();
        }

        public void Unsubscribe()
        {
            _timer.Start -= OnStart;
            _timer.OnSecondPassed -= OnSecondPass;
            _timer.Finished -= OnFinished;
        }

        private void OnStart(TimerEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name} has started for {_timer.Counter} seconds.");
        }

        private void OnSecondPass(TimerEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name} {e.Counter} seconds remaining.");
        }

        private void OnFinished(TimerEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {e.Name} has finished.");
        }
    }
}
