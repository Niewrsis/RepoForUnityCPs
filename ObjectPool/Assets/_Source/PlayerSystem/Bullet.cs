using System.Collections;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private BulletPool _bulletPool;
        public Rigidbody2D Rb;
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
        public void Construct(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }
        public IEnumerator StartLifeTime(float lifeTime)
        {
            yield return new WaitForSeconds(lifeTime);
            gameObject.SetActive(false);
        }
        private void OnDisable()
        {
            _bulletPool.ReturnToPool(this);
            Rb.velocity = Vector3.zero;
        }
    }
}