using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    private GameObject player = null;
    [SerializeField] private GameObject[] backgroundPrefab;
    private Vector3 nextPositionToSpawnBackground = new Vector3(0, 30, 0);
    private bool canChangeBackground = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("Script: BackgroundGenerator.cs - player is null");
        }
    }


    void Update()
    {
        BackgroundSpawner();
    }

    private void BackgroundSpawner()
    {
        CanChangeBackground();
        if (player != null && canChangeBackground && (Mathf.RoundToInt(player.transform.position.y) >= 15) && (Mathf.RoundToInt(player.transform.position.y) % 10 == 5))
        {
            canChangeBackground = false;
            backgroundPrefab[0].transform.position = nextPositionToSpawnBackground;
            nextPositionToSpawnBackground += new Vector3(0, 10, 0);
            ChangeBackgroundOrder(backgroundPrefab);
        }
    }

    private void ChangeBackgroundOrder(GameObject[] backgroundPrefab)
    {
        GameObject temp;

        temp = backgroundPrefab[0];
        backgroundPrefab[0] = backgroundPrefab[1];
        backgroundPrefab[1] = backgroundPrefab[2];
        backgroundPrefab[2] = backgroundPrefab[3];
        backgroundPrefab[3] = temp;
    }

    private void CanChangeBackground()
    {
        if (player != null && (Mathf.RoundToInt(player.transform.position.y) >= 15) && (Mathf.RoundToInt(player.transform.position.y) % 10 == 0))
            canChangeBackground = true;
    }
}
