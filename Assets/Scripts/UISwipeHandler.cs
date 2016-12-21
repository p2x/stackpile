using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler {

    public GameObject cube;

    public void OnBeginDrag(PointerEventData eventData) {

        //cube = Instantiate(Resources.Load("Cube")) as GameObject;

        Vector2 delta = eventData.delta;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
            if (delta.x > 0) { //Right
                cube.transform.Rotate(Vector3.up, 90.0f);
            } else { //Left
                cube.transform.Rotate(-Vector3.up, 90.0f);
            }
        } else {
            if (delta.y > 0) { //Up
                cube.transform.Rotate(Vector3.forward, 90.0f);
            } else { //Down
                cube.transform.Rotate(-Vector3.up, 90.0f);
            }
        }
    }

    public void OnDrag(PointerEventData eventData) {
        
    }
}
