using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    //Spawn with dragging gameobjects


    // Inspector Settings

    [Header("Go?")]
    public Direction direction;
    public enum Direction { Left, Right, Forward, Backward }

    
    [SerializeField] float speed = 5f;
    [SerializeField] float periodDistance = 15f;
    [SerializeField] float destroyDistance = 110f;

    [SerializeField] private GameObject CloneObjectParent;
    [SerializeField] private GameObject[] Obstacles;
    
    // Inspector Settings


    private int obstaclesLength;
    private GameObject spawnedObstacle;


    void Start()
    {
        SpawnObstacle();
    }


    void Update()
    {
        float distance = Vector3.Distance(spawnedObstacle.transform.position, transform.position);

        if (distance > periodDistance)
        {
            SpawnObstacle();
        }

    }


    void SpawnObstacle()
    {
        obstaclesLength = Obstacles.Length;

        int randomObstacle = Random.Range(0, obstaclesLength);
        

        spawnedObstacle = Instantiate(Obstacles[randomObstacle], transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = CloneObjectParent.transform;
        spawnedObstacle.AddComponent<ObstacleManager>();

        spawnedObstacle.GetComponent<ObstacleManager>().obstacleClass = ObstacleManager.Class.spawnedObstacle;

        switch (spawnedObstacle.tag)
        {
            case "Human":
                //spawnedObstacle.GetComponent<Animator>().SetBool("walking", true);      // walking animation is enabled
                int randomHuman = Random.Range(0, spawnedObstacle.transform.childCount - 1);
                spawnedObstacle.transform.GetChild(randomHuman).gameObject.SetActive(true);
                spawnedObstacle.gameObject.SetActive(true);
                spawnedObstacle.tag = "HumanClone";
                break;

            case "Car":
                spawnedObstacle.tag = "CarClone";
                break;
        }
        
        

        switch (direction)
        {
            case Direction.Left:
                spawnedObstacle.transform.rotation = Quaternion.Euler(Obstacles[randomObstacle].transform.rotation.eulerAngles.x, -90, Obstacles[randomObstacle].transform.rotation.eulerAngles.z);
                spawnedObstacle.GetComponent<ObstacleManager>().obstacleDirection[0] = true;
                break;
            case Direction.Right:
                spawnedObstacle.transform.rotation = Quaternion.Euler(Obstacles[randomObstacle].transform.rotation.eulerAngles.x, 90, Obstacles[randomObstacle].transform.rotation.eulerAngles.z);
                spawnedObstacle.GetComponent<ObstacleManager>().obstacleDirection[1] = true;
                break;
            case Direction.Forward:
                spawnedObstacle.transform.rotation = Quaternion.Euler(Obstacles[randomObstacle].transform.rotation.eulerAngles.x, 0, Obstacles[randomObstacle].transform.rotation.eulerAngles.z);
                spawnedObstacle.GetComponent<ObstacleManager>().obstacleDirection[2] = true;
                break;
            case Direction.Backward:
                spawnedObstacle.transform.rotation = Quaternion.Euler(Obstacles[randomObstacle].transform.rotation.eulerAngles.x, 180, Obstacles[randomObstacle].transform.rotation.eulerAngles.z);
                spawnedObstacle.GetComponent<ObstacleManager>().obstacleDirection[3] = true;
                break;
        }

        spawnedObstacle.GetComponent<ObstacleManager>().speed = speed;
        spawnedObstacle.GetComponent<ObstacleManager>().destroyDistance = destroyDistance;


    }




} 
 