using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    public static MainMenuManager instance;


    private void Awake()
    {
        instance = this;

        volumeSlider.value = PlayerPrefs.GetFloat("MainVolume");
        audioMixer.SetFloat("master", PlayerPrefs.GetFloat("MainVolume"));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Script: MainMenuManager\t Quit game");
    }

    public void ResumeGame()
    {
        UIManager.instance.ToggleEscapeMenu();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
