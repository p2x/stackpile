using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRotateZoom : MonoBehaviour {

    private Rigidbody gameObj;

    // Update is called once per frame
    void Update () {
        gameObj = GetComponent<Rigidbody>();
        if (Input.touchCount > 0) {
            Rotate();
        }
	}

    void Rotate() {
        Vector2 finger1 = Input.GetTouch(0).deltaPosition;
        //Vector2 finger2 = Input.GetTouch(1).deltaPosition;
        if (Mathf.Abs(finger1.x) > Mathf.Abs(finger1.y)) {
            if (finger1.x > 0) { //Right
                gameObj.transform.Rotate(Vector3.up, 90.0f);
                Debug.Log("Right");
            } else { //Left
                gameObj.transform.Rotate(-Vector3.up, 90.0f);
                Debug.Log("Left");
            }
        } else {
            if (finger1.y > 0) { //Up
                gameObj.transform.Rotate(Vector3.forward, 90.0f);
                Debug.Log("Up");
            } else { //Down
                gameObj.transform.Rotate(-Vector3.forward, 90.0f);
                Debug.Log("Down");
            }
        }
    } 
}
