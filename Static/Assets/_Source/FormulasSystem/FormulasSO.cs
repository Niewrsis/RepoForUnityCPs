using UnityEngine;

namespace Formulas
{
    [CreateAssetMenu(fileName = "New Formula SO", menuName = "SO/FormulaSO")]
    public class FormulasSO : ScriptableObject
    {
        [Header("Displacement")]
        [TextArea] public string DisplacmentFormula;
        public string DisplacmentParametr1;
        public string DisplacmentParametr2;

        [Header("Universal Gravitation")]
        [TextArea] public string UniversalGravitationFormula;
        public string UniversalGravitationParametr1;
        public string UniversalGravitationParametr2;
        public string UniversalGravitationParametr3;

        [Header("Friction Force")]
        [TextArea] public string FrictionForceFormula;
        public string FrictionForceParametr1;
        public string FrictionForceParametr2;

        [Header("Body Density")]
        [TextArea] public string BodyDensityFormula;
        public string BodyDensityParametr1;
        public string BodyDensityParametr2;

        [Header("Ohm Law")]
        [TextArea] public string OhmLawFormula;
        public string OhmLawParametr1;
        public string OhmLawParametr2;

        public string GetFormulaString(FormulasEnum formula)
        {
            switch (formula)
            {
                case FormulasEnum.Displacement:
                    {
                        return DisplacmentFormula;
                    }
                case FormulasEnum.UniversalGravitation:
                    {
                        return UniversalGravitationFormula;
                    }
                case FormulasEnum.FrictionForce:
                    {
                        return FrictionForceFormula;
                    }
                case FormulasEnum.BodyDensity:
                    {
                        return BodyDensityFormula;
                    }
                case FormulasEnum.OhmLaw:
                    {
                        return OhmLawFormula;
                    }
                default:
                    {
                        return "";
                    }
            }
        }
    }
}