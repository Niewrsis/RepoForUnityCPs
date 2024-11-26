using ConstVar;
using System;
using UnityEngine;

namespace Formulas
{
    public static class Formulas
    {
        public static float GetDisplacement(float AB, float BC)
        {
            return (float)Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(BC, 2));
        }
        public static float GetUniversalGravitation(float m1, float m2, float r)
        {
            return (ConstantVariables.GRAVITAIONAL_CONSTANT*m1*m2)/(float)Math.Pow(r, 2);
        }
        public static float GetFrictionForce(float u, float m)
        {
            return u * m * ConstantVariables.FREE_FALL_ACCELERATION;
        }
        public static float GetBodyDensity(float m, float V)
        {
            return m / V;
        }
        public static float GetOhmLaw(float U, float R)
        {
            return U/R;
        }
    }
}