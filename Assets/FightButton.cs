using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightButton : MonoBehaviour
{
    public GameObject panelAbilities;
    public GameObject panelFightRun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSwitchPanelButtonPressed()
    {
        panelAbilities.SetActive(true);
        
    }
    
}
