namespace PlayerSystem
{
    public class PlayerModel
    {
        private PlayerView _playerView;
        private float _currentHealth;
        public PlayerModel(Player player, PlayerView playerView)
        {
            _playerView = playerView;
            _currentHealth = player.MaxHealth;
            _playerView.OnHealthChangeText(_currentHealth);
        }   
        public void OnTakeDamage(float damage)
        {
            if (_currentHealth - damage <= 0)
            {
                OnPlayerDeath();
                return;
            }
            _currentHealth -= damage;
            _playerView.OnHealthChangeText(_currentHealth);
        }
        public void OnPlayerDeath()
        {
            //TODO: Death logic 
        }
    }
}