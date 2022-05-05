using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour
{
    public AudioClip correct;
    public AudioClip incorrect;
    

    public void playCorrect()
    {
        AudioSource.PlayClipAtPoint(correct, new Vector3(0, 10, 0));
        
    }

    public void playIncorrect()
    {
        AudioSource.PlayClipAtPoint(incorrect, new Vector3(0, 10, 0));
    
    }
}
