using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class challenge5 : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TMP_InputField numInput;
    public Button submitBtn;
    public TextMeshProUGUI output;

    public void DisplayName()
    {
        string nameValue = nameInput.text;
        int numValue = int.Parse(numInput.text);
        string outputName = output.text;
        // outputName = "You have entered " + numValue + ".";
        output.text = outputName;

        for (int i = 0; i < numValue; i++)
        {
            output.text += nameValue + "\n";
        }
    }





}
