using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaggleMenu : MonoBehaviour
{

    public GameObject TestSlime;

    public Vector2 minSpawnLoc, maxSpawnLoc;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSlime()
    {
        Instantiate(TestSlime, new Vector2(0, 0), Quaternion.identity);
    }
    public void SpawnSlimeRandomLoc()
    {

        float randX = Random.Range(minSpawnLoc.x, maxSpawnLoc.x);
        float randY = Random.Range(minSpawnLoc.y, maxSpawnLoc.y);


        Instantiate(TestSlime, new Vector2(randX, randY), Quaternion.identity);
    }

}
