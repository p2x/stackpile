using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountOfPackagesLeft : MonoBehaviour {
    Text text;

    public void displayAmountOfCubes()
    {
        text = gameObject.GetComponent<Text>();
        text.text = SelectAndCreatePackage.amountOfCubes + "x";
    }

    public void displayAmountOfCuboids()
    {
        text = gameObject.GetComponent<Text>();      
        text.text = SelectAndCreatePackage.amountOfCuboids + "x";
    }
}
