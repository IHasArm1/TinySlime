using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaggleMenu : MonoBehaviour
{

    public GameObject TestSlime;
    public GameObject TestSlimeCoin;

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

    public void SpawnSlimeCoin()
    {
        Instantiate(TestSlimeCoin, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -5), Quaternion.identity);
    }

}
