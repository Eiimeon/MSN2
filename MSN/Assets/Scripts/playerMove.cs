using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;

    public float speedFactor = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");

        Vector2 inputVector = context.ReadValue<Vector2>();

        Vector3 directionVector = new Vector3(inputVector.x, 0, inputVector.y);

        Vector3 rotatedDirectionVector = new Vector3();

        // directionVector = Vector3.RotateTowards(directionVector, cam.transform.rotation);

        Debug.Log(inputVector);
        rb.AddForce(gameObject.transform.rotation *  directionVector * speedFactor);
    }*/



    public void Watch(InputAction.CallbackContext context)
    {
        Debug.Log("Watch");

        Vector2 watchVector = context.ReadValue<Vector2>();

        //Vector3 directionVector = new Vector3(inputVector.x, 0, inputVector.y);

        //Vector3 rotatedDirectionVector = new Vector3();

        // directionVector = Vector3.RotateTowards(directionVector, cam.transform.rotation);

        Debug.Log(watchVector);
        //rb.AddForce(speedFactor * watchVector);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.transform.rotation);
    }
}
