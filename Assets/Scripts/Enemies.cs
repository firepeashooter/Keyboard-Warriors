
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [SerializeField] float leftbound = 0;
    [SerializeField] float rightbound = 0;

    public float speed = 5f;
    bool switc = true;
    private SpriteRenderer sr;

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        
        if(switc)
        {
            moveright();
        }
        if(!switc)
        {
            moveleft();
        }

        if(transform.position.x >= leftbound){
            switc = false;
            sr.flipX = false;
        }

         if(transform.position.x <= rightbound){
            switc = true;
            sr.flipX = true;
        }
    }

    void moveright(){
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void moveleft(){
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }


   
}

