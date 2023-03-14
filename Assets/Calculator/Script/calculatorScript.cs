using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class calculatorScript : MonoBehaviour
{
    public TMP_Text output;

    // int enterNumber;
    // bool hasEnteredNumber;

    int currentNumber;
    string currentMode = "+";

    // number in this function is set to be an integer
    // if currentNumber is clicked, add it to number
    // the result is stored in currentNumber
    // output the result of currentNumber and set it to a string
    public void NumberClicked(int number)
    {
        if (currentMode == "+")
        {
            Add(number);
        }
       else if (currentMode == "-")
        {
            Subtract(number);
        }
       else if (currentMode == "*")
       {
            Multiply(number);
       }
       else 
       {
            Divide(number);
       }
    
      // output.text = currentNumber.ToString();
    }

    // this function is for addition
    public void Add(int number)
    {
        if (currentMode == "+")
        {
            output.text = currentNumber.ToString(); 
            output.text = currentMode;
            output.text = currentNumber.ToString();
            currentNumber = currentNumber + number;
        }
    }

    // this function is for subtraction
    public void Subtract(int number)
    {
        if (currentMode == "-")
        {
            currentNumber = currentNumber - number;
        }
    }

    // this function is for mulitiplication
    public void Multiply(int number)
    {
        if (currentMode == "*")
        {
            currentNumber = currentNumber * number;
        }
    }

    // this function is for division
    public void Divide(int number)
    {
        if (currentMode == "/")
        {
            currentNumber = currentNumber / number;
        }
    }


    // this function sets the next mode of operation 
    public void SetMode(string newMode)
    {
        currentMode = newMode;
    }

    // this function clears all entries in the output
    public void ClearNumber()
    {
        currentNumber = 0;
        output.text = currentNumber.ToString();
    }

}    