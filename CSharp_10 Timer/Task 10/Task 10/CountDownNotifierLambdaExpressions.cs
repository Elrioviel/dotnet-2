using System;

namespace Task_10
{
    public class CountDownNotifierLambdaExpressions : ICountDownNotifier
    {
        readonly Timer.TimerHandler start = null;
        readonly Timer.TimerHandler onSecondPassed = null;
        readonly Timer.TimerHandler finished = null;
        private readonly Timer _timer;

        public CountDownNotifierLambdaExpressions(Timer timer)
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
            _timer.Start += (args) => { Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {args.Name} has started for {args.Counter} seconds."); };
            _timer.OnSecondPassed += (args) => { Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {args.Name} {args.Counter} seconds remaining."); };
            _timer.Finished += (args) => { Console.WriteLine($"[{DateTime.Now.Second}]:Timer: {args.Name} has finished."); };
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
