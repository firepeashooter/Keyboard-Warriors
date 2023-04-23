using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class ReadInput : MonoBehaviour
{

    public InputField inputField;
    
    private string input;

    private Animator animator;

    [SerializeField] GameObject hitbox;

    Momentum mom; //Hopefully connects to the momentum script


    private void Start() 
    {
        Time.timeScale = 1;
        animator = GetComponent<Animator>(); 
        mom = GameObject.FindGameObjectWithTag("Player").GetComponent<Momentum>();
    }
    

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

                //Transitions to the punching state (automatically transitions back after is is done)
                animator.SetTrigger("isPunching");

                //Activates and Deactivates the hitbox
                StartCoroutine(HitboxDelay(1));

                //Gains Momentum
                mom.gainMomentum();


                break;

            case "kick":
                Debug.Log("You Kicked");


                StartCoroutine(HitboxDelay(1));
                animator.SetTrigger("isKicking");

                //Gains Momentum
                mom.gainMomentum();

                break;

            
            case "jumpkick":
                Debug.Log("You Jump Kicked");

                //Transitions to the punching state (automatically transitions back after is is done)
                animator.SetTrigger("isJumpKicking");

                //Gains Momentum
                mom.gainMomentum();

                break;

            case "combokick":
                Debug.Log("You Combo Kicked");

                //Transitions to the punching state (automatically transitions back after is is done)
                animator.SetTrigger("isComboKicking");

                //Gains Momentum
                mom.gainMomentum();

                break;
            case "":
                //Nothing is typed (escaping the type menu)
                break;
            //If none of the above words are typed we lose momentum.
            default:
                mom.loseMomentum();
                break;
            
        }
        
    }

    //Makes sure the hitbo doesn't instanly turn back off
    IEnumerator HitboxDelay(float duration){
        hitbox.SetActive(true);

        yield return new WaitForSeconds(duration);

        hitbox.SetActive(false);
    }
}
