using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConstVar
{
    [CreateAssetMenu(fileName = "New Constants SO", menuName = "SO/ConstatntsSO")]
    public class ConstSO : ScriptableObject
    {
        public float GravitationalConstant;
        public float FreeFallAcceleration;
    }
}