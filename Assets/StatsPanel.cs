using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsPanel : MonoBehaviour
{
    public TextMeshProUGUI captured, defeated;
    public GameObject statsPanel;
    // Update is called once per frame
    void Update()
    {
        captured.SetText(PlayerPrefs.GetInt("CapturedMon").ToString());
        defeated.SetText(PlayerPrefs.GetInt("DefeatedMon").ToString());
    }
    public void onButtonPressed()
    {
        statsPanel.SetActive(false);
    }
}
