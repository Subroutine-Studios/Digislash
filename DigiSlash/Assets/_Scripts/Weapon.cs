using UnityEngine;

[SerializeField]
public class Weapon : MonoBehaviour
{
    public string bullet;
    public string bulletSubType;


    public float shootDelay;
    public float bulletForce;

    public float baseDmg;
    public float rps;

    public GameObject prefab;



    public Weapon(string bullet, string bulletSubType, float baseDmg, float rps)
    {
        this.bullet = bullet;
        this.bulletSubType = bulletSubType;
        this.baseDmg = baseDmg;
        this.rps = rps;
    }

  

}

