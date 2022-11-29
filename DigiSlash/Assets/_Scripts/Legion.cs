using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legion : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;
    public float _health = 120f;

    private float _explosionCooldown = 0f;

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
        if (_health <= 0)
        {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If an enemy stay inside an explosion while not immune, take dmg and start the explosion immunity timer
        if (collision.gameObject.tag == "Explosion" && _explosionCooldown >= 2f)
        {
            _health -= collision.GetComponent<Explosion>()._damage;
            _explosionCooldown = 0f;
        }
    }

    //Enemy turns red then dies shortly after
    private IEnumerator Death()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
