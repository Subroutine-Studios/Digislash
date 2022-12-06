using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legion : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;
    public float _health = 120f;

    private float _explosionCooldown = 0f;

    private bool dead = false;

    private bool deadByPlague = false;
    
    [SerializeField]
    private GameObject plague;

    [SerializeField]
    private GameObject _enemySmallLegion;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTracer._AIDestinationTarget.target = GameObject.FindGameObjectWithTag("Gate").GetComponent<Transform>();
        _enemyTracer._target = GameObject.FindGameObjectWithTag("Gate").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy dies, run Death()
        if (_health <= 0 && !dead)
        {
            dead = true;
            StartCoroutine(Death());

           // StartCoroutine(SpawnSmallLegions());
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If an enemy stay inside an explosion while not immune, take dmg and start the explosion immunity timer
        if (collision.gameObject.tag == "Explosion" && _explosionCooldown >= 0.2f)
        {
            _health -= collision.GetComponent<Explosion>()._damage;


            //If a plague explosion kills the enemy
            if(_health <= 0 && collision.GetComponent<Explosion>().isPlague)
                deadByPlague = true;

            //Pull enemy towards singularity
            else if (collision.GetComponent<Explosion>().isSingularity)
            {
                Vector3 playerPos = collision.transform.position - transform.position;
                gameObject.GetComponent<Rigidbody2D>().AddForce(playerPos.normalized * 800f);
            }

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

        //If the enemy is infected, die with plague explosion
        if (deadByPlague)
            Instantiate(plague, gameObject.transform.position, gameObject.transform.rotation);

        //Destroy(gameObject);


        yield return new WaitForSeconds(0.5f);

        int enemyCount = 5;


        GameObject enemy = _enemySmallLegion;

        while (enemyCount > 0)
        {
            Debug.Log("Enemy Count " + enemyCount);
         
            Vector3 posToSpawn = new Vector3(transform.position.x, transform.position.y, transform.position.z); // position to spawn (x,y,z)
            GameObject newEnemy = Instantiate(enemy, posToSpawn, Quaternion.identity);

            enemyCount--;

            yield return new WaitForSeconds(0.2f); // wait n seconds before spawning

        }

        Destroy(gameObject);
    }
 
}
