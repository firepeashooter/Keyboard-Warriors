using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULTIMATE : MonoBehaviour
{


    private float direction;
    private bool hit;
    private BoxCollider2D box;
    private float timer = 0;
    private Rigidbody2D rb;
    float horizontalMove;
    

    
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float movespeed = 5 * Time.deltaTime;
        transform.Translate(movespeed, 0, 0);



        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }

    }


    //Kills an enemy instantly
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

   
}
