using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyTracing : MonoBehaviour
{


    public Transform _target;

    [SerializeField] private Rigidbody2D _rb;

    public AIDestinationSetter _AIDestinationTarget;

    public float attackCooldown = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= _target.transform.position.x)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        if (attackCooldown < 5f)
        {
            attackCooldown += Time.deltaTime;
        }
    }
}
