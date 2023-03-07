using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class challenge2 : MonoBehaviour
{
    public TMP_InputField numInput;
    public TextMeshProUGUI outputResult;
    public Button submitBtn;

    public void CompareNums()
    {

        int input = int.Parse(numInput.text);
        string output = outputResult.text;

        if (input > 5)
        {
            output = input + " is bigger than 5.";
            outputResult.text = output;
        }
        else if (input < 5)
        {
            output = input + " is smaller than 5.";
            outputResult.text = output;
        }
        else
        {
            output = input + " is equal than 5.";
            outputResult.text = output;
        }
    }
}