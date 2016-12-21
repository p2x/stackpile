using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private Rigidbody gameObj;


	void Start () {
		
	}
	
	void Update () {
        gameObj = GetComponent<Rigidbody>();
        if (Input.touchCount == 1) {
            swipe();
        }
	}

    void swipe() {
        Vector2 delta = Input.GetTouch(0).deltaPosition;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
            if (delta.x > 0) { //Right

            } else { //Left

            }
        } else {
            if (delta.y > 0) { //Up

            } else { //Down

            }
        }
    }
}
