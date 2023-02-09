using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;



public class ComposerAsst : MonoBehaviour
{
   
    // declare the variable compositionText to 
    public TextMeshProUGUI compositionText;



    // create a list to store each note of the composition
    List<AudioSource> composition = new List<AudioSource>();



    // create a function to play a note when pressed
    // noteAudioSource is an instance of the class AudioSource and represents a source of audio
    public void PlayNote(AudioSource noteAudioSource)
    {
        // play notes
        // noteAudioSource.Play();

        // record notes to a list
        // add an AudioSource object to the collection composition
        composition.Add(noteAudioSource);

        // declare the message as a string
        string message = "Your composition: ";
        // Debug.Log("This is your composition");

        // intead of compositionText.text = composition[0].name + composition[1].name, use for loop to output text
        // int index = 0: set the first item (i.e. index) in the composition list to 0
        // index < composition.Count where Count returns the number of elements in the collection
        // index += 1 is a shorthand of index = index + 1". It increments the value of the variable "index" by 1
        // the for loop tells the computer to output the message until it reaches the max number of the composiiton list

        for (int index = 0; index < composition.Count; index += 1)
        {
           message += composition[index].name;
          // Debug.Log(composition[index].name);
        }

       compositionText.text = message;
    }

   

    // private IEnumerator PlayAllNotes()
    // {
    //   foreach(AudioSource note in composition)
    // {
    //   note.Play();
    // yield return new WaitForSeconds(0.5f);
    // }
    // }



    private IEnumerator PlayAllNotes()
    {
        for (int index = 0; index < composition.Count; index += 1)
       {
          composition[index].Play();
          

            while (composition[index].isPlaying == true)
           {
               yield return null;
           }
        }
    }

    public void Play()
    {
        StartCoroutine(PlayAllNotes());
    }



    public void RemoveNote()
    {
        composition.Remove(composition[composition.Count - 1]);

        string message = "Your composition: ";
        for (int index = 0; index < composition.Count; index += 1)
        {
            message += composition[index].name;
            // Debug.Log(composition[index].name);
        }
        compositionText.text = message;

    }
}