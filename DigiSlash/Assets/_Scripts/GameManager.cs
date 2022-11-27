using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Fort _fort;
    private int round = 1;
    private int roundMax = 5;
    [SerializeField]
    private bool _isGameOver = false;
    [SerializeField]
    private bool _isPlayerSuccessful = false; // bool variable to check if player won all waves

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.health <= 0)
        {
            // game ends
        }

        if (_fort._leaks <= 0)
        {
            // game ends
        }



        else if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            
        }


    }

    void GameOver()
    {
        _isGameOver = true;
    }
}
