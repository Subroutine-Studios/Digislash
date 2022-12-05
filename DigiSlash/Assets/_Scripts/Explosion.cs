using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float _decayTime = 0.1f;
    [SerializeField]
    public float _damage = 60f;

    public bool isSingularity = false;
    public bool isPlague = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Decay(_decayTime));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * 50);
    }


    IEnumerator Decay(float decayTime)
    {
        yield return new WaitForSeconds(decayTime);
        Destroy(gameObject);
    }

}
