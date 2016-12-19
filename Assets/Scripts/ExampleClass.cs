using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {

    public float speed = 0.1F;
    Vector2 pressTouch0;
    Vector2 releaseTouch0;
    Vector2 pressTouch1;
    Vector2 releaseTouch1;

    void Update() {
        Touch[] touch = Input.touches;
        if (touch.Length == 1) {
            //Debug.Log("x" + Input.GetTouch(0).deltaPosition.x);
            //Debug.Log("y" + Input.GetTouch(0).deltaPosition.y);
            //Drag(touch);
        } else if (touch.Length == 2) {
            Rotate(touch);
        }
    }

    void Drag(Touch[] touch) {
        Camera dragCam = GameObject.Find("DragCam").GetComponent<Camera>();
        if (touch[0].phase == TouchPhase.Moved) {
            //Vector3 touchDeltaPosition = dragCam.ScreenToWorldPoint(new Vector3());
            //this.gameObject.transform.Translate(touchDeltaPosition.x, 3, touchDeltaPosition.z);
            //transform.position = new Vector3(touchDeltaPosition.x, 3, touchDeltaPosition.z);
            Vector3 pos = dragCam.ScreenToViewportPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, 3, pos.z);
        }
    }

    void Rotate(Touch[] touch) {
        if (touch[0].phase == TouchPhase.Began) {
            pressTouch0 = touch[0].position;
        }
        if (touch[1].phase == TouchPhase.Began) {
            pressTouch1 = touch[1].position;
        }
        if (touch[0].phase == TouchPhase.Ended || touch[0].phase != TouchPhase.Canceled
            && touch[1].phase == TouchPhase.Ended && touch[1].phase != TouchPhase.Canceled) {
            releaseTouch0 = touch[0].position;
            //print("diff Touch 0 x = " + Mathf.Abs(pressTouch0.x - releaseTouch0.x));
            //print("diff Touch 0 y = " + Mathf.Abs(pressTouch0.y - releaseTouch0.y));
            releaseTouch1 = touch[1].position;
            //print("diff Touch 1 x = " + Mathf.Abs(pressTouch1.x - releaseTouch1.x));
            //print("diff Touch 1 y = " + Mathf.Abs(pressTouch1.y - releaseTouch1.y));

            if (Mathf.Abs(pressTouch0.x - releaseTouch0.x) > Mathf.Abs(pressTouch0.y - releaseTouch0.y)
                || Mathf.Abs(pressTouch1.x - releaseTouch1.x) > Mathf.Abs(pressTouch1.y - releaseTouch1.y)) {
                if ((pressTouch0.x - releaseTouch0.x) > 0 || (pressTouch1.x - releaseTouch1.x) > 0) {
                    Debug.Log("Left");

                } else {
                    Debug.Log("Right");
                }
            } else if (Mathf.Abs(pressTouch0.x - releaseTouch0.x) < Mathf.Abs(pressTouch0.y - releaseTouch0.y)
                || Mathf.Abs(pressTouch1.x - releaseTouch1.x) < Mathf.Abs(pressTouch1.y - releaseTouch1.y)) {
                if ((pressTouch0.y - releaseTouch0.y) > 0 || (pressTouch1.y - releaseTouch1.y) > 0) {
                    Debug.Log("Down");
                } else {
                    Debug.Log("Up");
                }
            }

        }
        //if (touch[1].phase == TouchPhase.Ended && touch[1].phase != TouchPhase.Canceled) {
        //    releaseTouch1 = touch[1].position;
        //    print("diff Touch 1 x = " + Mathf.Abs(pressTouch1.x - releaseTouch1.x));
        //    print("diff Touch 1 y = " + Mathf.Abs(pressTouch1.y - releaseTouch1.y));
        //}
    }
}