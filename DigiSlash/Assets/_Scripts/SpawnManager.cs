using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Waves
    {
        public int numTrespassers = 0;
        public int numLegions = 0;
        public int numWorms = 0;
        public int numPhalanx = 0;
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
    private GameObject _enemyPhalanx;
    [SerializeField]
    private GameObject _enemyContainer;

    public int currentWave = 0;

    public bool doneSpawning = true;

    [SerializeField]
    private GameObject _waveAnnoucement;
    [SerializeField]
    private TextMeshProUGUI _waveText;


    

    // Start is called before the first frame update
    void Start()
    {
        //Delele once game manager is set, game manager should call this
        //StartCoroutine(SpawnEnemyRoutine());
    }

    private void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    public IEnumerator SpawnEnemyRoutine()
    {
        _waveText.text = "Wave " + (currentWave+1).ToString();
        _waveAnnoucement.SetActive(true);
        yield return new WaitForSeconds(2f);
        _waveAnnoucement.SetActive(false);

        doneSpawning = false;
        int numTrespassers = _waves[currentWave].numTrespassers;
        int numLegions = _waves[currentWave].numLegions;
        int numWorms = _waves[currentWave].numWorms;
        int numPhalanx = _waves[currentWave].numPhalanx;

        Debug.Log("tres: " + _waves[currentWave].numTrespassers);
        Debug.Log("leg: " + _waves[currentWave].numLegions);
        Debug.Log("worm: " + _waves[currentWave].numWorms);
        Debug.Log("phalanx: " + _waves[currentWave].numPhalanx);

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

        for (int i = 0; i < numPhalanx; i++)
        {
            enemiesToBeSpawned.Add(3);
        }

        GameObject enemy;

        for(int i = 0; i< enemiesToBeSpawned.Count; i++)
        {
            Debug.Log(enemiesToBeSpawned[i]);
        }
        //Debug.Log(enemiesToBeSpawned);

        // while <???>, keep spawning enemies
        while (enemiesToBeSpawned.Count > 0)
        {
            int randomIndex = Random.Range(0, enemiesToBeSpawned.Count);
            
            switch (enemiesToBeSpawned[randomIndex])
            {
                case 0: enemy = _enemyTrespasser; break;
                case 1: enemy = _enemyLegion; break;
                case 2: enemy = _enemyWorm; break;
                case 3: enemy = _enemyPhalanx; break;
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