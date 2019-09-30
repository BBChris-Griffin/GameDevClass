using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private MovementControls gameController;
    private GameObject mainObject;
    // Start is called before the first frame update
    void Start()
    {
        // Gets information from the MovmentControls script
        GameObject gameControlObject = GameObject.FindGameObjectWithTag("GameController").gameObject;
        if(gameControlObject != null)
        {
            gameController = gameControlObject.GetComponent<MovementControls>();
        }
        mainObject = gameController.GetMainObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Allows camera to follow the main object
        this.transform.LookAt(mainObject.transform);
    }

    void Update()
    {
        // Keeps checking in case a new object is selected
        mainObject = gameController.GetMainObject();
    }
}
