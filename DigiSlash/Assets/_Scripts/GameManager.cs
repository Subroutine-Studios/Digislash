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
    public SpawnManager _spawnManager;

    [SerializeField]
    private bool _isGameOver = false;

    private int _enemiesLeft = 0;

    [SerializeField]
    public bool isPlayerSuccessful = true; // bool variable to check if player won the wave

    private Scene _currentScene;
    // insert UI Manager
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tracks number of enemies left on the field
        _enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // tracks player HP when it's not game over
        if (_player.health <= 0 && !_isGameOver)
        {
            // game ends
            _isGameOver = true;
            GameOverSequence();
        }

        // tracks fort HP when it's not game over
        else if (_fort._leaks <= 0 && !_isGameOver)
        {
            // game ends
            _isGameOver = true;
            GameOverSequence();
        }

        // tracks if the player has killed all enemies during a wave
        else if (_spawnManager.doneSpawning && _enemiesLeft <= 0 && !isPlayerSuccessful)
        {
            Debug.Log("SUCESS");
            _player._canShoot = false;
            _spawnManager.currentWave++;
            isPlayerSuccessful = true;
        }


        if (Input.GetKeyDown(KeyCode.X) && _isGameOver == true)
        {
            RestartLevel(); // restart current level
        }



    }

    void RestartLevel() // player restarts level if they are dead
    {
        int buildIndex = _currentScene.buildIndex;

        if (buildIndex != 6) // checks if level is not Level 3
            SceneManager.LoadScene(_currentScene.name);
        else
            SceneManager.LoadScene(5); // return to build phase
    }

    public void StartWave()
    {
        //We can make the player or fort heal a bit
        //Play sounds to indicte start of wave
        //We can even display "Wave 1" on UI
        //_uiManager.waveText.text = "Wave " + _spawnManager.currentWave;
        //_uiManager.waveText.gameObject.SetActive(true);


        //Spawn enemies
        _player._canShoot = true;
        _spawnManager.doneSpawning = false;
        _spawnManager.SpawnEnemies();

        isPlayerSuccessful = false;
    }

    void  GameOverSequence()
    {
        _player._canShoot = false;
        _isGameOver = true;
        _spawnManager.doneSpawning = true;
        _uiManager.gameOverTxt.gameObject.SetActive(true);
        _uiManager.restartLvlTxt.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _uiManager.gameOverTxt.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _uiManager.gameOverTxt.text = "";
            yield return new WaitForSeconds(0.5f);

        }
    }
}
