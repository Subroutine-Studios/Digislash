using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildPhase : MonoBehaviour
{

    // scene reference
    public static BuildPhase buildPhaseScene;

    //proceed button
    public GameObject _proceedBtn;


    // bullet type buttons
    public GameObject _bulletBtn;
    public GameObject _rocketBtn;
    public GameObject _stickyBtn;

    //trait buttons
    public GameObject _multiShotBtn;
    public GameObject _ricochetBtn;


    public GameObject _warpedBtn;
    public GameObject _doubleEdgeBtn;
    public GameObject _rapidFireBtn;
    public GameObject _heavyBtn;
    public GameObject _overClockedBtn;

    //equip trait button


    //switch weap button
    public GameObject _weap1Btn;
    public GameObject _weap2Btn;

    // function content

    public Text _fcBulletTypeText;
    public Text _fcSubTypeText;
    public Text _fcBaseDmgText;
    public Text _fcRpsText;


    // trait description content
    public Text _traitDescText;


    // Store values
    public static Weapon[] _weapons;

    public static int _selectedWeap; // 0 is Weap 1 , 1 is Weap 2


    // player

    private Player _player;


    void Start()
    {
        // Weapon 1 is selected by default
        _selectedWeap = 0;

        _weapons = new Weapon[2];

        // CHANGE THIS
        _weapons[0] = new Weapon("null", "null", 0, 0);
        _weapons[1] = new Weapon("null 1", "null 1", 0, 0);

        Debug.Log("Buld phase start: " + _weapons[_selectedWeap].bullet + " selected weapon : " + _selectedWeap);

        buildPhaseScene = this;

      //  _player = GameObject.Find("Player");

       


    }



    // CHANGE THIS
    // Update weapon array values
    public void updateWeaponList(string bullet, string bulletSubType, string baseDmg, string rps)
    {
        _weapons[_selectedWeap].bullet = bullet;
        _weapons[_selectedWeap].bulletSubType = bulletSubType;
        _weapons[_selectedWeap].baseDmg = float.Parse(baseDmg);
        _weapons[_selectedWeap].rps = float.Parse(rps);

    }



    // On Click Methods for Bullet type selection


    public void bulletBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "INT";
        _fcSubTypeText.text = "Shrapnel, Tracer";
        _fcBaseDmgText.text = "12";
        _fcRpsText.text = "10 " ;

        updateWeaponList("INT", "Shrapnel, Tracer", "12", "10");


      //  Debug.Log("BUTTON CLICK : Values of array weapon : "+ " weap # " + _selectedWeap + _weapons[_selectedWeap].bullet);


    }

    public void rocketBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "FL";
        _fcSubTypeText.text = "Nuclear, Napalm";
        _fcBaseDmgText.text = "60";
        _fcRpsText.text = "1";

        updateWeaponList("FL", "Nuclear, Napalm", "60", "1");

    }

    public void stickyBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "STR";
        _fcSubTypeText.text = "Plague, Singularity";
        _fcBaseDmgText.text = "30";
        _fcRpsText.text = "4";

        updateWeaponList("STR", "Plague, Singularity", "30", "4");

    }

    // On Click Methods for Traits

    public void multiShotBtnClick()
    {
        // display description
        _traitDescText.text = "+ 4 Projectile count (shoots 5 projectiles with a spread at a time)\n- Range";

    }

    public void ricochetBtnClick()
    {
        // display description
        _traitDescText.text = "Projectiles bounce once on enemy hit";

    }

    public void warpedBtnClick()
    {
        // display description
        _traitDescText.text = " > Bullets spawn from crosshair\n > 50 % fire rate";

    }

    public void doubleEdgeBtnClick()
    {
        // display description
        _traitDescText.text = "+ 100 % damage\n Receive 20 % of damage as recoil";

    }

    public void rapidFireBtnClick()
    {
        // display description
        _traitDescText.text = "+ 30% fire rate\n- 15 % damage";

    }

    public void heavyBtnClick()
    {
        // display description
        _traitDescText.text = "+ 20% damage\n- 15 % fire rate\n- movespeed";

    }

    public void overClockBtnClick()
    {
        // display description
        _traitDescText.text = "+ 50% damage\n+ 40 % fire rate\n+ Projectile speed\nChance to temporarily disable weapon upon firing / Bar for being disabled";

    }



    // Need to Store 

    //Array 
    // Weapon 1
    // Bullet type
    // Bullet traits []


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

    // change this
    public void updateFunctionScreen()
    {
        _fcBulletTypeText.text = _weapons[_selectedWeap].bullet;
        _fcSubTypeText.text = _weapons[_selectedWeap].bulletSubType;
        _fcBaseDmgText.text = _weapons[_selectedWeap].baseDmg.ToString();
        _fcRpsText.text = _weapons[_selectedWeap].rps.ToString();
    }










}
