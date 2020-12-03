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
     
       
        
        Debug.Log("Loaded!");
        transform.position = new Vector3(PlayerPrefs.GetFloat("X position"), PlayerPrefs.GetFloat("Y position"), 6.0f);
    } 


}
