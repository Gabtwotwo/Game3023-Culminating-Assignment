using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    
    public GameObject panelAbilities;
    public GameObject panelFightRun;
    private bool a = true;
    private bool b = false;
    public void OnSwitchPanelButtonPressed()
    {
        panelAbilities.SetActive(a);
        panelFightRun.SetActive(b);
        if(a)
        {
            a = false;
        }
        else
        {
            a = true;
        }

        if (b)
        {
            b = false;
        }
        else
        {
            b = true;
        }
        
    }
}
