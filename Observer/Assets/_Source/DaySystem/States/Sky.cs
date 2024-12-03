using DaySystem.Observer;
using UnityEngine;

namespace DaySystem.States
{
    public class Sky : MonoBehaviour, IObserver
    {
        [SerializeField] private Color morningColor;
        [SerializeField] private Color dayColor;
        [SerializeField] private Color eveningColor;
        [SerializeField] private Color nightColor;

        private Camera skyRenderer;
        private void Start()
        {
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.RegisterObserver(this);
            }

            skyRenderer = GetComponent<Camera>();
        }
        void IObserver.Update(float timeOfDay)
        {
            Color targetColor;

            if (timeOfDay < 0.25f)
            {
                targetColor = Color.Lerp(nightColor, morningColor, timeOfDay / 0.25f);
            }
            else if (timeOfDay < 0.5f)
            {
                targetColor = Color.Lerp(morningColor, dayColor, (timeOfDay - 0.25f) / 0.25f);
            }
            else if (timeOfDay < 0.75f)
            {
                targetColor = Color.Lerp(dayColor, eveningColor, (timeOfDay - 0.5f) / 0.25f);
            }
            else
            {
                targetColor = Color.Lerp(eveningColor, nightColor, (timeOfDay - 0.75f) / 0.25f);
            }

            skyRenderer.backgroundColor = targetColor;
        }
    }
}