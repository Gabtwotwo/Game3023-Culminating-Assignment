using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public bool enemyTurn;
    public int lastUsedMove;
    private int mana = 100;

    // Start is called before the first frame update
    void Start()
    {
        enemyTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyTurn == true)
        {
            StartCoroutine(EnemyTurn());
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
                    }
                    else { Debug.Log("I'll attack with Poison Thorn!"); }
                    mana -= 10;
                    break;
                case 2:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Fireball!");
                    }
                    else { Debug.Log("I'll attack with Poison Thorn!"); }
                    mana -= 10;

                    break;
                case 3:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Ice Beam!");
                    }
                    else { Debug.Log("I'll attack with Earthquake!"); }
                    mana -= 10;

                    break;
                case 4:
                    if (Time.frameCount % 2 == 0)
                    {
                        Debug.Log("I'll attack with Ice Beam!");
                    }
                    else { Debug.Log("I'll attack with Fireball!"); }
                    mana -= 10;

                    break;
                default:
                    Debug.Log("I'll use Struggle!");
                    break;

            }
        }

        else { Debug.Log("I'm out of mana so..."); }

        Debug.Log("I end my turn");
        enemyTurn = false;
        return null;
    }
}
