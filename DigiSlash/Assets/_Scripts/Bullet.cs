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

    [SerializeField]
    private bool isSticky = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits anything thats not a player or a gate
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Gate" && collision.gameObject.tag != "Explosion")
        {
            Debug.Log(collision);
            if (isSticky && explosion)
            {
                transform.parent = collision.transform;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                StartCoroutine(TimerToExplosion());
            }
        }

            else if (!isSticky && explosion)
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

            /* Use only if you want particle effect upon hitting enemy
            if (collision.gameObject.tag == "Enemy")
            {
                
            }
            */

            if(!isSticky)
                Destroy(gameObject);     
    }

    public IEnumerator TimerToExplosion()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
