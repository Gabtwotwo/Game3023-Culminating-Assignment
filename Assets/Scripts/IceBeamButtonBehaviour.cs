using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IceBeamButtonBehaviour : MonoBehaviour
{

    public SpriteRenderer enemySprite;
    public Color enemyColor;
    private bool alreadyAttacked;
    public EnemyBehaviour enemyRef;
    public ManaSystem manaref;
    public SwitchPanel switchPanel;
    public TextMeshProUGUI battleText;
    public GameObject battleTextPanel;
    public ParticleSystem ice;
    // Start is called before the first frame update
    void Start()
    {
        alreadyAttacked = false;
        


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
        var emitParams = new ParticleSystem.EmitParams();
        ice.Emit(emitParams, 500);
        enemyRef.TakeDamageEnemy(10);
        battleTextPanel.SetActive(true);

        battleText.SetText("Player used Ice Beam!");
        alreadyAttacked = true;
        enemySprite.color = Color.cyan;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = Color.blue;
        yield return new WaitForSeconds(1.0f);
        enemySprite.color = enemyColor;
        yield return new WaitForSeconds(1.0f);
        battleTextPanel.SetActive(false);
        enemyRef.enemyTurn = true;
        alreadyAttacked = false;
        ice.Stop();
        switchPanel.OnSwitchPanelButtonPressed();
    }
}
