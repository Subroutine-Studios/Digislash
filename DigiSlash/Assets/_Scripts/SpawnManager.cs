using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Waves
    {
        public int numTrespassers = 0;
        public int numLegions = 0;
        public int numWorms = 0;
        public float spawnDelay = 3f;
    }

    [SerializeField]
    private Waves[] _waves;


    [SerializeField]
    private GameObject _enemyTrespasser;
    [SerializeField]
    private GameObject _enemyLegion;
    [SerializeField]
    private GameObject _enemyWorm;
    [SerializeField]
    private GameObject _enemyContainer;

    public int currentWave = 0;

    public bool doneSpawning = true;


    public int enemiesLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Delele once game manager is good
        StartCoroutine(SpawnEnemyRoutine());
    }

    private void Update()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }


    public IEnumerator SpawnEnemyRoutine()
    {
        doneSpawning = false;
        int numTrespassers = _waves[currentWave].numTrespassers;
        int numLegions = _waves[currentWave].numLegions;
        int numWorms = _waves[currentWave].numWorms;

        //Add different enemies into the list
        List<int> enemiesToBeSpawned = new List<int>();

        for(int i = 0; i < numTrespassers; i++)
        {
            enemiesToBeSpawned.Add(0);
        }

        for (int i = 0; i < numLegions; i++)
        {
            enemiesToBeSpawned.Add(1);
        }

        for (int i = 0; i < numWorms; i++)
        {
            enemiesToBeSpawned.Add(2);
        }

        GameObject enemy;
        Debug.Log(enemiesToBeSpawned);

        // while <???>, keep spawning enemies
        while (enemiesToBeSpawned.Count > 0)
        {
            int randomIndex = Random.Range(0, enemiesToBeSpawned.Count);
            
            switch (enemiesToBeSpawned[randomIndex])
            {
                case 0: enemy = _enemyTrespasser; break;
                case 1: enemy = _enemyLegion; break;
                case 2: enemy = _enemyWorm; break;
                default: enemy = _enemyTrespasser; break;
            }

            enemiesToBeSpawned.RemoveAt(randomIndex);

            Vector3 posToSpawn = new Vector3(Random.Range(-2f, 2f), -6, 0); // position to spawn (x,y,z)
            GameObject newEnemy = Instantiate(enemy, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_waves[currentWave].spawnDelay); // wait n seconds before spawning

        }
        doneSpawning = true;

    }






}