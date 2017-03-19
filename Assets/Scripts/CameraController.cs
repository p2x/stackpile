
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public Transform target;
    public GameObject[] moveButtons;
    public GameObject enableCameraButton;
    public GameObject disableCameraButton;
    public float speedMod = 5.0f;
    private bool isCameraEnabled;
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

    public void EnableCamera()
    {
        if (!PackageListController.isPackageSelected)
        {
            isCameraEnabled = true;
            disableCameraButton.SetActive(false);
            enableCameraButton.SetActive(true);
            for (int i = 0; i < moveButtons.Length; i++)
            {
                moveButtons[i].SetActive(true);
            }
        }
    }

    public void DisableCamera()
    {
        isCameraEnabled = false;
        disableCameraButton.SetActive(true);
        enableCameraButton.SetActive(false);
        for (int i = 0; i < moveButtons.Length; i++)
        {
            moveButtons[i].SetActive(false);
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
        if(isRotatingRight)
        {
            transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime * speedMod);
        }
        else if (isRotatingLeft)
        {
            transform.RotateAround(point, Vector3.down, 20 * Time.deltaTime * speedMod);
        }
        else if (isMovingDown && transform.position.y >= 9.25)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speedMod);
        }
        else if (isMovingUp && transform.position.y <= 13)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedMod);
        }
    }

    public void EnableDisableUpDownButtons()
    {   
        if(isCameraEnabled)
        {
            if (transform.position.y > 9.25 && transform.position.y < 13)
            {
                moveButtons[2].SetActive(true);
                moveButtons[3].SetActive(true);
            }
            else if (transform.position.y > 13)
            {
                moveButtons[2].SetActive(false);
                ChangeMovingUpState(false);
            }
            else if (transform.position.y < 9.25)
            {
                moveButtons[3].SetActive(false);
                ChangeMovingDownState(false);
            }           
        }        
    }
    void Update()
    {
        MoveCamera();
        EnableDisableUpDownButtons();
    }
}