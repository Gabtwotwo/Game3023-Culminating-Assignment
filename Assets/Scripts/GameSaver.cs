using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    PlayerController playerRef;


    public void Save()
    {
        Debug.Log("Saved!");
        PlayerPrefs.SetInt("Hellokey", 10);



        PlayerPrefs.SetFloat("X position", transform.position.x);
        PlayerPrefs.SetFloat("Y position", transform.position.y);
        PlayerPrefs.Save();
    }

    public void Load()
    {

        if(PlayerPrefs.GetFloat("X Position") == 0.0f && PlayerPrefs.GetFloat("Y Position") == 0.0f)
        {
            Debug.Log("Initial load!");
            PlayerPrefs.SetFloat("X position", -14.4f);
            PlayerPrefs.SetFloat("Y position", 11.2f);
        }

        Debug.Log("Loaded!");
        transform.position = new Vector3(PlayerPrefs.GetFloat("X position"), PlayerPrefs.GetFloat("Y position"), 6.0f);
    } 


}
