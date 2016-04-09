using UnityEngine;
using System.Collections;

public class InstantiateSatellites : MonoBehaviour {

    public GameObject SatellitePrefab;

    // Use this for initialization
    void Start () {

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPointTop");
        int idx = Random.Range(0, spawnPoints.Length);
        GameObject randomSpawnPoint = spawnPoints[idx];
        Instantiate(SatellitePrefab, randomSpawnPoint.transform.position, Quaternion.identity);

        GameObject[] spawnPoints2 = GameObject.FindGameObjectsWithTag("SpawnPointBottom");
        int idx2 = Random.Range(0, spawnPoints2.Length);
        GameObject randomSpawnPoint2 = spawnPoints2[idx2];
        Instantiate(SatellitePrefab, randomSpawnPoint2.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
