using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //private Rigidbody2D rb2d;

    public GameSaver savingRef;

    private Animator m_animator;
    public GameObject grassSong;
    public GameObject villageSong;
    //private void Start()
    //{
    //    rb2d = GetComponent<Rigidbody2D>();
    //}
    private float speed = 5.0f;


    void Start()
    {
        savingRef.Load();
        m_animator = GetComponent<Animator>();
        
    }


    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Not in grass");
            if (transform.position.x > -11 && transform.position.x < -3 && transform.position.y < -1 && transform.position.y > -10)
            {
                grassSong.SetActive(true);
                villageSong.SetActive(false);

                Debug.Log("Waiting for 5000th frame");
                if (Time.frameCount % 5000 == 0)
                {
                    savingRef.Save();
                    SceneManager.LoadScene("EncounterScene");

                }
            }
            else { grassSong.SetActive(false);
                villageSong.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        movement *= Time.deltaTime;
        movement *= speed;

        

       // rb2d.AddForce(movement);
        transform.Translate(movement);
        
        
        if(moveHorizontal < 0)
        {
            m_animator.SetInteger("AnimState", 1);
        }
        else if(moveHorizontal > 0)
        {
            m_animator.SetInteger("AnimState", 2);

        }
        else if(moveVertical > 0)
        {
            m_animator.SetInteger("AnimState", 0);
        }
        else if(moveVertical < 0)
        {
            m_animator.SetInteger("AnimState", 3);
        }
        else
        {
            m_animator.SetInteger("AnimState", 4);
        }

    }
}

