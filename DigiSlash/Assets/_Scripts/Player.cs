using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 200f;


    [SerializeField]
    private float _speed = 4.5f;
    [SerializeField]
    private GameObject _firePos;
    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2 mousePos;
    [SerializeField]
    private Camera _cam;

    [SerializeField]
    private Weapon[] _weapons;
    [SerializeField]
    private Weapon _currentWeapon;
    public int _weaponIndex = 0;

    [SerializeField]
    private bool _canShoot = true;

    private float _cooldown = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _currentWeapon = _weapons[0];
    }

    void Awake()
    {
        //  _weapons = Build_Phase.buildPhaseScene._weapons;
      // _weapons = BuildPhase._weapons;

    }

    // Update is for other calculations
    void Update()
    {
        //Allow player functionality as long as player is alive
        if(health > 0)
        {
            //Get mouse position
            mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);


            CalculateMovement();
            CalculateAim();

            if (Input.GetButton("Fire1") && _canShoot)
            {
                Shoot();
                _canShoot = false;
                StartCoroutine(ShotTimer(_currentWeapon.rps));
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weaponIndex++;
                if (_weaponIndex >= _weapons.Length) _weaponIndex = 0;
                _currentWeapon = _weapons[_weaponIndex];
            }

            if (_cooldown < 2)
                _cooldown += Time.deltaTime;
        }

        

    }



    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // moving one meter per second
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        //transform.Translate(direction * Time.deltaTime * _speed);
        _rb.velocity = direction * Time.fixedDeltaTime * _speed;


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

    //Shoot bullet based on the weapon and its stats 
    void Shoot()
    {
        GameObject bullet = Instantiate(_currentWeapon.prefab, _firePos.transform.position, _firePos.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePos.transform.up * _currentWeapon.bulletForce, ForceMode2D.Impulse);
    }

    //Cooldown for shooting a weapon based on the weapon stats
    IEnumerator ShotTimer(float rps)
    {
        float delay = 1f / rps;
        yield return new WaitForSeconds(delay);
        _canShoot = true;
    }

    //When player gets hit, play short blinking animation 
    public IEnumerator CooldownEffect()
    {
        //hit.Play();

        while (_cooldown < 2 && health > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            //firePoint.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            //firePoint.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(0.2f);
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        //firePoint.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If enemy touches a player, take damage and start immunity cooldown
        if (collision.gameObject.tag == "Enemy")
        {
            _cooldown = 0;
            health -= 20f;
            StartCoroutine(CooldownEffect());
        }


    }

}