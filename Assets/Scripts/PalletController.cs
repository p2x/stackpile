using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the interaction between packages on the pallet.
/// </summary>
public class PalletController : MonoBehaviour {
    private List<PackageMoveController> Packages;

    public PalletController() {
        Packages = new List<PackageMoveController>();
    }

    public void Add(PackageMoveController package) {
        Packages.Add(package);
        package.Pallet = this;
        gameObject.transform.parent = gameObject.transform;
    }

    public void Remove(PackageMoveController package) {
        Packages.Remove(package);
        package.Pallet = null;
        gameObject.transform.parent = null;
    }

    public void BeginMovePackage(PackageMoveController package) {        
        // The player can move the package without moving other packages through collision.
        foreach (var p in Packages) {
            if (!Object.ReferenceEquals(p, package)) {
                p.GetComponent<Rigidbody>().isKinematic = true;
            }
        }        
    }

    public void EndMovePackage(PackageMoveController package) {
        // The packages are now affected by physics.
        foreach (var p in Packages) {
            if (!Object.ReferenceEquals(p, package)) {
                p.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
