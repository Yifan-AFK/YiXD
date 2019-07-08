using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BetterMovement : MonoBehaviour
{
    [SerializeField]
    float velocity;
    [SerializeField]
    bool isTopDown = false;
    Rigidbody2D XD;
    float verticalMove;
    float horizontalMove;
    [SerializeField]
    float verticalForce = 10.0f;
    bool isGrounded;
    private void Awake()
    {
        isGrounded = false;
        XD = GetComponent<Rigidbody2D>();
    }
    void moveCharacter()
    {
        if(isTopDown == false)
        {
            XD.gravityScale = 1.0f;
            horizontalMove = Input.GetAxisRaw("Horizontal") * velocity;
            Vector2 targetVelocity = new Vector2(horizontalMove, XD.velocity.y);
            Vector2 m_velocity = Vector2.zero;
            XD.velocity = Vector2.SmoothDamp(XD.velocity, targetVelocity, ref m_velocity, 0.05f);
        }
        else
        {
            XD.gravityScale = 0.0f;
            horizontalMove = Input.GetAxisRaw("Horizontal") * velocity;
            verticalMove = Input.GetAxisRaw("Vertical") * velocity;
            Vector2 targetVelocity = new Vector2(horizontalMove, verticalMove);
            Vector2 m_velocity = Vector2.zero;
            XD.velocity = Vector2.SmoothDamp(XD.velocity, targetVelocity, ref m_velocity, 0.05f);
        }
    }
    bool wasPressed;
    void betterJump()
    {
        float fallMultiplier = 2.5F;
        float lowJumpMultiplier = 2.0f;
        if (Input.GetButtonDown("Jump") && wasPressed)
        {
            XD.velocity = Vector2.up * verticalForce;
        }
        else
        {
            wasPressed = false;
        }
        if (XD.velocity.y < 0)
        {
            XD.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1)
                 * Time.fixedDeltaTime;
            //XD = XD +
        }
           else if(XD.velocity.y >0 && !Input.GetButton("Jump"))
        {
            XD.velocity += Vector2.up *  Physics2D.gravity.y *
            (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
    void Start () {
		
	}
    private void FixedUpdate()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i].gameObject.tag == "Ground")
            {
                wasPressed = true;
            }
        }
        if(isTopDown == false)
        {
            betterJump();
        }
        moveCharacter();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
