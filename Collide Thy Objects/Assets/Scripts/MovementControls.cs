using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    public float speed;
    private GameObject[] spheres;
    private GameObject[] cubes;
    private GameObject[] objects;
    private GameObject mainObject;

    // Start is called before the first frame update
    void Awake()
    {
        // Finds all spheres and cubes and selects the default object.
        spheres = GameObject.FindGameObjectsWithTag("Sphere");
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        mainObject = spheres[0];
    }

    // Update is called once per frame
    void Update()
    {

        // Pefroms Movement
        float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        mainObject.transform.Translate(translationX, 0, translationY);

        // Prevents the spheres and cubes from rotating. That can make invert the controls.
        for(int i = 0; i < spheres.Length; i++)
        {
            spheres[i].transform.localRotation = Quaternion.identity;
        }
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.localRotation = Quaternion.identity;
        }

        // The spheres have a habit from continuing to roll after being hit. IsKinematic stops that.
        if (mainObject.tag == "Sphere")
        {
            mainObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        // Switches between Spheres and cubes
        if (Input.GetKeyDown(KeyCode.S))
        {
            mainObject.GetComponent<Rigidbody>().isKinematic = false;
            mainObject = spheres[Random.Range(0, spheres.Length)];
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            mainObject.GetComponent<Rigidbody>().isKinematic = false;
            mainObject = cubes[Random.Range(0, cubes.Length)];
        }

        // Decreases speed
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            speed += 5;
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed -= 5;
        }
    }

    public GameObject GetMainObject()
    {
        return mainObject;
    }
}
