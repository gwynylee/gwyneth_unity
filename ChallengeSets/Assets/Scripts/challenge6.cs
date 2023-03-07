using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class challenge6 : MonoBehaviour
{
    public TMP_InputField input1;
    public TMP_InputField input2;
    public Button submitBtn;
    public TextMeshProUGUI output;

    
    public void power()
    {
        int baseNum = int.Parse(input1.text);
        int expNum = int.Parse(input2.text);
        int result = 1;

        for (int i = 0; i < expNum; i++)
        {
            result *= baseNum;
        }
        output.text = result.ToString();
    }
}
