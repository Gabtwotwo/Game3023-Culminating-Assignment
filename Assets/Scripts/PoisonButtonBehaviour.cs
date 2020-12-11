using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PoisonButtonBehaviour : MonoBehaviour
{
    public SwitchPanel switchPanel;

    public SpriteRenderer enemySprite;
    public Color enemyColor;
    private bool alreadyAttacked;
    public EnemyBehaviour enemyRef;
    public ManaSystem manaref;
    public TextMeshProUGUI battleText;
    public ParticleSystem poison;

    public GameObject battleTextPanel;

    // Start is called before the first frame update
    void Start()
    {
        
        alreadyAttacked = false;
        
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
        var emitParams = new ParticleSystem.EmitParams();
        poison.Emit(emitParams, 500);
        enemyRef.TakeDamageEnemy(15);
        battleTextPanel.SetActive(true);
        battleText.SetText("Player used Poison Spit");
        alreadyAttacked = true;
        enemySprite.color = new Color(128.0f, 0.0f, 128.0f, 255.0f);
        FindObjectOfType<AudioManager>().Play("Poison Thorn");

        yield return new WaitForSeconds(1.0f);
        enemySprite.color = new Color(148.0f, 0.0f, 211.0f, 255.0f);
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        yield return new WaitForSeconds(1.0f);       
        battleTextPanel.SetActive(false);
        enemyRef.enemyTurn = true;
        alreadyAttacked = false;
        poison.Stop();
        switchPanel.OnSwitchPanelButtonPressed();
        

    }
}
