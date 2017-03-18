
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public Transform target;
    public GameObject[] moveButtons;
    public Button cameraButton;
    public Sprite enableCamera;
    public Sprite disableCamera;
    public float speedMod = 5.0f;
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

    public void EnableDisableMoveButtons()
    {
        CheckCameraAndPackage.isCameraEnabled = !CheckCameraAndPackage.isCameraEnabled;
        if (CheckCameraAndPackage.isCameraEnabled && !CheckCameraAndPackage.isPackageSelected)
        {
            cameraButton.image.overrideSprite = enableCamera;
            for (int i = 0; i < moveButtons.Length; i++)
            {
                moveButtons[i].SetActive(true);
            }
        }
        else
        {
            cameraButton.image.overrideSprite = disableCamera;
            for (int i = 0; i < moveButtons.Length; i++)
            {
                moveButtons[i].SetActive(false);
            }
        }
    }

    public void ChangeRotatingRightState(bool state)
    {
        isRotatingRight = state;
    }

    public void ChangeRotatingLeftState(bool state)
    {
        isRotatingLeft = state;
    }

    public void ChangeMovingUpState(bool state)
    {
        isMovingUp = state;
    }

    public void ChangeMovingDownState(bool state)
    {
        isMovingDown = state;
    }

    public void MoveCamera()
    {
        if(CheckCameraAndPackage.isCameraEnabled && isRotatingRight)
        {
            transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime * speedMod);
        }
        else if (CheckCameraAndPackage.isCameraEnabled && isRotatingLeft)
        {
            transform.RotateAround(point, Vector3.down, 20 * Time.deltaTime * speedMod);
        }
        else if (CheckCameraAndPackage.isCameraEnabled && isMovingDown && transform.position.y >= 9.25)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speedMod);
        }
        else if (CheckCameraAndPackage.isCameraEnabled && isMovingUp && transform.position.y <= 13)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedMod);
        }
    }

    public void EnableDisableUpDownButtons()
    {
        if(CheckCameraAndPackage.isCameraEnabled && transform.position.y > 13)
        {
            moveButtons[2].SetActive(false);
            ChangeMovingUpState(false);
        }
        else if(CheckCameraAndPackage.isCameraEnabled && transform.position.y < 9.25)
        {
            moveButtons[3].SetActive(false);
            ChangeMovingDownState(false);
        }
        else if(CheckCameraAndPackage.isCameraEnabled && transform.position.y > 9.25 && transform.position.y < 13)
        {
            moveButtons[2].SetActive(true);
            moveButtons[3].SetActive(true);
        }
    }
    void Update()
    {
        MoveCamera();
        EnableDisableUpDownButtons();
    }
}