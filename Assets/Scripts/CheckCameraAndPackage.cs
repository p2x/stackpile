using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCameraAndPackage : MonoBehaviour {
    public static bool isPackageSelected = false;
    public static bool isCameraEnabled = false;

    public void CheckIsPackageSelected(bool state)
    {
        isPackageSelected = state;
    }

    public void CheckIfCameraIsEnabled(bool state)
    {
        isCameraEnabled = state;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
