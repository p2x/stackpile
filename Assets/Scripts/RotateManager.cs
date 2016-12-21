using UnityEngine;
using System.Collections;

public class RotateManager : MonoBehaviour {
    
    Vector2 pressTouch0;
    Vector2 releaseTouch0;
    Vector2 pressTouch1;
    Vector2 releaseTouch1;

    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;

    void Update() {
        Touch[] touch = Input.touches;
        if (touch.Length == 2) {
            Rotate(touch);
        }
    }


    /*
     * methode used to rotate an object using two fingers.
     * the object can be rotate in four directions (up, right, down, left).
     */
    void Rotate(Touch[] touch) {
        if (touch[0].phase == TouchPhase.Began) {
            pressTouch0 = touch[0].position;
        }
        if (touch[1].phase == TouchPhase.Began) {
            pressTouch1 = touch[1].position;
        }
        if (touch[0].phase == TouchPhase.Ended && touch[0].phase != TouchPhase.Canceled
            || touch[1].phase == TouchPhase.Ended && touch[1].phase != TouchPhase.Canceled) {
            releaseTouch0 = touch[0].position;
            releaseTouch1 = touch[1].position;

            if (Mathf.Abs(pressTouch0.x - releaseTouch0.x) > Mathf.Abs(pressTouch0.y - releaseTouch0.y)
                || Mathf.Abs(pressTouch1.x - releaseTouch1.x) > Mathf.Abs(pressTouch1.y - releaseTouch1.y)) {
                if ((pressTouch0.x - releaseTouch0.x) > 0 && (pressTouch1.x - releaseTouch1.x) > 0) {
                    Debug.Log("Left");
                    transform.Rotate(0, 90, 0, Space.World);
                } else {
                    Debug.Log("Right");
                    transform.Rotate(0, -90, 0, Space.World);
                }
            } else if (Mathf.Abs(pressTouch0.x - releaseTouch0.x) < Mathf.Abs(pressTouch0.y - releaseTouch0.y)
                || Mathf.Abs(pressTouch1.x - releaseTouch1.x) < Mathf.Abs(pressTouch1.y - releaseTouch1.y)) {
                if ((pressTouch0.y - releaseTouch0.y) > 0 && (pressTouch1.y - releaseTouch1.y) > 0) {
                    Debug.Log("Down");
                    transform.Rotate(90, 0, 0, Space.World);
                } else {
                    Debug.Log("Up");
                    transform.Rotate(-90, 0, 0, Space.World);
                }
            }

        }
    }
}