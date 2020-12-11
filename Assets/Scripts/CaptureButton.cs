using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CaptureButton : MonoBehaviour
{
    public GameObject battleSong;
    public GameObject VictorySong;
    public GameObject enemy;
    public Animator capturedEnemy;
    public EnemyBehaviour enemyRef;
    public GameObject battleTextPanel;
    public TextMeshProUGUI battleText;
    private string m_enemyName;



    public void OnCaptureButtonPressed()
    {
        if(Random.value < .5) //Capture Completed
        {
            //SceneManager.LoadScene("SampleScene");
            Debug.Log("Captured");

            battleSong.SetActive(false);
            int capturedMon = capturedEnemy.GetInteger("PlayAnimation");
            enemy.SetActive(false);
            VictorySong.SetActive(true);
            switch (capturedMon)
            {
                case 0:
                    Debug.Log("You caught a Florgunk!");
                    PlayerPrefs.SetInt("CapturedMon", 0);
                    m_enemyName = "Florgunk";
                    break;
                case 1:
                    Debug.Log("You caught a Chardos!");
                    PlayerPrefs.SetInt("CapturedMon", 1);
                    m_enemyName = "Chardos";


                    break;
                case 2:
                    Debug.Log("You caught a Primcie!");
                    PlayerPrefs.SetInt("CapturedMon", 2);
                    m_enemyName = "Primcie";

                    break;
                case 3:
                    Debug.Log("You caught a Parino!");
                    PlayerPrefs.SetInt("CapturedMon", 3);
                    m_enemyName = "Parino";

                    break;
                default:
                    Debug.Log("You caught MissingNo.!");
                    PlayerPrefs.SetInt("CapturedMon", 10);
                    m_enemyName = "MissingNo.";

                    break;
            }
            StartCoroutine(WaitToChangeScene());
        }

        else //Capture failed
        {
            Debug.Log("Failed to Capture");
            enemyRef.enemyTurn = true;
        }
    }

    IEnumerator WaitToChangeScene()
    {

        battleTextPanel.SetActive(true);
        battleText.SetText("You caught " + m_enemyName + "!");
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("SampleScene");
        
    }



}
