using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class challenge4 : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public Button addBtn;
    public Button subBtn;
    public TextMeshProUGUI resultOutput;

    private int input1;
    private int input2;
    private string output;

    private void GetInputOutput()
    {
        input1 = int.Parse(inputField1.text);
        input2 = int.Parse(inputField2.text);
        string output = resultOutput.text;
    }

    public void addNumbers()
    {
        GetInputOutput();

        int sum;
        sum = input1 + input2;

        output = "The sum of the 2 numbers are " + sum + ".";
        resultOutput.text = output;
    }

    public void subNumbers()
    {

        GetInputOutput();
        
        int sub;

        sub = input1 - input2;

        output = "The subtraction of the 2 numbers are " + sub + ".";
        resultOutput.text = output;
    }
}
