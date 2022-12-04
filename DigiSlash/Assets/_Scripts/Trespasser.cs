using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trespasser : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;
    public float _health = 40f;

    [SerializeField]
    private float _explosionCooldown = 0f;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTracer._AIDestinationTarget.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemyTracer._target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        StartCoroutine("TrespasserFlickerRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    
        //If enemy dies, run Death()
        if (_health <= 0 && !dead)
        {
            dead = true;
            StartCoroutine(Death());
        }


        //Recharge cool down to 0.2 secs
        if (_explosionCooldown < 0.2f)
        {
            _explosionCooldown += Time.deltaTime;
        }


       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If a bullet hits the enemy, deal dmg equal the the bullet dmg
        if (collision.gameObject.tag == "Bullet")
        {
            _health -= collision.GetComponent<Bullet>()._damage;
        }
        


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");
            //stop flicker routine
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
           // StopCoroutine(TrespasserFlickerRoutine());
            StopCoroutine("TrespasserFlickerRoutine");


            // teleport behind player
            Vector3 posToTp = new Vector3(_enemyTracer._target.position.x - 0.1f, _enemyTracer._target.position.y + 1, _enemyTracer._target.position.z); // position of player
            transform.position = posToTp;



        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        //If an enemy stay inside an explosion while not immune, take dmg and start the explosion immunity timer
        if (collision.gameObject.tag == "Explosion" && _explosionCooldown >= 0.2f)
        {
            _health -= collision.GetComponent<Explosion>()._damage;
            _explosionCooldown = 0f;
        }
    }

    //Enemy turns red then dies shortly after
    private IEnumerator Death()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 255f);
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0);
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 255f);
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 255f);
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0);
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }


    private IEnumerator TrespasserFlickerRoutine()
    {

        while (!dead)
        {
      
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0);
            yield return new WaitForSeconds(2f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
            yield return new WaitForSeconds(3f);

      
     

        }
    }



}
