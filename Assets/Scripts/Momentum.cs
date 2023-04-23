using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Momentum : MonoBehaviour
{
    public bool isCharged = false;//checks if the momentum is at 100 (can power a super move)
    public int momentum = 0;
    public Sprite[] spriteCollection;
    public int spriteIndex = 0;
    public Image image;
    public GameObject bullet;
    public Transform bulletPos;

    // Update is called once per frame
    void Update()
    {
        image.sprite = spriteCollection[spriteIndex];//constantly updates the health image

        
    }

    public void gainMomentum()
    {
        momentum += 50;

        if (!isCharged)
        {
            spriteIndex += 1;//changes anim

            if (spriteIndex == spriteCollection.Length)//if the bar is charged
            {
                isCharged = true;
                Debug.Log("Charged");
                if (Input.GetKeyDown(KeyCode.C) == true){
                    useCharge();
                }
                    
            }
        }
    }

    //resets the bar
    public void useCharge()
    {
        spriteIndex = 0;
        isCharged = false;
        Instantiate(bullet, bulletPos.position, Quaternion.identity);        
    }

    //Resets the bar when we mess up (or can be changed to lose a little bit if need be)
    public void loseMomentum()
    {
        if (spriteIndex > 1)
        {
            spriteIndex -= 1;
        }
    }
}
