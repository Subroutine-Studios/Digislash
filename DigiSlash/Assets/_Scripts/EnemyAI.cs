using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private Transform _target;


    [SerializeField] private Rigidbody2D _rb;


    [SerializeField] private float _health = 3f;

    [SerializeField] private AIDestinationSetter _AIDestinationTarget;


    // Start is called before the first frame update
    void Start()
    {
        _AIDestinationTarget.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= _target.transform.position.x)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}
