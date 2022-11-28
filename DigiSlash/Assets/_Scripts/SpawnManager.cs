using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Waves
    {
        public int _enemiesToSpawn = 14;
        public float spawnDelay = 3f;
    }

    [SerializeField]
    private Waves[] _waves;


    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private bool _stopSpawning = true;

    public int currentWave = 0;


    public int enemiesLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private void Update()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }


    public IEnumerator SpawnEnemyRoutine()
    {
        int enemiesSpawned = 0;


        // while <???>, keep spawning enemies
        while (_stopSpawning == false && currentWave < 3)
        {
            if (enemiesSpawned != _waves[currentWave]._enemiesToSpawn)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-2f, 2f), -6, 0); // position to spawn (x,y,z)
                GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                enemiesSpawned++;
                yield return new WaitForSeconds(_waves[currentWave].spawnDelay); // wait n seconds before spawning
                       
            }
            else
            {
                _stopSpawning = true;
            }
        }
        
    }






}
