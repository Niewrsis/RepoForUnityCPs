using Unity.VisualScripting;
using UnityEngine;

namespace ConstVar
{
    public static class ConstantVariables
    {
        private static ConstSO _so;
        public static float GRAVITAIONAL_CONSTANT { get; private set; }
        public static float FREE_FALL_ACCELERATION { get; private set; }

        public static void Load()
        {
            _so = Resources.Load("Constants") as ConstSO;
            GRAVITAIONAL_CONSTANT = _so.GravitationalConstant * Mathf.Pow(10, -11);
            FREE_FALL_ACCELERATION = _so.FreeFallAcceleration;
        }
    }
}