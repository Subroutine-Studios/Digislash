using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private SpawnManager _spawnManager;
    // insert UI Manager

    public int currentWave = 1;
    public int enemiesToSpawn = 14;
    public int enemiesLeft = 0;
    public bool startOfWave;

    // Start is called before the first frame update
    void Start()
    {
        // get component for UI Manager

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft <= 0 && startOfWave != true)
        {
            enemiesLeft = 0;
            EndWave();
        }
    }

    public void EndWave()
    {

    }

    public void StartWave()
    {
        startOfWave = true;
        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator EndWaveRoutine()
    {
        startOfWave = true;
        currentWave++;
        yield return new WaitForSeconds(3f);
        StartWave();
    }

    IEnumerator StartWaveRoutine()
    {
        // insert wave n text
        yield return new WaitForSeconds(3f);

        if (enemiesLeft != enemiesToSpawn)
        {
            _spawnManager.StartSpawning();
        }
    }
}
