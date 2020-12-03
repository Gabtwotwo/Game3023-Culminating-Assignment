using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonBehaviour : MonoBehaviour
{

    public GameSaver savingRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnSaveButtonPressed()
    {
        Debug.Log("Pressed the button");
        savingRef.Save();
    }
}
