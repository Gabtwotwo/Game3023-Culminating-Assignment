﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void OnStartButtonPressed()
    {
        Debug.Log("Pressed the button");
        SceneManager.LoadScene("SampleScene");
    }
}