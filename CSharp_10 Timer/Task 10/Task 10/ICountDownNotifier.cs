namespace Task_10
{
    public interface ICountDownNotifier
    {
        void Init();
        void Run();
        void Unsubscribe();
    }
}
