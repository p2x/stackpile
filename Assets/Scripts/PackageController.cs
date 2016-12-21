using UnityEngine;
using System.Collections;

public class PackageController : MonoBehaviour {
    public float Speed;

    private Vector3 MouseDownPosition;
    private Rigidbody Rigidbody;
    private RigidbodyConstraints OriginalRigidbodyConstraints;


    // Use this for initialization
    private void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        OriginalRigidbodyConstraints = Rigidbody.constraints;
        Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnMouseDown() {
        Rigidbody.isKinematic = false;
        Rigidbody.constraints = OriginalRigidbodyConstraints;
    }

    private void OnMouseDrag() {
        var currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));     
        Rigidbody.velocity = (currentMousePosition - Rigidbody.position) * Speed; 
    }

    private void OnMouseUp() {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.isKinematic = true;
        Rigidbody.constraints = RigidbodyConstraints.FreezeAll;      
    }
}