using TMPro;
using UnityEngine;

namespace UISystem
{
    public class SecondLeftText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI secondsText;

        public void ChangeSeconds(int seconds)
        {
            secondsText.text = seconds.ToString();
        }
    }
}