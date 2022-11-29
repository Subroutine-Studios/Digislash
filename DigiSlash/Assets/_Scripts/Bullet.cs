using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private float bulletDmg;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    public float _damage;

    [SerializeField]
    private GameObject trail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits anything thats not a player or a gate
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Gate")
        {
            if(explosion)
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

            /* Use only if you want particle effect upon hitting enemy
            if (collision.gameObject.tag == "Enemy")
            {
                
            }
            */
            Destroy(gameObject);
        }

            
    }
}
