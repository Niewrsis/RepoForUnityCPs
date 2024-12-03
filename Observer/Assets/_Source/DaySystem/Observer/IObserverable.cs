namespace DaySystem.Observer
{
    public interface IObserverable
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notify(float timeOfDay);
    }
}