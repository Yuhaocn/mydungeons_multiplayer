using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class WaveSpawner : NetworkBehaviour
{
    public Wave[] waves;

    public Wave currentWave;
    private NetworkObject m_SpawnedNetworkObject;

    [SerializeField]
    private Transform[] spawnpoints;

    public float timeBtwnSpawns;
    private int i = 0;
    private GameObject m_PrefabInstance;
    private bool stopSpawning = false;

    private void Awake()
    {

        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }

    private void Update()
    {enabled = IsServer;            
            if (!enabled)
            {
                return;
            }
        if(stopSpawning)
        {
            return;
        }

        if (Time.time >= timeBtwnSpawns)
        {
            SpawnWave();
            IncWave();

            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnpoints.Length);

            m_PrefabInstance =Instantiate(currentWave.EnemiesInWave[num], spawnpoints[num2].position, spawnpoints[num2].rotation);
            m_SpawnedNetworkObject =m_PrefabInstance.GetComponent<NetworkObject>();
            m_SpawnedNetworkObject.Spawn();
        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
}
