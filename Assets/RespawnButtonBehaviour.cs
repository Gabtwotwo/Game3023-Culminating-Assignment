using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnButtonBehaviour : MonoBehaviour
{

    public GameObject playerReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRespawnButtonClicked()
    {
        playerReference.transform.position = new Vector3(-11.43f, -15.38f, 6.39f);
    }
}
