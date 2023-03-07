using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class challenge3 : MonoBehaviour
{
    public TMP_InputField inputNum1;
    public TMP_InputField inputNum2;
    public Button submitButton;
    public TextMeshProUGUI outputResult;

    public void sumNumbers()
    {
     int input1 = int.Parse(inputNum1.text);
     int input2 = int.Parse(inputNum2.text);
     int sum;

     string output = outputResult.text;
     sum = input1 + input2;

     output = "The sum of the 2 numbers are " + sum + ".";

     outputResult.text = output;
    }
}
