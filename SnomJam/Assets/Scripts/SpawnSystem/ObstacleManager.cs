using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
   
    public float radius = 1;
    public Vector2 regionSize = Vector2.one;
    public int rejectionSamples = 30;

    List<Vector2> points;

    [SerializeField] private List<GameObject> prefabsToSpawn;
    [SerializeField] private List<GameObject> lanes;

    private void Awake()
    {
        spawnObstacles();
    }

    private void Start()
    {
        RoundOutToLanes();
    }

    void OnValidate() {
        points = PoissonDistributionGenerator.GeneratePoints(radius, regionSize, rejectionSamples);
    }

    private void RoundOutToLanes()
    {
        List<float> yTracker = new List<float>();
        foreach (var lane in lanes)
        {
            yTracker.Add(lane.transform.position.y);
        }
        Transform[] childList = GetComponentsInChildren<Transform>();
        foreach (var child in childList)
        {
            float closestPosY = 
                yTracker.Aggregate((x,y) => Math.Abs(x-child.transform.position.y) < Math.Abs(y-child.transform.position.y) ? x : y);
            child.transform.position = new Vector3(child.transform.position.x, closestPosY, 1);
            Vector3 toLocalSpace = transform.InverseTransformPoint(child.transform.position);
            child.transform.localPosition = new Vector3(toLocalSpace.x, toLocalSpace.y, 1);
        }
        
    }

    private void spawnObstacles()
    {
        if (points != null) {
            foreach (Vector2 point in points)
            {
                int randomIndex = Random.Range(0, prefabsToSpawn.Count);
                GameObject randomObstacle = Instantiate(prefabsToSpawn.ElementAt(randomIndex));
                randomObstacle.transform.position = new Vector3(point.x, point.y, 1);
                randomObstacle.transform.parent = gameObject.transform;

            }
        }
    }
    
    
    
    
}
