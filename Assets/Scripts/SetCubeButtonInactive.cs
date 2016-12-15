using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCubeButtonInactive : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {   
        if(SelectAndCreatePackage.amountOfCubes == 0)
        {
            gameObject.SetActive(false);
        }       
    }   
}
