
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool noDamage = true;
    public int health = 100;
    public Sprite[] spriteCollection;
    public int spriteIndex = 0;
    public Image image;

    void Update()
    {
        if (!noDamage)//if damage has been taken before
        {
            image.sprite = spriteCollection[spriteIndex];//constantly updates the health image
        }
        
    }

    // When SendMessage is recieved, this will be called and the player will lose health
    void loseHealth()
    {
        health -= 10;
        if (noDamage)
        {
            noDamage = false;//intended to show that health has not been damaged once
        } else
        {
            if (spriteIndex < spriteCollection.Length)
            {
                spriteIndex += 1;//change displayed anim
            } else
            {
                //Restart cuz game over
                SceneManager.LoadScene("SampleScene");
            }
            
        }
        

    }


    //Deals with the player being hit by an enemy
     private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Enemy"){
            Debug.Log("Ouch");
            loseHealth();
        }

        if (other.gameObject.tag == "Spikes"){
            Debug.Log("Spiked");
            loseHealth();
        } 

        
    }

    //This deals with the bullets as they are trigger colliders and not regular colliders
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Bullet"){
            Debug.Log("Shot");
            loseHealth();
        } 

        
    }

   
    
}

