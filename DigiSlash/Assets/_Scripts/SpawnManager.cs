using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private WaveManager _waveManager;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }


    IEnumerator SpawnEnemyRoutine()
    {
        int enemiesSpawned = 0;

        yield return new WaitForSeconds(3.0f); // wait 3 seconds before spawning

        // while <???>, keep spawning enemies
        while (_stopSpawning == false && _waveManager.currentWave < 4)
        {
            if (enemiesSpawned != _waveManager.enemiesToSpawn)
            {
                switch (_waveManager.currentWave)
                {
                    // Wave 1
                    case 1:
                        Vector3 posToSpawn = new Vector3(Random.Range(-2f, 2f), -6, 0); // position to spawn (x,y,z)
                        GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
                        newEnemy.transform.parent = _enemyContainer.transform;

                        _waveManager.enemiesLeft++;
                        enemiesSpawned++;
                        break;

                    // Wave 2
                    case 2:
                        _waveManager.enemiesLeft++;
                        enemiesSpawned++;
                        break;

                    // Wave 3
                    case 3:
                        _waveManager.enemiesLeft++;
                        enemiesSpawned++;
                        break;
                }
            }
            else
            {
                _waveManager.startOfWave = false;
                enemiesSpawned = 0;
                _stopSpawning = true;
            }
        }
        
            yield return new WaitForSeconds(5.0f);
<<<<<<< Updated upstream
=======

            // will never get here
>>>>>>> Stashed changes
        }






}
