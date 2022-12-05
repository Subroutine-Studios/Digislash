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
    private GameObject _shatter;

    [SerializeField]
    public bool isShrapnel = false;
    public bool isTracer = false;

    [SerializeField]
    private bool isSticky = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits anything thats not a player or a gate
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Gate" && collision.gameObject.tag != "Explosion" && collision.gameObject.tag != "Bullet")
        {            
            //Bullet sticks to object if it is sticky
            if (isSticky && explosion)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                // creates joint
                FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
                // sets joint position to point of contact
                joint.anchor = transform.position;
                // conects the joint to the other object
                joint.connectedBody = collision.GetComponent<Rigidbody2D>();
                // Stops objects from continuing to collide and creating more joints
                joint.enableCollision = false;

                StartCoroutine(TimerToExplosion());
            }

            else if (!isSticky && explosion)
                Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);

            /* Use only if you want particle effect upon hitting enemy
            if (collision.gameObject.tag == "Enemy")
            {
                
            }
            */

            if (!isSticky)
                Destroy(gameObject);
        }

                
    }

    public IEnumerator TimerToExplosion()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
        Destroy(gameObject);
    }
}
