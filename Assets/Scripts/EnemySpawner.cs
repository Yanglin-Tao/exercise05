using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemiesToSpawn;
    public float spawnDistance = 10f;
    private Transform playerTransform; 
    private bool toSpawn = false;

    private Transform spawnPoint;
    public Transform spawnPoint1;
    public Transform spawnPoint2;


    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine("SpawnRoutine");
    }

    void Update()
    {
        int num = PublicVars.GetNewFlagCount();
        int existing_enemies = GameObject.FindGameObjectsWithTag("Ghoul").Length / 2;
        // print(existing_enemies);

        if (num == 2 && existing_enemies < 1){
            enemiesToSpawn = 1;
            toSpawn = true;
        };
        if (num >= 3 && num <= 6 && existing_enemies < 2){
            enemiesToSpawn = 2;
            toSpawn = true;
        };
        if (num >= 7 && existing_enemies < 3){
            enemiesToSpawn = 3;
            toSpawn = true;
        };

    }

    IEnumerator SpawnRoutine(){
        while (true) {
            if (toSpawn) {
                SpawnEnemies();
            }
            yield return new WaitForSeconds(.4f);
        }
    }

    void SpawnEnemies(){
        int existing_enemies = GameObject.FindGameObjectsWithTag("Ghoul").Length / 2;
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Floor 1") {
            spawnPoint = spawnPoint1;
        }
        if (currentScene.name == "Floor 2") {
            spawnPoint = spawnPoint2;
        }
        
        enemiesToSpawn = enemiesToSpawn - existing_enemies;

        for (int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
        toSpawn = false;
    }
}
