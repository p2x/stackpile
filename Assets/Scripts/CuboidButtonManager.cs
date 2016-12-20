using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the interactíbility of the cuboid button and sets the button inactive if there is no cuboid-shaped packages left to place.
/// </summary>
public class CuboidButtonManager : MonoBehaviour
{
    private Button selectedPackage;

    // Update is called once per frame
    void Update ()
    {
        if (SelectAndCreatePackage.amountOfCuboids == 0 && !SelectAndCreatePackage.packageSelected)
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
