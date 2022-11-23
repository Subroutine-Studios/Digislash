using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private int round = 1;
    private int roundMax = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            // game ends
        }

        else if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            
        }


    }
}
