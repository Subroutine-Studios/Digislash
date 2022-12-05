using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phalanx : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;
    
    public float _health = 500f;

    private float _damageCooldown = 0f;

    private bool dead = false;

    private bool blockHits = false;

    private bool deadByPlague = false;
    [SerializeField]
    private GameObject plague;

    private Transform _player;
    private Transform _gate;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _gate = GameObject.FindGameObjectWithTag("Gate").GetComponent<Transform>();


        _enemyTracer._AIDestinationTarget.target = _gate;
        _enemyTracer._target = _gate;


    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);

        if(distanceFromPlayer < 5f)
        {
            _enemyTracer._AIDestinationTarget.target = _player;
            _enemyTracer._target = _player;
        }

        else
        {
            _enemyTracer._AIDestinationTarget.target = _gate;
            _enemyTracer._target = _gate;
        }


        //If enemy dies, run Death()
        if (_health <= 0 && !dead)
        {
            dead = true;
            StartCoroutine(Death());
        }

        //Recharge damage down to 0.8 secs
        if (_damageCooldown < 0.8f)
        {
            _damageCooldown += Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If a bullet hits the enemy, deal dmg equal the the bullet dmg
        if (collision.gameObject.tag == "Bullet")
        {
            if(_damageCooldown >= 0.8f)
            {
                _health -= collision.GetComponent<Bullet>()._damage;
                _damageCooldown = 0;
            }
        }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        //If an enemy stay inside an explosion while not immune, take dmg and start the explosion immunity timer
        if (collision.gameObject.tag == "Explosion" && _damageCooldown >= 0.8f)
        {
            _health -= collision.GetComponent<Explosion>()._damage;

            //If a plague explosion kills the enemy
            if (_health <= 0 && collision.GetComponent<Explosion>().isPlague)
                deadByPlague = true;

            //Pull enemy towards singularity
            else if (collision.GetComponent<Explosion>().isSingularity)
            {
                Vector3 playerPos = collision.transform.position - transform.position;
                gameObject.GetComponent<Rigidbody2D>().AddForce(playerPos.normalized * 800f);
            }

            _damageCooldown = 0f;
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

        //If the enemy is infected, die with plague explosion
        if (deadByPlague)
            Instantiate(plague, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);
    }
}
