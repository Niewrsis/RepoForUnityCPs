using TMPro;
using UnityEngine;

namespace Visual
{
    public class StateText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stateText;

        public bool DrawState(string stateName)
        {
            stateText.text = stateName;
            return false;
        }
    }
}