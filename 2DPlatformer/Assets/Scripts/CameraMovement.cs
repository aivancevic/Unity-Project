using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speedStart;
    [SerializeField] private float increasePerSecond;
    private float secondsElapsed = 0;
    private bool spaceCheck;
    private bool canCameraSpeedUp;
    [SerializeField] private Text startGame;


    private void Awake()
    {
        spaceCheck = true;
        canCameraSpeedUp = false;
    }
    
    void Update()
    {

        if (spaceCheck && Input.GetKeyDown(KeyCode.Space))
        {
            canCameraSpeedUp = true;
            spaceCheck = false;
            startGame.gameObject.SetActive(false);
        }
        SpeedUpCamera();
    }

    private void SpeedUpCamera()
    {
        if (canCameraSpeedUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * (increasePerSecond * secondsElapsed + speedStart));
            secondsElapsed += Time.deltaTime / 3;
        }
    }
}
