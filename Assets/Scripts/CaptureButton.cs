using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CaptureButton : MonoBehaviour
{
    public GameObject battleSong;
    public GameObject VictorySong;
    public GameObject enemy;
    public Animator capturedEnemy;

    


    public void OnCaptureButtonPressed()
    {
        if(Random.value < .5) //Capture Completed
        {
            //SceneManager.LoadScene("SampleScene");
            Debug.Log("Captured");

            battleSong.SetActive(false);
            int capturedMon = capturedEnemy.GetInteger("PlayAnimation");
            enemy.SetActive(false);
            VictorySong.SetActive(true);
            switch (capturedMon)
            {
                case 0:
                    Debug.Log("You caught a Florgunk!");
                    break;
                case 1:
                    Debug.Log("You caught a Chardos!");
                    break;
                case 2:
                    Debug.Log("You caught a Primcie!");
                    break;
                case 3:
                    Debug.Log("You caught a Parino!");
                    break;
                default:
                    Debug.Log("You caught MissingNo.!");
                    break;
            }

        }

        else //Capture failed
        {
            Debug.Log("Failed to Capture");
            
        }
    }





}
