using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCuboidButtonInactive : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        if (SelectAndCreatePackage.amountOfCuboids == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
