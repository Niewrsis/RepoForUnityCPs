using UnityEngine;

namespace Core
{
        public class ShootState : AGameState
        {
            public override void Enter()
            {
                Debug.Log("Enter Shoot State");
            }
           /* public override void Update()
            {
                Debug.Log("Update");
            }*/
            public override void Exit()
            {
                Debug.Log("Exit Shoot State");
            }
        }
}