using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrerfab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    float startDelay = 2;
    float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        Instantiate(obstaclePrerfab, spawnPos, obstaclePrerfab.transform.rotation);
    }
}

