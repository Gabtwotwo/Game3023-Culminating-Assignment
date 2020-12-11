using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FireballButtonBehaviour : MonoBehaviour
{
    public SwitchPanel switchPanel;
    public SpriteRenderer enemySprite;
    public Color enemyColor;
    private bool alreadyAttacked;
    public EnemyBehaviour enemyRef;
    public ManaSystem manaref;
    public TextMeshProUGUI battleText;
    public GameObject battleTextPanel;
    public ParticleSystem Fireball;

    // Start is called before the first frame update
    void Start()
    {
        alreadyAttacked = false;
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
        var emitParams = new ParticleSystem.EmitParams();
        Fireball.Emit(emitParams, 500);
        enemyRef.TakeDamageEnemy(25);
        battleTextPanel.SetActive(true);
        battleText.SetText("Player used Fireball!");
        alreadyAttacked = true;
        enemySprite.color = Color.yellow;
        FindObjectOfType<AudioManager>().Play("Fireball");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("kill me");
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        yield return new WaitForSeconds(1.0f);
        battleTextPanel.SetActive(false);
        enemyRef.enemyTurn = true;
        alreadyAttacked = false;
        Fireball.Stop();
        switchPanel.OnSwitchPanelButtonPressed();
    }
}
