using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private static Game instance;
        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }

                return instance;
            }
        }
        public void ActivateLoseGame()
        {
            Time.timeScale = 0f;
        }
    }
}