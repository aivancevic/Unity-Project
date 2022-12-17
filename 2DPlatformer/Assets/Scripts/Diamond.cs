using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private int numOfPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            AudioManager.PlaySound("Diamond Collect");
            UIManager.instance.AddScore(numOfPoints);
            Destroy(this.gameObject);
        }
    }
}