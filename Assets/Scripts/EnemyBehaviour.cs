﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EnemyBehaviour : MonoBehaviour
{
    public ManaSystem player;
    private Animator m_animator;

    public bool enemyTurn;
    public int lastUsedMove;
    private int mana;

    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar enemyHealth;

    public TextMeshProUGUI enemyName;
    private string m_enemyName;

    public TextMeshProUGUI battleText;

    public GameObject battleTextPanel;
    public SpriteRenderer playerSprite;
    public Color playerColor;
    public GameObject victorySong;
    public GameObject battleSong;

    public GameSaver gameSaver;
    public ParticleSystem earthquake, fireball, poison, ice;

    // Start is called before the first frame update
    void Start()
    {
        enemyTurn = false;
        m_animator = GetComponent<Animator>();
        switch(Random.Range(0, 4))
        {
            case 0:
                m_animator.SetInteger("PlayAnimation", 0);
                m_enemyName = "Florgunk";
                enemyName.SetText(m_enemyName);
                break;
            case 1:
                m_animator.SetInteger("PlayAnimation", 1);
                m_enemyName = "Chardos";
                enemyName.SetText(m_enemyName);

                break;
            case 2:
                m_animator.SetInteger("PlayAnimation", 2);
                m_enemyName = "Primcie";
                enemyName.SetText(m_enemyName);

                break;
            case 3:
                m_animator.SetInteger("PlayAnimation", 3);
                m_enemyName = "Parino";
                enemyName.SetText(m_enemyName);

                break;
            default:
                Debug.Log("How did we get here?");
                break;

        }
        mana = 100;
        currentHealth = maxHealth;
        enemyHealth.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            enemyTurn = false;
            battleSong.SetActive(false);
            victorySong.SetActive(true);
            StartCoroutine(WaitToChangeScene());

        }
        if (enemyTurn == true)
        {
            StartCoroutine(EnemyTurn());
        }


    }
    public void TakeDamageEnemy(int damage)
    {
        if (damage > currentHealth || currentHealth == 0)
        {
            //die
            Debug.Log("Enemy Die");
            StartCoroutine(WaitToChangeScene());
 


        }
        else
        {
            currentHealth -= damage;
            enemyHealth.setHealth(currentHealth);
        }


    }
    IEnumerator EnemyTurn()
    {
        Debug.Log("It's my turn!");
        //yield return new WaitForSeconds(2);
        Debug.Log("I'm thinking...");
        //yield return new WaitForSeconds(1);
        Debug.Log(lastUsedMove);


        if (mana > 0)
        {
            switch (lastUsedMove)
            {
                case 1:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Earthquake!");
                        player.TakeDamagePlayer(15);
                        StartCoroutine(AnimateEarthquake());

                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Poison Spit!");
                        player.TakeDamagePlayer(5);
                        StartCoroutine(AnimatePoison());


                    }
                    mana -= 10;
                    break;
                case 2:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Fireball!");
                        player.TakeDamagePlayer(10);
                        StartCoroutine(AnimateFireball());

                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Poison Spit!");
                        player.TakeDamagePlayer(5);
                        StartCoroutine(AnimatePoison());

                    }
                    mana -= 10;

                    break;
                case 3:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Ice Beam!");
                        player.TakeDamagePlayer(10);
                        StartCoroutine(AnimateIceBeam());

                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Earthquake!");
                        player.TakeDamagePlayer(15);
                        StartCoroutine(AnimateEarthquake());

                    }
                    mana -= 10;

                    break;
                case 4:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Ice Beam!");
                        player.TakeDamagePlayer(10);
                        StartCoroutine(AnimateIceBeam());

                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Fireball!");
                        player.TakeDamagePlayer(10);
                        StartCoroutine(AnimateFireball());

                    }
                    mana -= 10;

                    break;
                default:
                    Debug.Log("I'll use Struggle!");
                    player.TakeDamagePlayer(15);
                    TakeDamageEnemy(10);
                    StartCoroutine(AnimateStruggle());
                    break;

            }
        }

        else { Debug.Log("I'm out of mana so..."); }

        Debug.Log("I end my turn");
        enemyTurn = false;
        yield return new WaitForEndOfFrame();
    }

    IEnumerator AnimatePoison()
    {
        var emitParams = new ParticleSystem.EmitParams();
        poison.Emit(emitParams, 500);
        battleTextPanel.SetActive(true);
        battleText.SetText(m_enemyName + " used Posion Thorn");
        playerSprite.color = new Color(128.0f, 0.0f, 128.0f, 255.0f);
        FindObjectOfType<AudioManager>().Play("Poison Thorn");

        yield return new WaitForSeconds(1.0f);
        playerSprite.color = new Color(148.0f, 0.0f, 211.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        playerSprite.color = playerColor;
        yield return new WaitForSeconds(1.0f);
        poison.Stop();
        battleTextPanel.SetActive(false);
    }
    IEnumerator AnimateIceBeam()
    {
        var emitParams = new ParticleSystem.EmitParams();
        ice.Emit(emitParams, 500);
        battleTextPanel.SetActive(true);
        battleText.SetText( m_enemyName + " used Ice Beam");
        playerSprite.color = Color.cyan;
        FindObjectOfType<AudioManager>().Play("Ice Beam");

        yield return new WaitForSeconds(1.0f);
        playerSprite.color = Color.blue;
        yield return new WaitForSeconds(1.0f);
        playerSprite.color = playerColor;
        yield return new WaitForSeconds(1.0f);
        ice.Stop();
        battleTextPanel.SetActive(false);
    }
    IEnumerator AnimateEarthquake()
    {
        var emitParams = new ParticleSystem.EmitParams();
        earthquake.Emit(emitParams, 500);
        battleTextPanel.SetActive(true);
        battleText.SetText(m_enemyName + " used Earthquake");
        playerSprite.color = new Color(210.0f, 105.0f, 30.0f, 255.0f);
        FindObjectOfType<AudioManager>().Play("Earthquake");

        yield return new WaitForSeconds(1.0f);
        playerSprite.color = new Color(165.0f, 42.0f, 42.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        playerSprite.color = playerColor;
        yield return new WaitForSeconds(1.0f);
        earthquake.Stop();
        battleTextPanel.SetActive(false);
    }
    IEnumerator AnimateFireball()
    {
        var emitParams = new ParticleSystem.EmitParams();
        fireball.Emit(emitParams, 500);
        battleTextPanel.SetActive(true);
        battleText.SetText(m_enemyName + " used Fireball");
        playerSprite.color = Color.yellow;
        FindObjectOfType<AudioManager>().Play("Fireball");

        yield return new WaitForSeconds(1.0f);
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        playerSprite.color = playerColor;
        yield return new WaitForSeconds(1.0f);
        fireball.Stop();
        battleTextPanel.SetActive(false);
    }
    IEnumerator AnimateStruggle()
    {
        
        battleTextPanel.SetActive(true);
        battleText.SetText(m_enemyName + " used Struggle");
        yield return new WaitForSeconds(3.0f);
        battleTextPanel.SetActive(false);
    }
    IEnumerator WaitToChangeScene()
    {

        battleTextPanel.SetActive(true);
        battleText.SetText("You defeated " + m_enemyName + "!");
        transform.position = new Vector3(1000, 1000, 1000);
        

        
        yield return new WaitForSeconds(10.0f);
        PlayerPrefs.SetInt("DefeatedMon", PlayerPrefs.GetInt("DefeatedMon") + 1);
        SceneManager.LoadScene("SampleScene");

    }

}
