using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeamButtonBehaviour : MonoBehaviour
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

    public void OnIceBeamButtonPressed()
    {
        if (GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn == false)
        {

            if (!alreadyAttacked)
            {
                if (manaref.mana > 0)
                {

                    StartCoroutine(AnimateIceBeam());
                    enemyRef.lastUsedMove = 2;
                    manaref.mana -= 10;

                }
                else { Debug.Log("You are out of mana!"); }

            }
        }

    }

    IEnumerator AnimateIceBeam()
    {
        alreadyAttacked = true;
        enemySprite.color = Color.cyan;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = Color.blue;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn = true;
        alreadyAttacked = false;
    }
}
