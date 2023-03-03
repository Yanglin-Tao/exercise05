using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName = "Level1";
    
    private void OnTriggerEnter(Collider other){
        print("Hi");
        if (other.CompareTag("Player")){
            SceneManager.LoadScene(levelName);
        }
    }
}
