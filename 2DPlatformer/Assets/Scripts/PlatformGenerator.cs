using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private float levelWidth = 3f;
    [SerializeField] private int numOfPlatforms;
    [SerializeField] private float minY = .2f;
    [SerializeField] private float maxY = 1.5f;
    private Vector3 spawnPosition = new Vector3(0, 0, 0);
    private Transform platformHolder = null;
    private GameObject player = null;
    private Vector3 referencePositionToSpawnNextPlatform = new Vector3(0, 0, 0);
    private Transform thisGameObjectTransform;

    void Start()
    {
        Cursor.visible = false;
        GetOtherComponents();
        GetStartingPlatforms();
    }

    void Update()
    {
        SpawnPlatforms();
    }

    private void GetOtherComponents()
    {
        platformHolder = GameObject.Find("PlatformHolder").transform;

        if (platformHolder == null)
        {
            Debug.LogError("Script: PlatformGenerator.cs - platformHolder is null");
        }

        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Script: PlatformGenerator.cs - player is null");
        }

        thisGameObjectTransform = GetComponent<Transform>();
        if (thisGameObjectTransform == null)
        {
            Debug.LogError("Script: PlatformGenerator.cs -> thisGameObjectTransform is null");
        }
    }

    private void GetStartingPlatforms()
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            InstantiatePlatofrmAtSpawnPosition();
        }
    }

    private void InstantiatePlatofrmAtSpawnPosition()
    {
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);

        thisGameObjectTransform.position = spawnPosition;

        Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], thisGameObjectTransform.position, Quaternion.identity, platformHolder);
    }

    private void SpawnPlatforms()
    {
        if (player != null && (player.transform.position.y - referencePositionToSpawnNextPlatform.y) > 1)
        {
            referencePositionToSpawnNextPlatform = player.transform.position;
            InstantiatePlatofrmAtSpawnPosition();
        }
    }
}