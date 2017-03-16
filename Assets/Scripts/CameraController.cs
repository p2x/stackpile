
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public Transform target;
    public GameObject[] moveButtons;
    public Button cameraButton;
    public Sprite enableCamera;
    public Sprite disableCamera;
    public float speedMod = 5.0f;
    private bool isCameraEnabled = false;
    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;
    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private Vector3 point;

    void Start()
    {
        point = target.transform.position;
        transform.LookAt(point);
    }

    public void SwitchCameraState()
    {
        isCameraEnabled = !isCameraEnabled;
        if (isCameraEnabled)
        {
            cameraButton.image.overrideSprite = enableCamera;
        }
        else
        {
            cameraButton.image.overrideSprite = disableCamera;
        }
        for(int i = 0; i < moveButtons.Length; i++)
        {
            moveButtons[i].active = !moveButtons[i].active;
        }
    }

    public void SwitchRotatingRightState()
    {
        isRotatingRight = !isRotatingRight;
    }

    public void SwitchRotatingLeftState()
    {
        isRotatingLeft = !isRotatingLeft;
    }

    public void SwitchMoveUpState()
    {
        isMovingUp = !isMovingUp;
    }

    public void SwitchMoveDownState()
    {
        isMovingDown = !isMovingDown;
    }

    public void MoveCamera()
    {
        if(isCameraEnabled && isRotatingRight)
        {
            transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime * speedMod);
        }
        if (isCameraEnabled && isRotatingLeft)
        {
            transform.RotateAround(point, Vector3.down, 20 * Time.deltaTime * speedMod);
        }
        if (isCameraEnabled && isMovingDown && transform.position.y >= 9.25)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speedMod);
        }
        if (isCameraEnabled && isMovingUp && transform.position.y <= 13)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedMod);
        }
    }
    void Update()
    {
        MoveCamera();
    }
}