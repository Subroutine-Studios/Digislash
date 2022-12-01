using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildPhase : MonoBehaviour
{


    //proceed button
    [SerializeField]
    private GameObject _proceedBtn;


    // bullet type buttons
    [SerializeField]
    private GameObject _bulletBtn;
    [SerializeField]
    private GameObject _rocketBtn;
    [SerializeField]
    private GameObject _stickyBtn;

    //trait buttons
    [SerializeField]
    private GameObject _multiShotBtn;
    [SerializeField]
    private GameObject _warpedBtn;
    [SerializeField]
    private GameObject _rapidFireBtn;

    //switch weap button
    [SerializeField]
    private GameObject _weap1Btn;
    [SerializeField]
    private GameObject _weap2Btn;

    // function content
    [SerializeField]
    private Text _fcBulletTypeText;
    [SerializeField]
    private Text _fcSubTypeText;
    [SerializeField]
    private Text _fcBaseDmgText;
    [SerializeField]
    private Text _fcRpsText;


    // trait description content
    [SerializeField]
    private Text _traitDescText;


    // Store values
    public static Weapon[] _weapons;

    public static int _selectedWeap; // 0 is Weap 1 , 1 is Weap 2

    [SerializeField]
    private GameObject _prefabA;
    [SerializeField]
    private GameObject _prefabB;


    // player
    private Player _player;


    void Start()
    {
        // Weapon 1 is selected by default
        _selectedWeap = 0;

        _weapons = new Weapon[2];

        _weapons[0] = new Weapon("null", "null", "null", 0, 0, 0, 0, 0, 0, _prefabA, _prefabB);
        _weapons[1] = new Weapon("null", "null", "null", 0, 0, 0, 0, 0, 0, _prefabA, _prefabB);


        Debug.Log("Buld phase start: " + _weapons[_selectedWeap].bullet + " selected weapon : " + _selectedWeap);


    }



    // CHANGE THIS
    // Update weapon array values

    public void updateWeaponList(string bullet, string bulletSubTypeA, string bulletSubTypeB, float bulletForceA, float bulletForceB, float baseDmgA, float baseDmgB, float rpsA, float rpsB, GameObject prefabA, GameObject prefabB)
    {
        _weapons[_selectedWeap].bullet = bullet;
        _weapons[_selectedWeap].bulletSubTypeA = bulletSubTypeA;
        _weapons[_selectedWeap].bulletSubTypeB = bulletSubTypeB;
        _weapons[_selectedWeap].bulletForceA = bulletForceA;
        _weapons[_selectedWeap].bulletForceB = bulletForceB;


        _weapons[_selectedWeap].baseDmgA = baseDmgA;
        _weapons[_selectedWeap].baseDmgB = baseDmgB;

        _weapons[_selectedWeap].rpsA = rpsA;
        _weapons[_selectedWeap].rpsB = rpsB;

        _weapons[_selectedWeap].prefabA = prefabA;
        _weapons[_selectedWeap].prefabB = prefabB;

    }



    // On Click Methods for Bullet type selection


    public void bulletBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "INT";
        _fcSubTypeText.text = "Shrapnel, Tracer";
        _fcBaseDmgText.text = "12";
        _fcRpsText.text = "10 ";

        updateWeaponList("INT", "Shrapnel", "Tracer", 8, 8, 12, 12, 10, 10, _prefabA, _prefabB);



        //  Debug.Log("BUTTON CLICK : Values of array weapon : "+ " weap # " + _selectedWeap + _weapons[_selectedWeap].bullet);


    }

    public void rocketBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "FL";
        _fcSubTypeText.text = "Nuclear, Napalm";
        _fcBaseDmgText.text = "60";
        _fcRpsText.text = "1";

        updateWeaponList("FL", "Nuclear", "Napalm", 8, 8, 60, 60, 1, 1, _prefabA, _prefabB);


    }

    public void stickyBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "STR";
        _fcSubTypeText.text = "Plague, Singularity";
        _fcBaseDmgText.text = "30";
        _fcRpsText.text = "4";


        updateWeaponList("STR", "Plague", "Singularity", 8, 8, 30, 30, 4, 4, _prefabA, _prefabB);

    }

    // On Click Methods for Traits

    public void multiShotBtnClick()
    {
        // display description
        _traitDescText.text = "+ 4 Projectile count (shoots 5 projectiles with a spread at a time)\n- Range";

    }


    public void warpedBtnClick()
    {
        // display description
        _traitDescText.text = " > Bullets spawn from crosshair\n > 50 % fire rate";

    }


    public void rapidFireBtnClick()
    {
        // display description
        _traitDescText.text = "+ 30% fire rate\n- 15 % damage";

    }



    public void weap1BtnClick()
    {
        _selectedWeap = 0;
        updateFunctionScreen();

    }

    public void weap2BtnClick()
    {
        _selectedWeap = 1;
        updateFunctionScreen();

    }

    public void updateFunctionScreen()
    {
        _fcBulletTypeText.text = _weapons[_selectedWeap].bullet;
        _fcSubTypeText.text = _weapons[_selectedWeap].bulletSubTypeA;
        _fcBaseDmgText.text = _weapons[_selectedWeap].baseDmgA.ToString();
        _fcRpsText.text = _weapons[_selectedWeap].rpsA.ToString();
    }










}
