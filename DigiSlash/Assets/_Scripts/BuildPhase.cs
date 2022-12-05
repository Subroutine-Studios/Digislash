using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject _equipTraitBtn;


    [SerializeField]
    private Text _traitEquippedText;


    [SerializeField]
    private Text _bulletText;



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
    [SerializeField]
    private Text _fcTraitText;

    // trait description content
    [SerializeField]
    private Text _traitDescText;

    private static int _selectedTrait = -1; // 0 = multishot, 1 = warped, 2 = rapidfire

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

        Debug.Log("Build phase start: " + _weapons[_selectedWeap].bullet + " selected weapon : " + _selectedWeap);
    }




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

    public void startLevelThree()
    {
        SceneManager.LoadScene(6);
    }


    // On Click Methods for Bullet type selection


    public void bulletBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "String bullet_type = Bullet";
        _fcSubTypeText.text = "String bullet_subType = Shrapnel, Tracer";
        _fcBaseDmgText.text = "int base_Dmg = 12";
        _fcRpsText.text = "int rps = 10 ";

        _bulletText.text = "class Bullet :";

        updateWeaponList("Bullet", "Shrapnel", "Tracer", 8, 8, 12, 12, 10, 10, _prefabA, _prefabB);



        //  Debug.Log("BUTTON CLICK : Values of array weapon : "+ " weap # " + _selectedWeap + _weapons[_selectedWeap].bullet);


    }

    public void rocketBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "String bullet_type = Rocket";
        _fcSubTypeText.text = "String bullet_subType = Nuclear, Napalm";
        _fcBaseDmgText.text = "int base_Dmg = 60";
        _fcRpsText.text = "int rps = 1";

        _bulletText.text = "class Rocket :";

        updateWeaponList("Rocket", "Nuclear", "Napalm", 8, 8, 60, 60, 1, 1, _prefabA, _prefabB);
    }

    public void stickyBtnClick()
    {
        // update function content
        _fcBulletTypeText.text = "String bullet_type = Sticky";
        _fcSubTypeText.text = "String bullet_subType = Plague, Singularity";
        _fcBaseDmgText.text = "int base_Dmg = 30";
        _fcRpsText.text = "int rps = 4";

        _bulletText.text = "class Sticky :";

        updateWeaponList("Sticky", "Plague", "Singularity", 8, 8, 30, 30, 4, 4, _prefabA, _prefabB);
    }

    // On Click Methods for Traits

    public void multiShotBtnClick()
    {
        _selectedTrait = 0;
        // display description
        _traitDescText.text = "+ 4 Projectile count (shoots 5 projectiles with a spread at a time)\n- Range";

    }

    public void warpedBtnClick()
    {
        _selectedTrait = 1;
        // display description
        _traitDescText.text = " > Bullets spawn from crosshair\n > 50 % fire rate";

    }

    public void rapidFireBtnClick()
    {
        _selectedTrait = 2;
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

    public void equipTraitBtnClick()
    {
  
        // check currently selected trait
        if (_selectedTrait == 0) // multishot
        {
            Debug.Log("Selected trait 0 ");
            // update trait equipped text box
            _traitEquippedText.text = "Trait equipped: Multishot";
            // update function
            _fcTraitText.text = "String trait = \"Multishot\"\nprint(\"+ 4 Projectile count (shoots 5 projectiles with a spread at a time), - Range\");\n\nreturn dmg;";

            Player._multiShot = true;
        } 
        if(_selectedTrait == 1) // warped
        {
            Debug.Log("Selected trait 1 ");
            // update trait equipped text box
            _traitEquippedText.text = "Trait equipped: Warped";
            // update function
            _fcTraitText.text = "String trait = \"Warped\"\nprint(\"Bullets spawn from crosshair, 50 % fire rate\");\n\nreturn dmg;";

            Player._warped = true;
        }
        
        if(_selectedTrait == 2) // rapidfire
        {
            Debug.Log("Selected trait 2 ");
            // update trait equipped text box
            _traitEquippedText.text = "Trait equipped: Rapid-fire";
            // update function
            _fcTraitText.text = "String trait = \"Rapid-fire\"\nprint(\"+ 30% fire rate , -15 % damage\");\n\nreturn dmg;";

            Player._rapidFire = true;
        }


        

    }

    public void updateFunctionScreen()
    {
        
        _bulletText.text = "class " + _weapons[_selectedWeap].bullet;

        _fcBulletTypeText.text = "String bullet_type = " + _weapons[_selectedWeap].bullet;
        _fcSubTypeText.text = "String bullet_subType = " + _weapons[_selectedWeap].bulletSubTypeA;
        _fcBaseDmgText.text = "int base_Dmg = " + _weapons[_selectedWeap].baseDmgA.ToString();
        _fcRpsText.text = "int rps = " + _weapons[_selectedWeap].rpsA.ToString();

     
        
    }








}
