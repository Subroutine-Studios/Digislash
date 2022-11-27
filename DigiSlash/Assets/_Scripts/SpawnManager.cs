using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }


    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f); // wait 3 seconds before spawning


        // while <???>, keep spawning enemies
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-2f, 2f), -6, 0); // position to spawn (x,y,z)
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }

        // will never get here
    }






}
