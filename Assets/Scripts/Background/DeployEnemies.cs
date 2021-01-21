using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemies : ScreenBounds
{
    public Object[] enemiesPrefabs;
    private int enemiesValue;
    private float Crono;
    private float respawnTime = 8f;

    void Start()
    {
        GetBackRenderer();
        GetBounds();

        SpawnEnemies();
    }



    void Update()
    {
        Crono += Time.deltaTime;

        if (Crono >= respawnTime)
        {
            SpawnEnemies();
            Crono = 0;
        }
    }



    public void SpawnEnemies()
    {
        Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)],new Vector2(-10, Random.Range(Bounds.y * -1.2f, 2.3f)),new Quaternion(0, 0, 0, 0));
    }
}
