using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;
    public List<ObstacleController> obstaclesToSpawn;
    public GameConfigurator config;


    // Start is called before the first frame update
    void Start()
    {
        InitObstacles();
        //StartCoroutine(SpawnRandomObstacles());
    }

    public void GenerateObstacles()
    {
        StartCoroutine(SpawnRandomObstacles());
    }

    public void StopGenerator()
    {
        StopAllCoroutines();
    }

    public void ResetGenerator()
    {
        foreach(ObstacleController obstacle in obstaclesToSpawn)
        {
            obstacle.gameObject.SetActive(false);
        }
    }

    void InitObstacles()
    {
        int index = 0;
        for(int i = 0; i< obstacles.Length * 3; i++)
        {
            GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            obstaclesToSpawn.Add(obj.GetComponent<ObstacleController>());
            
            index++;
            if (index.Equals(obstacles.Length))
            {
                index = 0;
            }
        }
    }

    IEnumerator SpawnRandomObstacles()
    {
        yield return new WaitForSeconds(Random.Range(config.minRangeObstacleGenerator, config.maxRangeObstacleGenerator));

        int index = Random.Range(0, obstaclesToSpawn.Count);

        while (true)
        {
            ObstacleController obstacle = obstaclesToSpawn[index];

            if (!obstacle.gameObject.activeInHierarchy)
            {
                obstaclesToSpawn[index].gameObject.SetActive(true);
                obstaclesToSpawn[index].transform.position = transform.position;
                break;
            }
            else
            {
                index = Random.Range(0, obstaclesToSpawn.Count);
            }
            
        }

        StartCoroutine(SpawnRandomObstacles());
    }
}
