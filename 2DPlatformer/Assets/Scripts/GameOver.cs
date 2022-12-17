using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text restartQuitText;

    private void Update()
    {
        if (gameOverText.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1f;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0);
                Cursor.visible = true;
                Time.timeScale = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            AudioManager.PlaySound("Death");
            AudioManager.PlaySound("Game Over");
            Destroy(other.gameObject);
            gameOverText.gameObject.SetActive(true);
            restartQuitText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
