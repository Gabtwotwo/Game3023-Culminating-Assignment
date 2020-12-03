using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeButtonBehaviour : MonoBehaviour
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

    public void OnEarthquakeButtonPressed()
    {
        if (GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn == false)
        {

            if (!alreadyAttacked)
            {
                if (manaref.mana > 0)
                {
                    StartCoroutine(AnimateEarthquake());
                    enemyRef.lastUsedMove = 3;
                    manaref.mana -= 10;
                }
                else { Debug.Log("You are out of mana!"); }

            }
        }

    }

    IEnumerator AnimateEarthquake()
    {
        alreadyAttacked = true;
        enemySprite.color = new Color(210.0f, 105.0f, 30.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = new Color(165.0f, 42.0f, 42.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        GameObject.Find("Enemy").GetComponent<EnemyBehaviour>().enemyTurn = true;
        alreadyAttacked = false;
    }
}
