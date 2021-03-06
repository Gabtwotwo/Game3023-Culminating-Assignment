﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManaSystem : MonoBehaviour
{
    public int mana;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar playerHealth;
    public GameSaver loadGame;
    // Start is called before the first frame update
    void Start()
    {
        mana = 100;
        currentHealth = maxHealth;
        playerHealth.SetMaxHealth(maxHealth);
        
    }
    
    public void TakeDamagePlayer(int damage)
    {
        if(damage > currentHealth)
        {
            //die
            Debug.Log("Player Die");
            SceneManager.LoadScene("SampleScene");

            PlayerPrefs.SetInt("If first save used", 1);
        }
        else
        {
            currentHealth -= damage;
            playerHealth.setHealth(currentHealth);
        }
        

    }
}
