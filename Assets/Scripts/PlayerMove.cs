using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
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

    [SerializeField] LayerMask groundLayer;

    public InputField inputField;


    //ONLY FOR THE PURPOSES OF ENABLING/DISABLING TEXT FIELD (FOR ALL INTENTS AND PURPOSES DO NOT USE THIS EVER)
    public GameObject field;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        //Gets input from the player and multiplies it by the runSpeed
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Handles the Jump operation
        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }


        //Handles the Mode Switch
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Switch Modes");

            //Enables the Type Script 
            this.GetComponent<TypingController>().enabled = true;

            //Enables the Text Field and selects it so that you can immediatley type in it
            field.SetActive(true);
            Select();

            //Disables the Move Script
            this.enabled = false;
        }
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);

        //If there is anything in the array then we are colliding with the ground so return true, else return false
        if(colliders.Length > 0)
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
