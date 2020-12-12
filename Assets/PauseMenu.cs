using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameSaver savingRef;
    public GameObject playerReference, pausePanel, statsPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OnSaveButtonPressed()
    {
        Debug.Log("Pressed the button");
        savingRef.Save();
    }
    public void OnStatsButtonPressed()
    {
        statsPanel.SetActive(true);
    }
    public void OnRespawnButtonClicked()
    {
        Time.timeScale = 1;
        playerReference.transform.position = new Vector3(-11.43f, -15.38f, 6.39f);
        
        pausePanel.SetActive(false);
        
    }

    public void OnCloseMenuButtonPressed()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        
    }

    public void OnBackToMenuButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }
}
