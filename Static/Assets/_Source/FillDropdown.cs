using Formulas;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FillDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private string _displacement = "Displacement";
    private string _universalGravitation = "Universal Gravitation";
    private string _frictionForce = "Friction Force";
    private string _bodyDensity = "Body Density";
    private string _ohmLaw = "Ohm Law";

    private List<string> _options = new();

    private void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();

        _options.Add(_displacement);
        _options.Add(_universalGravitation);
        _options.Add(_frictionForce);
        _options.Add(_bodyDensity);
        _options.Add(_ohmLaw);

        _dropdown.AddOptions(_options);

        ChangeFormulaEnum();
    }
    public void ChangeFormulaEnum()
    {
        FormulasManager.instance.CurrentFormula = (FormulasEnum)_dropdown.value;
        FormulasManager.instance.Draw();
    }
}
