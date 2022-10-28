using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class playerMove1 : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public Transform parentTrf;

    private Vector2 velocity = Vector2.zero;
    private Vector2 frameVelocity;

    public float forceFactor = 0.95f;
    public float lookSpeed = 5000000000f;
    public float sensi = 2;
    public float smoothing = 1.5f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private float newAngleX = 0f;
    private float newAngleY = 0f;

    private float deltaRX = 0f;
    private float previousMouseX = 0;
    private float previousMouseY = 0;

    // Start is called before the first frame update
    void Start()
    {
        //parentTrf = GetComponentInParent(typeof(Transform));
    }

    private void Move()
    {
        rb.AddForce(transform.forward * forceFactor * Input.GetAxis("Vertical"));
        rb.AddForce(transform.right * forceFactor * Input.GetAxis("Horizontal"));

        
    }

    private void Watch()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensi);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        //rb.AddTorque(transform.up * Time.deltaTime * mouseDelta);

        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        cam.transform.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        /*deltaRX = rotationX;

        rotationX = -1 * (previousMouseX - Input.GetAxis("Mouse X"));
        rotationY = 1 * (previousMouseY - Input.GetAxis("Mouse Y"));

        //rotationY += Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        deltaRX = rotationX - deltaRX;

        newAngleX = transform.eulerAngles.x + rotationX;
        newAngleY = transform.eulerAngles.y + rotationY;

        transform.Rotate(transform.up, rotationX);
        transform.Rotate(transform.right, rotationY);*/

        // previousMouseX = Input.GetAxis("Mouse X");
        // previousMouseY = Input.GetAxis("Mouse Y");

        // transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.right);
        // transform.eulerAngles = new Vector3(rotationX, rotationY, 0f);
        //transform.eulerAngles = new Vector3(newAngleX, newAngleY, 0f);

        //transform.Rotate(-transform.up * rotationY);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Watch();
    }

    private void FixedUpdate()
    {
        // Custom drag
        //rb.velocity = rb.velocity * 0.98f;
    }
}
