using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace ResourceSystem.View
{
    [RequireComponent (typeof (Button))]
    public class ResourceButton : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private Image resourceIcon;
        
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
            yield return new WaitForSeconds(_enableTime);
            StartCoroutine(EndTime());
        }
        IEnumerator EndTime()
        {
            ResourceViewService.Instance.SetDisabledIcon(resourceIcon, resourceType);
            _button.onClick.AddListener(StartFirstCorutine);
            _button.enabled = true;
            yield return new WaitForSeconds(_disableTime);
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