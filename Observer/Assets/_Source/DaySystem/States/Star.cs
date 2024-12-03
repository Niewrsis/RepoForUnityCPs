using DaySystem.Observer;
using UnityEngine;

namespace DaySystem.States
{
    public class Star : MonoBehaviour, IObserver
    {
        private SpriteRenderer _starRenderer;

        private void Start()
        {
            Timer timer = FindObjectOfType<Timer>();

            if (timer != null)
            {
                timer.RegisterObserver(this);
            }

            _starRenderer = GetComponent<SpriteRenderer>();
        }

        void IObserver.Update(float timeOfDay)
        {
            Color color = _starRenderer.color;

            if (timeOfDay < 0.25f || timeOfDay > 0.75f)
            {
                color.a = 1f;
            }
            else if (timeOfDay >= 0.25f && timeOfDay <= 0.5f)
            {
                color.a = Mathf.Lerp(1f, 0f, (timeOfDay - 0.25f) / 0.25f);
            }
            else if (timeOfDay > 0.5f && timeOfDay <= 0.75f)
            {
                color.a = Mathf.Lerp(0f, 1f, (timeOfDay - 0.5f) / 0.25f);
            }
            else
            {
                color.a = 0f;
            }
            _starRenderer.color = color;
        }
    }
}