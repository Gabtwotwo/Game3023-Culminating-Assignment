using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSaver : MonoBehaviour
{
    
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
        
            float xSave = PlayerPrefs.GetFloat("X position");
            float ySave = PlayerPrefs.GetFloat("Y position");

            if (xSave == 0.0f && ySave == 0.0f)
            {
                Debug.Log("Initial load!");
                PlayerPrefs.SetFloat("X position", -15.77f);
                PlayerPrefs.SetFloat("Y position", -17.82f);
            }


            Debug.Log("Loaded!");
            transform.position = new Vector3(PlayerPrefs.GetFloat("X position"), PlayerPrefs.GetFloat("Y position"), 6.0f);
            Debug.Log("not supposed to happen regular load");
           

    }

    public void SaveEncounterPosition()
    {
        PlayerPrefs.SetFloat("current X position", transform.position.x);
        PlayerPrefs.SetFloat("current Y position", transform.position.y);
        PlayerPrefs.Save();
    }

    public void LoadEncounterPosition()
    {
        //SceneManager.LoadScene("SampleScene");
        transform.position = new Vector3(PlayerPrefs.GetFloat("current X position"), PlayerPrefs.GetFloat("current Y position"), 6.0f);
        Debug.Log(transform.position);
    }

    public void SetBool(int num)
    {
        PlayerPrefs.SetInt("If first save used", num);
    }
}
