using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{

    

    //Animation Controller
    private Animator animator;


    //Controls the Left and Right Speed of the Character
    [SerializeField] public float runSpeed = 5f;


    //Stores the Horizontal Move Input
    float horizontalMove;


    //Controls the Jump Height of the Character
    [SerializeField] float jumpHeight = 4f;

    private Rigidbody2D rb;


    //All Variables pretaining to the Ground/Ground Check
    [SerializeField] Transform groundCheckCollider;

    const float groundCheckRadius = 0.2f;

    //Everything we want the player to be able to jump off of
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask spikeLayer;

    public InputField inputField;

    public Transform camera;//Makes the camera move with the player's movement


    //ONLY FOR THE PURPOSES OF ENABLING/DISABLING TEXT FIELD (FOR ALL INTENTS AND PURPOSES DO NOT USE THIS EVER)
    public GameObject field;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    

    void Update()
    {

        if (transform.position.x > 206)
        {
            SceneManager.LoadScene("EndScene");
        }
        //Gets input from the player and multiplies it by the runSpeed
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        //Deals with he transition to running animation
        if(horizontalMove == 0){
            animator.SetBool("isMoving", false);
        }else
        {
            animator.SetBool("isMoving", true);
        }


        //Flips the character when going left or right
        if(horizontalMove > 0)
        {
            gameObject.transform.localScale = new Vector3(3,3,3); //Make sure this is equal to the scale of the player character!!!!

        }else if(horizontalMove < 0)
        {
            gameObject.transform.localScale = new Vector3(-3,3,3);
        }


        //Handles the Jump operation and vertical camera movement
        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        } else
        {
            animator.SetBool("isJumping", false);
        }


        //Handles the Mode Switch
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Switch Modes");

            //Get the camera to follow the player
            camera.position = transform.position;
            camera.position -= new Vector3(0, 0, 20);

            //Enables the Type Script 
            this.GetComponent<TypingController>().enabled = true;

            //Changes Player State to Typing State
            animator.SetBool("isTyping", true);

            //Enables the Text Field and selects it so that you can immediatley type in it
            field.SetActive(true);
            Select();

            //Disables the Move Script
            this.enabled = false;
        }

        //Get the camera to follow the player
        camera.position = transform.position;
        camera.position -= new Vector3(0, 0, 20);
        
    }

    
   


    private void FixedUpdate() 
    {
        //I'll be honest I have no idea what this is for
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime;
    }


    //Checks if the player is colliding with the ground
    bool GroundCheck()
    {
        //An aray containing anything colliding with the groundCheck gameObject in a certain radius, that is also part of the ground layer
        Collider2D[] groundColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        Collider2D[] spikeColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, spikeLayer);

        //If there is anything in the array then we are colliding with the ground so return true, else return false
        if(groundColliders.Length > 0 || spikeColliders.Length > 0)
        {
            return true;
        }else
        {
            return false;
        }
    }


    //Automatically Selects the InputField for easy typing (No having to click it constantly if you want to type)
    public void Select()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }


   

    
}
