using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float health, maxHealth = 20f;
   


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

     // Calculatest the ammount of damage the enemy has taken and if health gets below 0 it disapeares
    public void TakeDamage(float damageAmmount)
    {
        health -= damageAmmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Checks to see if it collides with the hitbox (activated by attacking)
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "HitBox"){
            Debug.Log("EnemyHit");
            TakeDamage(10);
        }

        if (other.gameObject.tag == "ULTIMATE"){
            Destroy(gameObject);
        }
    }
}
