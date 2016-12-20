using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectAndCreatePackage : MonoBehaviour {
    public static int amountOfCubes = 2;
    public static int amountOfCuboids = 2;
    public static GameObject package;
    public static bool packageSelected = false;
    //private enum PackageShape {CUBE = 1, CUBOID = 2};
    //public static int shapeIndex;

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
            //shapeIndex = (int)PackageShape.CUBE;
        }
        else if(!packageSelected && amountOfCubes > 0)
        {
            amountOfCubes--;
            package = Instantiate(Resources.Load("Cube")) as GameObject;
            package.transform.position = new Vector3(0, 4.5f, 0);
            package.GetComponent<Renderer>().material.color = new Color(1.000f, 0.843f, 0.000f);
            //shapeIndex = (int)PackageShape.CUBE;
            packageSelected = true;
        }
        
    }

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
            //shapeIndex = (int)PackageShape.CUBOID;
        }
        else if(!packageSelected && amountOfCuboids > 0)
        {
            amountOfCuboids--;
            package = Instantiate(Resources.Load("Cuboid")) as GameObject;
            package.transform.position = new Vector3(0, 4.5f, 0);
            package.GetComponent<Renderer>().material.color = new Color(1.000f, 0.843f, 0.000f);
            //shapeIndex = (int)PackageShape.CUBOID;
            packageSelected = true;
        }     
    }

    public void Update()
    {   
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {   
            package.transform.Rotate(45, 0, 0);
            //cube.transform.Rotate(Vector3.right, Time.deltaTime * 100f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            package.transform.Rotate(-45, 0, 0);
            //cube.transform.Rotate(Vector3.left, Time.deltaTime * 100f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            package.transform.Rotate(0, 45, 0);
            //cube.transform.Rotate(Vector3.up, Time.deltaTime * 100f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            package.transform.Rotate(0, -45, 0);
            //cube.transform.Rotate(Vector3.down, Time.deltaTime * 100f);
        }

        /*if (Input.GetAxis("Mouse Y") < 0 && Input.GetKey(KeyCode.Mouse0))
        {
            //cube.transform.Rotate(Vector3.up, Time.deltaTime * 100f);
            cube.transform.Rotate(-45, 0, 0);
        }
        else if (Input.GetAxis("Mouse Y") > 0 && Input.GetKey(KeyCode.Mouse0))
        {
            //cube.transform.Rotate(Vector3.down, Time.deltaTime * 100f);
            cube.transform.Rotate(45, 0, 0);
        }
        else if (Input.GetAxis("Mouse X") > 0 && Input.GetKey(KeyCode.Mouse0))
        {
            //cube.transform.Rotate(Vector3.right, Time.deltaTime * 100f);
            cube.transform.Rotate(0, -45, 0);
        }
        else if (Input.GetAxis("Mouse X") < 0 && Input.GetKey(KeyCode.Mouse0))
        {
            //cube.transform.Rotate(Vector3.left, Time.deltaTime * 100f);
            cube.transform.Rotate(0, 45, 0);
        }*/
    }
}

