using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Attach this script to an empty object in your scene
 If a player already exists in the scene, a new player will not be created
 To add spawn points to the spawner, add elements to "Player Spawns"
   "Previous Level" is the level that we are loading from
   "Spawn Point" is point where the player will spawn
   If your scene does not have a previously loaded scene, leave "Previous Level" empty
 Use the Camera offsets to place the camera above the player upon spawn
*/
public class PlayerSpawner : MonoBehaviour
{
    // Player spawn variables
    public GameObject playerPrefab;
    public PlayerSpawn[] playerSpawns;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    public AudioClip walkEffect;
    void Awake() {
        // Check if there is already a player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null) {
            print("Player exists");
            return; 
        }

        // Check each potential spawnpoint
        foreach(PlayerSpawn spawn in playerSpawns) {
            // Check which spawn point matches the previous scene
            if(spawn.previousLevel == PublicVars.previousScene) {
                // Create the player & position the camera
                player = Instantiate(playerPrefab, spawn.spawnPoint.position, Quaternion.identity);
                Camera mainCam = Camera.main;
                mainCam.transform.position = new Vector3(
                    player.transform.position.x,
                    player.transform.position.y + cameraOffsetY,
                    player.transform.position.z + cameraOffsetZ
                );

                player.GetComponentInChildren<WalkingSound>().walkingEffect = walkEffect;

                return;
            }
        }
    }
}

[System.Serializable]
public class PlayerSpawn
{
    public string previousLevel;
    public Transform spawnPoint;
}