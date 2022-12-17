using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioClip collectDiamond, playerDeath, gameOver, mainTheme;
    [SerializeField] private static AudioSource source;
    [SerializeField] private AudioMixer audioMixer;
    private static bool audioManagerFirstTime = true;
    [SerializeField] private Slider volumeSlider;
    public static AudioManager instance;
    private Scene scene;
    string sceneName;


    private void Start()
    {
        audioMixer.SetFloat("master", PlayerPrefs.GetFloat("MainVolume"));
    }
    private void Awake()
    {
        instance = this;
        GetAudioClips();
        source = GetComponent<AudioSource>();

        if (source == null)
        {
            Debug.LogError("Script: AudioManager\t AudioSource is NULL");
        }

        volumeSlider.value = PlayerPrefs.GetFloat("MainVolume");

        if (audioManagerFirstTime)
        {
            DontDestroyOnLoad(this);
            source.clip = mainTheme;
            source.Play();
            audioManagerFirstTime = false;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    private void FixedUpdate()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        if (sceneName.Equals("MainMenu"))
        {
            source = GetComponent<AudioSource>();
        }
    }

    private void GetAudioClips()
    {
        collectDiamond = Resources.Load<AudioClip>("Diamond Collect");
        playerDeath = Resources.Load<AudioClip>("Death");
        gameOver = Resources.Load<AudioClip>("Game Over");
        mainTheme = Resources.Load<AudioClip>("Main Theme");
    }

    public static void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "Diamond Collect":
                source.PlayOneShot(collectDiamond);
                break;
            case "Death":
                source.PlayOneShot(playerDeath);
                break;
            case "Game Over":
                source.PlayOneShot(gameOver);
                break;
            default:
                Debug.LogError("Script: AudioManager\t Undefined sound name");
                break;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("master", volume);
        PlayerPrefs.SetFloat("MainVolume", volume);
    }
}
