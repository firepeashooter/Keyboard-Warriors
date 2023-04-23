using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypingController : MonoBehaviour
{
    public InputField inputField;

    //Animation Controller
    private Animator animator;

    //ONLY FOR THE PURPOSES OF ENABLING/DISABLING TEXT FIELD (FOR ALL INTENTS AND PURPOSES DO NOT USE THIS EVER)
    public GameObject field;


    private void Start() 
    {
       animator = GetComponent<Animator>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //Handles the Mode Switch
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Switch Modes");

            //Disables the Text Field
            field.SetActive(false);

            //Changes the State of the player back to Idle
            animator.SetBool("isTyping", false);

            //Disables the Type Script and enables the Move Script
            this.GetComponent<PlayerMove>().enabled = true;
            this.enabled=false;


        }
    }

    
}
