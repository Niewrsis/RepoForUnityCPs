using UnityEngine;

namespace CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform target;

        [Header("Attributes")]
        [SerializeField] private float speed;
        private void Update()
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -20), target.position, speed * Time.deltaTime);
        }
    }
}