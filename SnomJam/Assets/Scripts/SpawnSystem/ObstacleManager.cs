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

    public float debugRad = 1f;

    [SerializeField] private List<GameObject> prefabsToSpawn;
    [SerializeField] private List<GameObject> blockadePositions;
    [SerializeField] private List<GameObject> lanes;

    [SerializeField] private GameObject blockadePrefab;
    [SerializeField] private Transform obstacleLane;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LaneManager laneManager;
    [SerializeField] private Menu menu;

    [SerializeField] private float offSetForBlockade;
    [SerializeField] private float timeInterval;
    [SerializeField] private float timer = 0f;
    
    private void Awake()
    {
        SpawnObstacles();
    }

    private void Start()
    {
        RoundOutToLanes();
    }

    private void Update()
    {
        if (!gameManager.isGameOver && gameManager.gameStarted)
        {
            timer += Time.deltaTime;
            if (timer > timeInterval)
            {
                timer = 0;
                SpawnBlockades();
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var p in points)
        {
            Gizmos.DrawSphere(p, debugRad);
        }
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

    private void SpawnObstacles()
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

    private void SpawnBlockades()
    {
        GameObject spawnedBlockade = Instantiate(blockadePrefab);
        GameObject player = GameObject.FindWithTag("Player");
        int randomRange = Random.Range(0, blockadePositions.Count);
        spawnedBlockade.transform.position = new Vector3(player.transform.position.x + offSetForBlockade, blockadePositions.ElementAt(randomRange).transform.position.y, 1f);
        spawnedBlockade.transform.SetParent(obstacleLane.transform, true);
    }
    
    
    
    
}
