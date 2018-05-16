using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PeopleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject[] PersonTypes;

    public float minSpawnTime = 4f;
    public float maxSpawnTime = 8f;

    private bool stop = false;

    private void Start()
    {
        StartCoroutine(SpawnPeople());
    }

    IEnumerator SpawnPeople()
    {
        while (stop == false)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Instantiate(PersonTypes[Random.Range(0, PersonTypes.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform);
        }
    }

    public void Stop()
    {
        stop = true;
    }
}