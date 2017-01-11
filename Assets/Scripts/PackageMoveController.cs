using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Controls the movement of the package on the pallet.
/// </summary>
public class PackageMoveController : MonoBehaviour {
    /// <summary>
    /// The speed with which the pallet is moved.
    /// </summary>
    public float Speed;

    /// <summary>
    /// Fires when the package is moved for the first time.
    /// </summary>
    public event UnityAction InitiallyMoved {
        add { if (!WasInitiallyMoved) InitiallyMovedEvent += value; }
        remove { InitiallyMovedEvent -= value; }
    }

    /// <summary>
    /// Enabled or disables movement.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// The pallet that contains the package or null if the package is not assigned to a pallet.
    /// </summary>
    public PalletController Pallet { get; set; }

    private Rigidbody Rigidbody;
    private bool WasInitiallyMoved;
    private event UnityAction InitiallyMovedEvent;

    private void Start() {        
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown() {
        if (!Enabled || Pallet == null)
            return;
        CheckInitialMove();
        Pallet.BeginMovePackage(this);
    }

    private void OnMouseDrag() {
        if (!Enabled || Pallet == null)
            return;
        var currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));     
        Rigidbody.velocity = (currentMousePosition - Rigidbody.position) * Speed; 
    }

    private void OnMouseUp() {
        if (!Enabled || Pallet == null)
            return;
        Rigidbody.velocity = Vector3.zero;
        Pallet.EndMovePackage(this);
    }

    private void CheckInitialMove() {
        if (!WasInitiallyMoved) {
            Rigidbody.isKinematic = false;
            WasInitiallyMoved = true;
            var initiallyMovedEvent = InitiallyMovedEvent;
            if (initiallyMovedEvent != null) {
                initiallyMovedEvent();
                initiallyMovedEvent = null;
            }
        }
    }
}