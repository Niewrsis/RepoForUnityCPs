using TMPro;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI hpText;

        private SpriteRenderer _sr;
        private Player _player;
        private void Start()
        {
            _sr = GetComponent<SpriteRenderer>();
        }
        public void Construct(Player player)
        {
            _player = player;
        }
        public void OnHealthChangeText(float currentHealth)
        {
            hpText.text = currentHealth.ToString();
            OnHealthChangeSprite(currentHealth);
        }
        private void OnHealthChangeSprite(float currentHealth)
        {
            if(currentHealth > _player.MaxHealth * 0.75)
            {
                _sr.color = Color.green;
            }
            else if(currentHealth < _player.MaxHealth * 0.5)
            {
                _sr.color = Color.yellow;
            }
            else if(currentHealth < _player.MaxHealth * 0.25)
            {
                _sr.color = Color.red;
            }
        }
    }
}