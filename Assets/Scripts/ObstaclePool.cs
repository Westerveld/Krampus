using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public static ObstaclePool instance;
    public GameObject[] obstacle;

    public int amount;
   
    public List<GameObject> obstacles;
	// Use this for initialization
	void Awake ()
    {
        instance = this;
        obstacles = new List<GameObject>();

        for(int i = 0; i < amount; i++)
        {
            GameObject newObstacle = Instantiate(obstacle[Random.Range(0, obstacle.Length)]);

            newObstacle.transform.parent = transform;
            obstacles.Add(newObstacle);
            newObstacle.SetActive(false);

        }


	}
	

    public void SpawnObstacle(Vector3 pos, float speed)
    {
        foreach(GameObject o in obstacles)
        {
            if(!o.activeSelf)
            {
                o.transform.position = pos;
                o.GetComponent<ObstacleMover>().speed = speed;
                o.SetActive(true);
                break;
            }
        }
    }
    
}
