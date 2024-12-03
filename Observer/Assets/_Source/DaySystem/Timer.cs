using DaySystem.Observer;
using System.Collections.Generic;
using UnityEngine;

namespace DaySystem
{
    public class Timer : MonoBehaviour, IObserverable
    {
        [SerializeField] private float dayLength;
        private float _currentTime;

        private List<IObserver> observers = new List<IObserver>();

        public float DayLength => dayLength;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= dayLength)
                _currentTime = 0f;

            Notify(_currentTime / dayLength);
        }

        public void Notify(float timeOfDay)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(timeOfDay);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}