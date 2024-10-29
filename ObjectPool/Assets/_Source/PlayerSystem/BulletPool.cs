using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class BulletPool
    {
        private Queue<Bullet> _bulletPool;
        private const int _startPoolSize = 10;

        public BulletPool(Bullet bulletPrefab, Transform bulletPoolObj)
        {
            InitPool(bulletPrefab, bulletPoolObj);
        }
        public void InitPool(Bullet bulletPrefab, Transform bulletPoolObj)
        {
            _bulletPool = new();
            for (int i = 0; i < _startPoolSize; i++)
            {
                Bullet bulletInstance = Object.Instantiate(bulletPrefab, bulletPoolObj);
                bulletInstance.Construct(this);
                _bulletPool.Enqueue(bulletInstance);
                bulletInstance.gameObject.SetActive(false);
            }
        }
        public bool TryGetItem(out Bullet bullet) => _bulletPool.TryDequeue(out bullet);
        public void ReturnToPool(Bullet bullet) => _bulletPool.Enqueue(bullet);
    }
}