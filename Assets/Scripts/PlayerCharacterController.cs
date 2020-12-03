using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello World");
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontale"), Input.GetAxis("Vertical"));
        movementVector *= Time.deltaTime * speed;

        transform.Translate(movementVector);
    }
}
