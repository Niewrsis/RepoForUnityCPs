using UnityEngine;

namespace PlayerSystem
{
    public class PlayerShoot : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform firePoint;

        [Header("Attributes")]
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float lifeTime;

        private BulletPool _bulletPool;

        public void Construct(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }
        public void Shoot()
        {
            if (_bulletPool.TryGetItem(out var bullet))
            {
                bullet.gameObject.SetActive(true);

                StartCoroutine(bullet.StartLifeTime(lifeTime));

                bullet.transform.position = firePoint.position;

                Vector3 playerPosition = transform.position;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Vector3 targetPosition = hit.point;

                    Vector3 direction = (targetPosition - playerPosition).normalized;

                    bullet.Rb.velocity = direction * bulletSpeed;

                    float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ - 90f);
                }
            }
        }
    }
}