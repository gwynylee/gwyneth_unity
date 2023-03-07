using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class challenge7 : MonoBehaviour
{
    public TMP_InputField tempInput;
    public TMP_InputField weatherInput;
    public Button submitBtn;
    public TextMeshProUGUI output;

    public void jacket()
    {
        int temp = int.Parse(tempInput.text);
        string weather = weatherInput.text;
        string result = output.text;

        if (temp < 5 || weather == "Y")
        {
            result = "You should wear a jacket.";
            output.text = result;

            // Debug.Log("You should wear a jacket.");
        }
        else {
            result = "You don't need a jacket.";
            output.text = result;

            // Debug.Log("You don't need a jacket.");
        }
        

    }
}
