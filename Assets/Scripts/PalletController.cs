using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletController : MonoBehaviour {
    private List<PackageController> Packages;

    public PalletController() {
        Packages = new List<PackageController>();
    }

    public void Add(PackageController package) {
        Packages.Add(package);
    }

    public void BeginMovePackage(PackageController package) {
        foreach (var p in Packages) {
            if (!Object.ReferenceEquals(p, package)) {
                p.GetComponent<Rigidbody>().isKinematic = true;
            }
        }        
    }

    public void EndMovePackage(PackageController package) {
        foreach (var p in Packages) {
            if (!Object.ReferenceEquals(p, package)) {
                p.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
