using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerShoot _playerShoot;
        public void Construct(PlayerShoot playerShoot)
        {
            _playerShoot = playerShoot;
        }
        private void Update()
        {
            ListenShootInput();
        }
        private void ListenShootInput()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _playerShoot.Shoot();
            }
        }
    }
}