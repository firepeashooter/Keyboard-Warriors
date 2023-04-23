using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    [SerializeField] int radius = 10;
    

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //Distance betwen the player and the Enemy
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        //Only shoots the player if it is at distance radius
        if(distance < radius){
            timer += Time.deltaTime;

            //Shoots a bullet every 2 seconds
            if(timer > 2)
            {
                timer = 0;
                shoot();
            }


        }
        
    }

    //Creates the bullet and shoots it
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}
