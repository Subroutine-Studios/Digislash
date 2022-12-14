using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private float bulletDmg;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private float _damage;

    [SerializeField]
    private GameObject trail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            if(explosion)
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

            if (collision.gameObject.tag == "Enemy")
            {
                //collision.GetComponent<Trespasser>()._health -= _damage;
            }
            Destroy(gameObject);
        }

            
    }
}
