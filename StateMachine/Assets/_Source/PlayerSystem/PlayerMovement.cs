using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        public void Move(float xMove, float yMove, Player player)
        {
            player.Rb.velocity = new Vector2(xMove, yMove).normalized * player.MoveSpeed;
        }
    }
}