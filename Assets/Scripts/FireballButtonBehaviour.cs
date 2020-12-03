using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballButtonBehaviour : MonoBehaviour
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

    public void OnFireballButtonPressed()
    {
        if (GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn == false)
        {
            if (!alreadyAttacked)
            {
                if (manaref.mana > 0)
                {

                    StartCoroutine(AnimateFireball());
                    enemyRef.lastUsedMove = 1;
                    manaref.mana -= 10;

                }
                else { Debug.Log("You are out of mana!"); }

            }
        }
    }

    IEnumerator AnimateFireball()
    {
        alreadyAttacked = true;
        enemySprite.color = Color.yellow;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn = true;
        alreadyAttacked = false;
    }
}
