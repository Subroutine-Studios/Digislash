using UnityEngine;

[SerializeField]
public class Weapon : MonoBehaviour
{
    public string bullet;
    public string bulletSubTypeA;
    public string bulletSubTypeB;

    public float bulletForceA;
    public float bulletForceB;

    public float baseDmgA;
    public float baseDmgB;

    public float rpsA;
    public float rpsB;

    public GameObject prefabA;
    public GameObject prefabB;

    public Weapon(string bullet, string bulletSubTypeA, string bulletSubTypeB, float bulletForceA, float bulletForceB, float baseDmgA, float baseDmgB, float rpsA, float rpsB, GameObject prefabA, GameObject prefabB)
    {
        this.bullet = bullet;
        this.bulletSubTypeA = bulletSubTypeA;
        this.bulletSubTypeB = bulletSubTypeB;
        this.bulletForceA = bulletForceA;
        this.bulletForceB = bulletForceB;
        this.baseDmgA = baseDmgA;
        this.baseDmgB = baseDmgB;
        this.rpsA = rpsA;
        this.rpsB = rpsB;
        this.prefabA = prefabA;
        this.prefabB = prefabB;
    }
}

