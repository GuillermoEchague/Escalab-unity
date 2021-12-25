using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public static playerController instance;

    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump; 
    public float jumpForce;
    public float bounceForce; 
    
    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    public float KnockBackLength, KnockBackForce;
    public float KnockBackCounter;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(KnockBackCounter <= 0) {
            
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

         if (Input.GetButtonDown("Jump")) {
                      

            if(isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                  // Debug.Log("Jump!2");
            } 
            else 
            {
                    if(canDoubleJump)
                    {
                       theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                       canDoubleJump = false;
                        // Debug.Log("Jump!3");
                    }
             }
        }

        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        } else if(theRB.velocity.x > 0) {
            theSR.flipX = false;
        } 
        }
        else {
           KnockBackCounter -= Time.deltaTime;
           if(!theSR.flipX){
               theRB.velocity = new Vector2(-KnockBackForce, theRB.velocity.y);
           } else {
                theRB.velocity = new Vector2(KnockBackForce, theRB.velocity.y);
           }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded",isGrounded);
    }

    public void  Knockback() {
        KnockBackCounter = KnockBackLength;
        theRB.velocity = new Vector2(0f, KnockBackForce);
    }

    public void Bounce(){
        theRB.velocity= new Vector2(theRB.velocity.x, bounceForce);
    }
}
