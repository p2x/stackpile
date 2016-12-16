using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeButtonManager : MonoBehaviour {
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
