using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class CalculatorScript2 : MonoBehaviour
{
    float input1;
    float input2;
    
    string currentMode;
    string newMode;
   
    public TMP_Text output;

    string currentInputMode = "input1";

    
    public void NumberClicked(int number)
    {
        Debug.Log(number);
        

        if (currentInputMode == "input1" )
        {
               input1 = input1 * 10 + number;
               output.text = input1.ToString();
        }
        else
        {
               input2 = input2 * 10 + number;
               output.text = input2.ToString();
        }
    }

    public void Operation(string val)
    {
        Debug.Log(val);
        currentMode = val;
        output.text = currentMode.ToString();
        currentInputMode = "input2";
    }

    public void EqualMode(string equal)
    {
        Debug.Log(equal);

        float result = 0;

        if (currentMode == "/" && input2 == 0)
        {
            output.text = "Error! Denominator cannot be 0";
            return;
        }

  
        {
            switch (currentMode)
            {
                case "/":
                    result = input1 / input2;
                    break;

                case "*":
                    result = input1 * input2;
                    break;

                case "-":
                    result = input1 - input2;
                    break;

                case "+":
                    result = input1 + input2;
                    break;
            }

            output.text = result.ToString();

            input1 = result;
            input2 = 0;
        }
    }

    public void SetMode()
        {
            currentMode = newMode;
            output.text = currentMode.ToString();
        }

        public void ClearResult()
        {
            input1 = 0;
            input2 = 0;
            output.text = "0";
        }
    }




