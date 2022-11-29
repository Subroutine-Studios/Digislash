using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
    public float _leaks = 10f; // fort HP

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If an enemy that is not a trespasser attacks fort after their cooldown ends
        if (collision.tag == "Enemy" && !collision.GetComponent<Trespasser>() && collision.GetComponent<EnemyTracing>().attackCooldown >= 5f)
        {
            _leaks -= 2f;
            collision.GetComponent<EnemyTracing>().attackCooldown = 0f;
        }
    }

}