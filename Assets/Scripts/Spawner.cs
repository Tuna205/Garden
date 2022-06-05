using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> collectablePrefabs;

    public float speed = 1;
    public float spawnInterval = 2;
    public float spawnIntervalDecreaseEvery10Waves = 0.2f;
    public float maxSpawnInterval = 0.8f;

    private readonly List<Vector3> finalPositions = new()
    {
        new Vector3(3, 4, 0), new Vector3(-3, 4, 0), new Vector3(3, -4, 0), new Vector3(-3, -4, 0),
        new Vector3(8, 2.5f, 0), new Vector3(-8, 2.5f, 0), new Vector3(8, -2.5f, 0), new Vector3(-8, -2.5f, 0)
    };

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (!UDPReceiver.hasData)
            {
                yield return new WaitUntil((() => UDPReceiver.hasData));
            }
            else
            {
                SpawnWave();
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    void SpawnWave()
    {
        int count = Random.value < 0.33 ? 2 : 1;
        
        for (int i = 0; i < count; i++)
        {
            GameObject collectablePrefab = collectablePrefabs[Random.Range(0, collectablePrefabs.Count)];
            Collectable collectible = Instantiate(collectablePrefab, this.transform).GetComponent<Collectable>();
            Vector3 direction = finalPositions[Random.Range(0, finalPositions.Count)] - this.transform.position;
            collectible.Initialize(direction, speed);
        }

        currentWave++;
        
        if (currentWave % 10 == 0)
        {
            spawnInterval = Math.Max(maxSpawnInterval, spawnInterval - spawnIntervalDecreaseEvery10Waves);
        }
    }
}
