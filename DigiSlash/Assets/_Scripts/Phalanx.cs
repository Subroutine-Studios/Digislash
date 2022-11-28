using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phalynx : MonoBehaviour
{
    [SerializeField]
    private EnemyTracing _enemyTracer;
    
    public float _health = 500f;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTracer._AIDestinationTarget.target = GameObject.FindGameObjectWithTag("Gate").GetComponent<Transform>();
        _enemyTracer._target = GameObject.FindGameObjectWithTag("Gate").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
