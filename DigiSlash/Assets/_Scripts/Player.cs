using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField]
    private float _speed = 4.5f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);



    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
   
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

        if (transform.position.x >= 11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11f)
        {
            transform.position = new Vector3(-11f,transform.position.y, 0);
        }
    }

}
