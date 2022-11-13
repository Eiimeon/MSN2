using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class watch : MonoBehaviour
{

    public Rigidbody rb;
    public Camera cam;
    public Image camOverlay;
    public AudioSource SFX_Swim;
    private bool canPlaySFW_Swim = true;

    // Bool?ens
    private bool canWatch = true;

    public float forceMultiplier = 100f;
    public float dashSpeed = 2f;
    public float watchSpeed = 75f;
    public float zoomSpeed = 3;
    public float straightenSpeed = 0.2f;

    private bool canDash = true;
    private float dashTimer = 0;

    private float cruiseTimer = 0;

    private Vector3 targetRotation;
    private Vector3 angleDrift = new Vector3(1f, 1f, 0);

    private Quaternion stableRotation;

    // Start is called before the first frame update
    void Start()
    {
        camOverlay.enabled = false;
        targetRotation = transform.position;
        targetRotation = transform.rotation.eulerAngles;
    }

    public void Swim()
    {
        Vector2 leftStick = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Debug.Log("test" + leftStick.magnitude);

        // Cruise Slope

        if (leftStick.magnitude > 0.1f)
        {
            cruiseTimer += Time.deltaTime;
        }
        else
        {
            cruiseTimer = 0;
        }

        if (cruiseTimer > 1)
        {
            leftStick *= 2.5f + 1.5f * Mathf.Sin(3 * (cruiseTimer - 1 + Mathf.PI/2));
            //Mathf.Abs(Mathf.Sin(3 * (cruiseTimer - 1 + Mathf.PI/2))) < 0.1f
            if (Mathf.Sin(3 * (cruiseTimer - 1)) > 0.9f && canPlaySFW_Swim)
            {
                //Debug.Log("Swim Sound");
                SFX_Swim_Delay();
                SFX_Swim.Play();
            }
        }

        rb.AddForce(transform.right * leftStick.x * Time.deltaTime * forceMultiplier);
        rb.AddForce(transform.forward * leftStick.y * Time.deltaTime * forceMultiplier);

        //rb.AddForce(transform.right * Input.GetAxis("HorizontalL") * Time.deltaTime * forceMultiplier);
        //rb.AddForce(transform.forward * Input.GetAxis("VerticalL")* Time.deltaTime * forceMultiplier);



        if (Input.GetAxis("Jump") == 1 && canDash)
        {
            canDash = false;
            dashTimer = 1;
            Debug.Log("Jump");
            rb.AddForce(transform.forward * dashSpeed, ForceMode.Acceleration);
        }
        dashTimer -= Time.deltaTime;
        if (dashTimer < 0)
        {
            canDash = true;
        }
    }

    IEnumerator SFX_Swim_Delay()
    {
        canPlaySFW_Swim = false;
        yield return new WaitForSeconds(1f);
        canPlaySFW_Swim = true;
    }

    private void Watch()
    {
        Vector3 mouseDelta = new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        Vector3 rStick = new Vector3(-1 * Input.GetAxis("rStickY") / 3.5f, Input.GetAxis("rStickX") / 3.5f, 0);

        //Debug.Log(rStick);

        targetRotation += mouseDelta * Time.deltaTime * 3 * watchSpeed;

        if (rStick.magnitude > 0.1f)
        {
            targetRotation += rStick * Time.deltaTime * watchSpeed;
        }
        else
        {
            targetRotation += angleDrift * Time.deltaTime;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 1.5f * Time.deltaTime);
    }

    private void Zoom()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, zoomSpeed * Time.deltaTime);
            camOverlay.enabled = true;
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 100, zoomSpeed * Time.deltaTime);
            camOverlay.enabled = false;
        }
    }

    private void Straighten()
    {
        if (Input.GetAxis("Fire2") == 1)
        {
            canWatch = false;
            stableRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, stableRotation, straightenSpeed * Time.deltaTime);
            targetRotation = transform.rotation.eulerAngles;
        }
        else
        {
            canWatch = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Swim();
        if (canWatch)
        {
            Watch();
        }
        Zoom();
        Straighten();
    }
}