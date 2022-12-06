namespace Task_10
{
    public class TimerEventArgs
    {
        public string Name { get; }
        public int Counter { get; }

        public TimerEventArgs(string name, int counter)
        {
            Name = name;
            Counter = counter;
        }
    }
}
