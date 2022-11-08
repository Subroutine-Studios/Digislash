using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField]
    private float _speed = 4.5f;
    [SerializeField]
    private float _hitPoint = 1000f;
    [SerializeField]
    private Transform _firePos;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
   
    }


    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // moving one meter per second
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * Time.deltaTime * _speed);


        // up and down bounds

        if (transform.position.y >= 3.9f)
        {
            transform.position = new Vector3(transform.position.x, 3.9f, 0);
        }
        else if (transform.position.y <= -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }

        //  left and right bounds

        if (transform.position.x >= 7.5f)
        {
            transform.position = new Vector3(7.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -7.5f)
        {
            transform.position = new Vector3(-7.5f,transform.position.y, 0);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePos.position, _firePos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePos.right * _bulletForce, ForceMode2D.Impulse);
    }

}
