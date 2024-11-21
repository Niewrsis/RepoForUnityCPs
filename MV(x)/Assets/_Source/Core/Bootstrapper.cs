using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private PlayerController _playerController;
        private Player _player;

        private void Awake()
        {
            player = Instantiate(player);

            _playerView = player.GetComponent<PlayerView>();
            _player = player.GetComponent<Player>();
        }
        private void Start()
        {
            _playerModel = new(_player, _playerView);
            _playerController = new(_playerModel, _playerView);
            _playerView.Construct(_player);
        }
    }
}