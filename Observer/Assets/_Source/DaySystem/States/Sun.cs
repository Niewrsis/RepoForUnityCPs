using DaySystem.Observer;
using UnityEngine;

namespace DaySystem.States
{
    public class Sun : MonoBehaviour, IObserver
    {
        [SerializeField] private Transform pointToRotate;
        private float _rotationSpeed;

        private void Start()
        {
            Timer timer = FindObjectOfType<Timer>();

            if (timer != null)
            {
                timer.RegisterObserver(this);
                UpdateRotationSpeed(timer.DayLength);
            }
        }

        void IObserver.Update(float timeOfDay)
        {
            float newAngle = _rotationSpeed * Time.deltaTime;
            pointToRotate.Rotate(0, 0, newAngle);
        }

        private void UpdateRotationSpeed(float dayLengthInSeconds)
        {
            if (dayLengthInSeconds > 0)
            {
                _rotationSpeed = 360f / dayLengthInSeconds;
            }
            else
            {
                _rotationSpeed = 0;
            }
        }
    }
}