using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReadInput : MonoBehaviour
{

    public InputField inputField;
    
    private string input;
    

    public void ReadStringInput(string s)
    {
        Select();
        //Stores the Input string (and prints it to the log)
        input = s;
        Debug.Log(s);
        

        //PROCESS THE STRING 
        Action(s);


        //Clears the Input Field
        inputField.text = "";

    }

    //Automatically Selects the InputField for easy typing (No having to click it constantly if you want to type)
    public void Select()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }



    void Action(string input)
    {
        //Standardizes the string (makes it non case sensitive)
        input = input.ToLower(); 

        
        switch(input)
        {
            case "punch":
                Debug.Log("You Punched");
                break;

            case "kick":
                Debug.Log("You Kicked");
                break;
        }
        
    }
}
