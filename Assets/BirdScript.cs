using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidObject;
    public float flapStrength;
    public LogicScript logic;
    public static bool birdIsAlive = true;
    public AudioSource audioFlap;
    public AudioSource audioStart; 

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdIsAlive = true;
        audioStart.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidObject.velocity = Vector2.up * flapStrength;
            audioFlap.Play();
        }

        if (Mathf.Abs(transform.position.y) > 14.6)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false; 
    }
}
