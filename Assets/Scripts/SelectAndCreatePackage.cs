using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Selects and instantiates prefab packages in cube or cuboid shape above the pallet.
/// </summary>
public class SelectAndCreatePackage : MonoBehaviour
{
    public static int amountOfCubes = 2;
    public static int amountOfCuboids = 2;
    public static GameObject package;
    public static bool packageSelected = false;
    
    /// <summary>
    /// Selects and instantiates a cube-shaped package.
    /// </summary>
    public void selectAndInstantiateCube()
    {
        if (packageSelected && amountOfCubes > 0)
        {
            amountOfCubes--;
            amountOfCuboids++;
            Destroy(package);
            package = Instantiate(Resources.Load("Cube")) as GameObject;
            package.transform.position = new Vector3(0, 4.5f, 0);
            package.GetComponent<Renderer>().material.color = new Color(1.000f, 0.843f, 0.000f);
        }
        else if(!packageSelected && amountOfCubes > 0)
        {
            amountOfCubes--;
            package = Instantiate(Resources.Load("Cube")) as GameObject;
            package.transform.position = new Vector3(0, 4.5f, 0);
            package.GetComponent<Renderer>().material.color = new Color(1.000f, 0.843f, 0.000f);
            packageSelected = true;
        }
        
    }

    /// <summary>
    /// Selects and instantiates a cuboid-shaped package.
    /// </summary>
    public void selectAndInstantiateCuboid()
    {
        if (packageSelected && amountOfCuboids > 0)
        {
            amountOfCuboids--;
            amountOfCubes++;
            Destroy(package);
            package = Instantiate(Resources.Load("Cuboid")) as GameObject;
            package.transform.position = new Vector3(0, 4.5f, 0);
            package.GetComponent<Renderer>().material.color = new Color(1.000f, 0.843f, 0.000f);
        }
        else if(!packageSelected && amountOfCuboids > 0)
        {
            amountOfCuboids--;
            package = Instantiate(Resources.Load("Cuboid")) as GameObject;
            package.transform.position = new Vector3(0, 4.5f, 0);
            package.GetComponent<Renderer>().material.color = new Color(1.000f, 0.843f, 0.000f);
            packageSelected = true;
        }     
    }
}

