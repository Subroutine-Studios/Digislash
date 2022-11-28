using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trespasser : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;
    public float _health = 40f;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTracer._AIDestinationTarget.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemyTracer._target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _health -= 5f;
        }
    }
}
