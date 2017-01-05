using UnityEngine;
using System.Collections;

public class PackageController : MonoBehaviour {
    public float Speed;
    public PalletController Pallet;

    private Rigidbody Rigidbody;


    // Use this for initialization
    private void Start() {
        Pallet.Add(this);
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown() {
        Pallet.BeginMovePackage(this);
    }

    private void OnMouseDrag() {
        var currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));     
        Rigidbody.velocity = (currentMousePosition - Rigidbody.position) * Speed; 
    }

    private void OnMouseUp() {
        Rigidbody.velocity = Vector3.zero;
        Pallet.EndMovePackage(this);
    }
}