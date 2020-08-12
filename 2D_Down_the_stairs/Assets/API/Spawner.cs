using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float spawnTime;
    private float countTime;
    private Vector3 spawnPosition;

    void Start()
    {
        
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.1f, 3.1f);

        if(countTime>=spawnTime)
        {
            CreatePlatform();
            countTime = 0;
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0, platforms.Count);
        int spikeNum = 0;
        if (index == 5) spikeNum ++;
        if(spikeNum>1)
        {
            spikeNum = 0;
            countTime = spawnTime;
            return;
        }
        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);

    }
    void Update()
    {
        SpawnPlatform();
    }
}
