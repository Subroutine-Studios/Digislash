using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trespasser : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;

    [SerializeField]
    private float _health = 40f;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTracer._AIDestinationTarget.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemyTracer._target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {

    }
}
