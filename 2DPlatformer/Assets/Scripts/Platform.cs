using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] diamonds;
   
    void Start()
    {
        spawnDiamonds();
    }

    private void spawnDiamonds()
    {
        if (Random.Range(1, 4) == 1)
        {
            Instantiate(diamonds[Random.Range(0, 10)], this.gameObject.transform.GetChild(0).position, Quaternion.identity);
        }
    }
}
