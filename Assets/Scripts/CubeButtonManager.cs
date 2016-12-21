using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the interactíbility of the cube button and sets the button inactive if there is no cube-shaped packages left to place.
/// </summary>
public class CubeButtonManager : MonoBehaviour
{
    private Button selectedPackage;

    // Update is called once per frame
    void Update()
    {   
        if(SelectAndCreatePackage.amountOfCubes == 0 && !SelectAndCreatePackage.packageSelected)
        {
            gameObject.SetActive(false);
        }
        if (!SelectAndCreatePackage.packageSelected)
        {
            selectedPackage = gameObject.GetComponent<Button>();
            selectedPackage.interactable = true;
        }
    }   
}
