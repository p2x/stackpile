using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays amount of packages left to place on the pallet.
/// </summary>
public class AmountOfPackagesLeft : MonoBehaviour
{
    Text text;

    /// <summary>
    /// Displays amount of cube-shaped packages left to place.
    /// </summary>
    public void displayAmountOfCubes()
    {
        text = gameObject.GetComponent<Text>();
        text.text = SelectAndCreatePackage.amountOfCubes + "x";
    }
    
    /// <summary>
    /// Displays amount of cuboid-shaped packages left to place.
    /// </summary>
    public void displayAmountOfCuboids()
    {
        text = gameObject.GetComponent<Text>();      
        text.text = SelectAndCreatePackage.amountOfCuboids + "x";
    }
}
