using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonButtonBehaviour : MonoBehaviour
{

    public SpriteRenderer enemySprite;
    public Color enemyColor;
    private bool alreadyAttacked;
    public EnemyBehaviour enemyRef;
    public ManaSystem manaref;



    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer enemySprite = GetComponent<SpriteRenderer>();
        //Color enemyColor = GetComponent<Color>();
        alreadyAttacked = false;
        EnemyBehaviour enemyRef = GetComponent<EnemyBehaviour>();
        ManaSystem manaref = GetComponent<ManaSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPoisonButtonPressed()
    {
        if (GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn == false)
        {
            if (!alreadyAttacked)
            {
                if (manaref.mana > 0)
                {
                    StartCoroutine(AnimatePoison());
                    enemyRef.lastUsedMove = 4;
                    manaref.mana -= 10;

                }
                else { Debug.Log("You are out of mana!"); }

            }
        }

    }

    IEnumerator AnimatePoison()
    {
        alreadyAttacked = true;
        enemySprite.color = new Color(128.0f, 0.0f, 128.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = new Color(148.0f, 0.0f, 211.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn = true;
        alreadyAttacked = false;
    }
}
