using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChallengeScript : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TextMeshProUGUI output;
    public Button submitButton;

    public void Challenge1()
    {
        string name = nameInput.text;
        string age = ageInput.text;
        
        output.text = "Your name is " + name + ", and you are " + age + " years old.";
        Debug.Log(output.text);
    }

    public void Start()
    {
        submitButton.onClick.AddListener(Challenge1);
    }
}

