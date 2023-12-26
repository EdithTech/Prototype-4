using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerUpPrefab;

    [SerializeField] int enemyCount;
    [SerializeField] int enemyWave = 1;

    float spwanRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        startEnemyWave(enemyWave);
    }

    void Update(){
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0){
            startEnemyWave(enemyWave);
        }
    }

    Vector3 genrateRandomPosition(){
        float spwanRangeX = Random.Range(-spwanRange, spwanRange);
        float spwanRangeZ = Random.Range(-spwanRange, spwanRange);
        Vector3 randomPos = new Vector3(spwanRangeX, 0f, spwanRangeZ);
        return randomPos;
    }

    void startEnemyWave(int Wave){
        for(int i=0; i<Wave; i++){
            Instantiate(enemyPrefab, genrateRandomPosition(), Quaternion.identity);
        }

        Instantiate(powerUpPrefab, genrateRandomPosition(), Quaternion.identity);
        enemyWave++;
    }
}
