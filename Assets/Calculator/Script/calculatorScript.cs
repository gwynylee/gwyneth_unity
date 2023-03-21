using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class calculatorScript : MonoBehaviour
{
    public TMP_Text output;

    int currentNumber;
    string currentMode;
    string inputSequence;
    string result;

    public Button equalBtn;

    //   public Button addBtn;
    //   public Button subtractBtn;
    //   public Button multiplyBtn;
    //   public Button divideBtn;

    // number in this function is set to be an integer
    // if currentNumber is clicked, add it to number
    // the result is stored in currentNumber
    // output the result of currentNumber and set it to a string
    public void NumberClicked(int number)
    {
        if (currentMode == "+")
        {
            
            currentNumber = currentNumber + number;
            Debug.Log(currentNumber);
        }
        else if (currentMode == "-")
        {
            currentNumber = currentNumber - number;
        }
        inputSequence += number.ToString();
        
        output.text = inputSequence.ToString();
    }

   public void Equal()
   {
       output.text = result;
   }
    // Add event listeners to each operation button

//    private void Start()
//    {
//
//
//        addBtn.onClick.AddListener(() =>
//        {
//            currentMode = "+";
//        });
//
//        subtractBtn.onClick.AddListener(() =>
//        {
//            currentMode = "-";
//        });
//
//        multiplyBtn.onClick.AddListener(() =>
//        {
//            currentMode = "*";
//        });
//
//        divideBtn.onClick.AddListener(() =>
//        {
//            currentMode = "/";
//        });
//    }
//

//   if (hasEnteredNumber == true)
//   {
//       output.text = (enterNumber + number).ToString();
//   }
//   else
//   {
//       enterNumber = number;
//       hasEnteredNumber = true;
//       output.text = number.ToString();
//   }
//


    // this function sets the next mode of operation 
    public void SetMode(string newMode)
    {
        currentMode = newMode;
        inputSequence += newMode.ToString();
        output.text = inputSequence.ToString();
    }

    // this function clears all entries in the output
    public void ClearNumber()
    {
        currentNumber = 0;
        output.text = currentNumber.ToString();
    }

}    