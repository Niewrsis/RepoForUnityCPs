using PlayerSystem;
using InputSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform bulletPoolObj;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private InputListener inputListener;

        private BulletPool _bulletPool;
        void Awake()
        {
            _bulletPool = new(bulletPrefab, bulletPoolObj);
            playerShoot.Construct(_bulletPool);
            inputListener.Construct(playerShoot);
        }
    }
}