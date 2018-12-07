using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float zSpawnInterval = 12.5f;
    public static GameManager instance;

    public float lastZ, defY = -30, xPos, defX;
    public float obstacleSpeed;

    float spawnTime, spawnInterval = 2.5f;

	public float multiplier;
    public int spawnWidth;
	// Use this for initialization
	void Start ()
    {
        instance = this;
        for (int i = 0; i < 20; i++)
        {
            
            SpawnNewObstacle();
            lastZ += zSpawnInterval;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(spawnTime < Time.time)
        {
            spawnTime += spawnInterval;
			if(spawnInterval > 0.1f)
			{
				spawnInterval -= 0.01f;
			}
            SpawnNewObstacle();
        }
	}

    public void SpawnNewObstacle()
    {
        xPos = defX;
        for (int i = 0; i < spawnWidth; i++)
        {
            xPos += 19.0f;
            ObstaclePool.instance.SpawnObstacle(new Vector3(xPos, defY, lastZ), -obstacleSpeed);
        }
		multiplier += 0.05f;
        //lastZ += zSpawnInterval;
    }
}
