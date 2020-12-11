using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EarthquakeButtonBehaviour : MonoBehaviour
{
    public SwitchPanel switchPanel;

    public SpriteRenderer enemySprite;
    public Color enemyColor;
    private bool alreadyAttacked;
    public EnemyBehaviour enemyRef;
    public ManaSystem manaref;
    public TextMeshProUGUI battleText;
    public GameObject battleTextPanel;

    // Start is called before the first frame update
    void Start()
    {

        alreadyAttacked = false;


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
        enemyRef.TakeDamageEnemy(15);
        battleTextPanel.SetActive(true);
        battleText.SetText("Player used Earthquake!");
        alreadyAttacked = true;
        enemySprite.color = new Color(210.0f, 105.0f, 30.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = new Color(165.0f, 42.0f, 42.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        yield return new WaitForSeconds(1.0f);
        battleTextPanel.SetActive(false);
        enemyRef.enemyTurn = true;
        alreadyAttacked = false;
        switchPanel.OnSwitchPanelButtonPressed();
    }
}
