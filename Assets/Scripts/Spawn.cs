using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject brickPrefab;
    IEnumerator Start()
    {
        for (int i = 0; i < 2000; i++) {
            Vector3 spawnPos = new Vector3(Random.Range(-5, 5), 1.8f, Random.Range(-5, 5));
            Instantiate(brickPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.4f);
        }
    }
}
