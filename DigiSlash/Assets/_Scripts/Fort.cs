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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            StartCoroutine(DamageOverTime());
        }
    }

    IEnumerator DamageOverTime()
    {        
        _leaks -= 2f;
        yield return new WaitForSeconds(10f);
    }
}
