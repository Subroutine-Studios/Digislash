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
    private GameObject _firePos;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletForce = 20f;
    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2 mousePos;
    [SerializeField]
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is for other calculations
    void Update()
    {
        //Get mouse position
        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        CalculateMovement();
        CalculateAim();

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
            transform.position = new Vector3(-7.5f, transform.position.y, 0);
        }

    }

    void CalculateAim()
    {
        //Calculate angle relative to the middle of the camera 
        Vector2 lookDir = mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        //If angle is at the left side of screen
        if (angle > 0 || angle < -180)
        {
            //Flip player
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            //Switch the fire position to the left side
            _firePos.transform.position = transform.position + new Vector3(-0.16f, 0.0007f, 0f);
            
            //If fireposition had a sprite model (Ex. gun)
            //_firePos.GetComponent<SpriteRenderer>().flipX = true;
        }

        //If angle is at the right side of screen
        else
        {
            //Flip player
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

            //Switch the fire position to the right side
            _firePos.transform.position = transform.position + new Vector3(0.16f, 0.0007f, 0f);
            
            //If fireposition had a sprite model (Ex. gun)
            //_firePos.GetComponent<SpriteRenderer>().flipX = false;
        }

        //Rotate fireposition to aim bullets
        _firePos.GetComponent<Rigidbody2D>().rotation = angle;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePos.transform.position, _firePos.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePos.transform.up * _bulletForce, ForceMode2D.Impulse);
    }

}
