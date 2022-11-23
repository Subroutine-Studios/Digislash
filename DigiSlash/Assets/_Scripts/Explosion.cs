using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float _decayTime = 0.1f;
    [SerializeField]
    private float _damage = 60f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Decay(_decayTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.GetComponent<EnemyTracing>().health -= _damage;
        }

    }

    IEnumerator Decay(float decayTime)
    {
        yield return new WaitForSeconds(decayTime);
        Destroy(gameObject);
    }

}
