using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Core;
using UISystem;

namespace ResourceSystem.View
{
    [RequireComponent (typeof (Button))]
    public class ResourceButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private Image resourceIcon;
        [SerializeField] private SecondLeftText secondsText;
        
        private float _enableTime;
        private float _disableTime;

        private Button _button;

        private void Awake()
        {
            ResourceViewService.Instance.SetEnabledIcon(resourceIcon, resourceType);

            ResourceService.Instance.SetEnabledTime(ref _enableTime, resourceType);
            ResourceService.Instance.SetDisabledTime(ref _disableTime, resourceType);
        }
        private void Start()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(StartFirstCorutine);
        }

        IEnumerator StartTime()
        {
            _button.onClick.RemoveAllListeners();
            _button.enabled = false;
            for (int i = (int)_enableTime; i > 0; i--)
            {
                secondsText.ChangeSeconds(i);
                yield return new WaitForSeconds(1);
            }
            StartCoroutine(EndTime());
        }
        IEnumerator EndTime()
        {
            ResourceViewService.Instance.SetDisabledIcon(resourceIcon, resourceType);
            _button.onClick.AddListener(StartFirstCorutine);
            _button.enabled = true;
            for (int i = (int)_disableTime; i > 0; i--)
            {
                secondsText.ChangeSeconds(i);
                yield return new WaitForSeconds(1);
            }
            StopAllCoroutines();
            _button.onClick.RemoveAllListeners();
            _button.enabled = false;
            Game.Instance.ActivateLoseGame();
        }
        private void StartFirstCorutine()
        {
            ResourceViewService.Instance.SetEnabledIcon(resourceIcon, resourceType);
            StopAllCoroutines();

            StartCoroutine(StartTime());
        }
    }
}