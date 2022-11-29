using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Fort _fort;

    [SerializeField]
    private bool _isGameOver = false;
    [SerializeField]

    private bool _isPlayerSuccessful = false; // bool variable to check if player won all waves

    private Scene _currentScene;
    // insert UI Manager

    // Start is called before the first frame update
    void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        // tracks player HP
        if (_player.health <= 0)
        {
            // game ends
            _isGameOver = true;
            StartCoroutine(GameOverSequence());
        }

        // tracks fort HP
        if (_fort._leaks <= 0)
        {
            // game ends
            _isGameOver = true;
            StartCoroutine(GameOverSequence());
        }
    }

    void RestartLevel() // player restarts level if they are dead
    {
        SceneManager.LoadScene(_currentScene.name);
    }

    void StartLevelTwo()
    {
        //SceneManager.LoadScene(//insert level 2);
    }
    void StartLevelThree()
    {
        //SceneManager.LoadScene(//insert level 3);
    }

    IEnumerator GameOverSequence()
    {
        // set GameOver text to true

        yield return new WaitForSeconds(5.0f);
    }
}
