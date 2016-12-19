using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Rigidbody cube;

    void Update () {
        cube = GetComponent<Rigidbody>();
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
            cube.transform.Rotate(Vector3.left, 90.0f);
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
            cube.transform.Rotate(Vector3.right, 90.0f);
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Up))
            cube.transform.Rotate(Vector3.up, 90.0f);
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Down))
            cube.transform.Rotate(Vector3.down, 90.0f);
    }
}
