using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float velocity;
    public float verticalForceMagnitude;
    Rigidbody2D XD;
    bool Ground;
    int numJumps;
    const int Limitjumps = 2;
    // Use this for initialization
    void Start()
    {
        XD = GetComponent<Rigidbody2D>();
        Ground = true;// false
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Jump") && Ground)
        {
            XD.AddForce(Vector2.up * verticalForceMagnitude);
            if (numJumps == Limitjumps)
            {
                Ground = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
            XD.velocity += Vector2.up * velocity;
        if (Input.GetKeyDown(KeyCode.S))
            XD.velocity += Vector2.down * velocity;
        if (Input.GetKeyDown(KeyCode.D))
            XD.velocity += Vector2.right * velocity;
        if (Input.GetKeyDown(KeyCode.A))
            XD.velocity += Vector2.left * velocity;

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetvelocity;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Ground = true;
            numJumps = 0;
        }
    }
}