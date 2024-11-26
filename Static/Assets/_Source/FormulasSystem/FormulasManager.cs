using ConstVar;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Formulas
{
    public class FormulasManager : MonoBehaviour
    {
        public static FormulasManager instance;

        public FormulasEnum CurrentFormula { get; set; }
        public object Resource { get; private set; }

        [SerializeField] private GameObject slot3;
        [SerializeField] private TMP_InputField inputField1, inputField2, inputField3;
        [SerializeField] private TextMeshProUGUI formula, varSlot1, varSlot2, varSlot3, resultText;
        [SerializeField] private Button calculateButton;

        private FormulasSO _formulasSO;

        private void Awake()
        {
            instance = this;

            ConstantVariables.Load();
            _formulasSO = Resources.Load("Formulas") as FormulasSO;
        }
        private void Start()
        {
            Draw();
            calculateButton.onClick.AddListener(Calculate);
        }
        public void Draw()
        {
            SetSlots();
            SetFormula();
            ResetResult();
        }
        private void SetSlots()
        {
            switch(CurrentFormula)
            {
                case FormulasEnum.Displacement:
                    {
                        slot3.SetActive(false);
                        varSlot1.text = _formulasSO.DisplacmentParametr1;
                        varSlot2.text = _formulasSO.DisplacmentParametr2;
                        break;
                    }
                case FormulasEnum.UniversalGravitation:
                    {
                        slot3.SetActive(true);
                        varSlot1.text = _formulasSO.UniversalGravitationParametr1;
                        varSlot2.text = _formulasSO.UniversalGravitationParametr2;
                        varSlot3.text = _formulasSO.UniversalGravitationParametr3;
                        break;
                    }
                case FormulasEnum.FrictionForce:
                    {
                        slot3.SetActive(false);
                        varSlot1.text = _formulasSO.FrictionForceParametr1;
                        varSlot2.text = _formulasSO.FrictionForceParametr2;
                        break;
                    }
                case FormulasEnum.BodyDensity:
                    {
                        slot3.SetActive(false);
                        varSlot1.text = _formulasSO.BodyDensityParametr1;
                        varSlot2.text = _formulasSO.BodyDensityParametr2;
                        break;
                    }
                case FormulasEnum.OhmLaw:
                    {
                        slot3.SetActive(false);
                        varSlot1.text = _formulasSO.OhmLawParametr1;
                        varSlot2.text = _formulasSO.OhmLawParametr2;
                        break;
                    }
            }
        }
        private void SetFormula()
        {
            formula.text = _formulasSO.GetFormulaString(CurrentFormula);
        }
        private void ResetResult()
        {
            inputField1.text = "0";
            inputField2.text = "0";
            inputField3.text = "0";
            resultText.text = "Result = ?";
        }
        private void Calculate()
        {
            switch(CurrentFormula)
            {
                case FormulasEnum.Displacement:
                    {
                        resultText.text = $"Result = {Math.Round(Formulas.GetDisplacement(Convert.ToSingle(inputField1.text), Convert.ToSingle(inputField2.text)), 3)}";
                        break;
                    }
                case FormulasEnum.UniversalGravitation:
                    {
                        resultText.text = $"Result = {Formulas.GetUniversalGravitation(Convert.ToSingle(inputField1.text), Convert.ToSingle(inputField2.text), Convert.ToSingle(inputField3.text))}";
                        break;
                    }
                case FormulasEnum.FrictionForce:
                    {
                        resultText.text = $"Result = {Math.Round(Formulas.GetFrictionForce(Convert.ToSingle(inputField1.text), Convert.ToSingle(inputField2.text)), 3)}";
                        break;
                    }
                case FormulasEnum.BodyDensity:
                    {
                        resultText.text = $"Result = {Math.Round(Formulas.GetBodyDensity(Convert.ToSingle(inputField1.text), Convert.ToSingle(inputField2.text)), 3)}";
                        break;
                    }
                case FormulasEnum.OhmLaw:
                    {
                        resultText.text = $"Result = {Math.Round(Formulas.GetOhmLaw(Convert.ToSingle(inputField1.text), Convert.ToSingle(inputField2.text)), 3)}";
                        break;
                    }
            }
        }
    }
}