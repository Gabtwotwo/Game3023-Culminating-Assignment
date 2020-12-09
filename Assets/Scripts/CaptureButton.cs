using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CaptureButton : MonoBehaviour
{
    public void OnCaptureButtonPressed()
    {
        if(Random.value < .5) //Capture Completed
        {
            //SceneManager.LoadScene("SampleScene");
            Debug.Log("Captured");
        }

        else //Capture failed
        {
            Debug.Log("Failed to Capture");
            
        }
    }
}
