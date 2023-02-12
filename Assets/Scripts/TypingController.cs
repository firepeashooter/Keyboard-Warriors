using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypingController : MonoBehaviour
{
    public InputField inputField;

    //ONLY FOR THE PURPOSES OF ENABLING/DISABLING TEXT FIELD (FOR ALL INTENTS AND PURPOSES DO NOT USE THIS EVER)
    public GameObject field;

    
    // Update is called once per frame
    void Update()
    {
        
        //Handles the Mode Switch
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Switch Modes");

            //Disables the Text Field
            field.SetActive(false);

            //Disables the Type Script and enables the Move Script
            this.GetComponent<PlayerMove>().enabled = true;
            this.enabled=false;


        }
    }

    
}
