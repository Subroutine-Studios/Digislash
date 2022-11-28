using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildPhase : MonoBehaviour
{

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


    // On Click Methods for Bullet type selection


    public void bulletBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "INT";
        _fcSubTypeText.text = "Shrapnel, Tracer";
        _fcBaseDmgText.text = "12";
        _fcRpsText.text = "10";

    }

    public void rocketBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "FL";
        _fcSubTypeText.text = "Nuclear, Napalm";
        _fcBaseDmgText.text = "60";
        _fcRpsText.text = "1";

    }

    public void stickyBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "STR";
        _fcSubTypeText.text = "Plague, Singularity";
        _fcBaseDmgText.text = "30";
        _fcRpsText.text = "4";

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







    void Update ()
    {
        // check weapon number


    }

   

}
