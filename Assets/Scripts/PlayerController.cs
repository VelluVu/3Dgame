using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float moveSpeed = 1.7f;
    private float chargeMultiplier = 1.3f;
    private float directionSpeed = 2f;
    private float jumpForce = 4f;
    private float exhaustOverTime = 0.1f;
    private float exhaustBurst = 15f;
    private float exhausted = 10f;
    private float waitExhausted;
    private Vector3 verticalVelocity;

    private float rotateSpeed = 180f;
    
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveVector;
    private Vector3 momentumSlide;

    private Rigidbody controller;
    private Animator playerAnimator;
    StaminaController stamControl;

    private bool canDoubleJump = false;
    private bool isGrounded;
    private int jumps = 1;
    private int jumpCounter = 0;


    // Use this for initialization
    void Start () {

        controller = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        stamControl = GetComponent<StaminaController>();
        
    }
	
	// Update is called once per frame
	void Update () {

        Exhausted();
        PlayerMove();
        Charge();
        WalkAnimation();
        PlayerTurn(); 
        PlayerJump();

    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMove()
    {
        //Uses basic up,down,w,s inputs and applies them into vector3 z axis.
      
        moveDirection = new Vector3(0f, 0f, moveSpeed * Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= directionSpeed;
        
        controller.AddForce(moveDirection);
        

    }
    void PlayerTurn()
    {

        transform.Rotate(0, rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal"),0);
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && jumpCounter <= 1 && stamControl.curStam >= 15)
        {
            stamControl.DrainStamina(exhaustBurst);
            controller.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCounter++;
        }
        
    }
    void WalkAnimation()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftShift))
        {
            
            playerAnimator.SetTrigger("Walk");
            
            
        } 
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetTrigger("Walk");
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftShift))
        {
            
            playerAnimator.SetTrigger("Idle");
            stamControl.RegenStamina(exhaustOverTime * 0.5f);

        }
    }
    void Charge()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && stamControl.curStam >= 0 && waitExhausted == 0)
        {
            stamControl.DrainStamina(exhaustOverTime);
            directionSpeed = moveSpeed * chargeMultiplier;
            playerAnimator.SetTrigger("Charge");
            
            if (stamControl.curStam == 0)
            {
                waitExhausted = exhausted;
                directionSpeed = moveSpeed;
                
            }
        }
        else
        {
            directionSpeed = moveSpeed;
            stamControl.RegenStamina(exhaustOverTime * 0.25f);
        
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground") {
            jumpCounter = 0;
        }
    }
    public void Die()
    {
        controller.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void Exhausted()
    {
        if (waitExhausted > 0)
        {
            waitExhausted -= Time.deltaTime;
        }

        if (waitExhausted < 0)
        {
            waitExhausted = 0;
        }
    }
}
