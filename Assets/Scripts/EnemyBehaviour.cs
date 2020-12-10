using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        enemyTurn = false;
        m_animator = GetComponent<Animator>();
        switch(Random.Range(0, 4))
        {
            case 0:
                m_animator.SetInteger("PlayAnimation", 0);
                enemyName.SetText("Florgunk");
                break;
            case 1:
                m_animator.SetInteger("PlayAnimation", 1);
                enemyName.SetText("Chardos");

                break;
            case 2:
                m_animator.SetInteger("PlayAnimation", 2);
                enemyName.SetText("Primcie");

                break;
            case 3:
                m_animator.SetInteger("PlayAnimation", 3);
                enemyName.SetText("Parino");

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
        if(enemyTurn == true)
        {
            StartCoroutine(EnemyTurn());
        }
    }
    public void TakeDamageEnemy(int damage)
    {
        if (damage > currentHealth)
        {
            //die
            Debug.Log("Die");
            SceneManager.LoadScene("SampleScene");
            
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
                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Poison Thorn!");
                        player.TakeDamagePlayer(5);

                    }
                    mana -= 10;
                    break;
                case 2:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Fireball!");
                        player.TakeDamagePlayer(10);
                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Poison Thorn!");
                        player.TakeDamagePlayer(5);
                    }
                    mana -= 10;

                    break;
                case 3:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Ice Beam!");
                        player.TakeDamagePlayer(10);
                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Earthquake!");
                        player.TakeDamagePlayer(15);
                    }
                    mana -= 10;

                    break;
                case 4:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Ice Beam!");
                        player.TakeDamagePlayer(10);
                    }
                    else 
                    { 
                        Debug.Log("I'll attack with Fireball!");
                        player.TakeDamagePlayer(10);
                    }
                    mana -= 10;

                    break;
                default:
                    Debug.Log("I'll use Struggle!");
                    player.TakeDamagePlayer(15);
                    TakeDamageEnemy(10);
                    break;

            }
        }

        else { Debug.Log("I'm out of mana so..."); }

        Debug.Log("I end my turn");
        enemyTurn = false;
        yield return new WaitForEndOfFrame();
    }
}
