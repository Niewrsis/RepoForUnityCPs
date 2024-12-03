using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject circlePlayerArea;

        [Header("Attributes")]
        public float MoveSpeed;

        public Rigidbody2D Rb { get; set; }
        public SpriteRenderer Sr { get; set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Sr = GetComponent<SpriteRenderer>();
        }
        public GameObject GetCirclePlayerArea() { return circlePlayerArea; }
    }
}