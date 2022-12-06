using Task_10;

namespace TimerUI
{
    class Program
    {
        delegate void Task(TimerEventArgs e);
        static void Main(string[] args)
        {
            ICountDownNotifier[] countdownNotifiers = new ICountDownNotifier[3];
            countdownNotifiers[0] = ReadTask ("Reading the task", 1);
            countdownNotifiers[1] = WorkOnTask("Working on the task", 2);
            countdownNotifiers[2] = CheckTask("Checking the task", 5);
            foreach (ICountDownNotifier countdownNotifier in countdownNotifiers)
            {
                countdownNotifier.Init();
                countdownNotifier.Run();
                countdownNotifier.Unsubscribe();
            }
        }

        private static CountDownNotifierMethods ReadTask(string name, int time)
        {
            Timer readingTaskTimer = Timer.Create(name, time);
            return new CountDownNotifierMethods(readingTaskTimer);
        }

        private static CountDownNotifierLambdaExpressions WorkOnTask(string name, int time)
        {
            Timer workingOnTaskTimer = Timer.Create(name, time);
            return new CountDownNotifierLambdaExpressions(workingOnTaskTimer);
        }

        private static CountDownNotifierAnonymousMethods CheckTask(string name, int time)
        {
            Timer checkingTaskTimer = Timer.Create(name, time);
            return  new CountDownNotifierAnonymousMethods(checkingTaskTimer);
        }
    }
}
