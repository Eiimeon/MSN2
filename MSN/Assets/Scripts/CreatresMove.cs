using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatresMove : MonoBehaviour
{
    //private float startTime = Time.time;
    private Vector3 targetPosition = Vector3.zero;
    private Vector3 additionnalPosition = Vector3.zero;

    private Vector3 direction;

    private float baseX;
    private float baseY;
    private float baseZ;

    private bool isGoingForward = true;

    public float rotationSpeed = 1;
    public float frequency;
    public float amplitude;
    public float phase;
    public float speed = 1f;
    public float duration = Mathf.PI;
    public float internalTimer = 0;
    public float radius = 20;
    // Start is called before the first frame update
    void Start()
    {
        baseX = transform.position.x;
        baseY = transform.position.y;
        baseZ = transform.position.z;
        direction = transform.forward;
        //Debug.Log(direction);

        //Debug.Log(name);
        //targetPosition = transform.position;
    }

    private void VirusMove()
    {
        internalTimer += Time.deltaTime;
        if (internalTimer > duration)
        {
            internalTimer = 0;
            if (isGoingForward)
            {
                isGoingForward = false;
            }
            else
            {
                isGoingForward = true;
            }
            //isGoingForward = (Math.Pow(isGoingForward - 1), 2);
            Debug.Log(isGoingForward);
        }
        //Debug.Log("VirusMove");
        //Debug.Log(speed * direction);
        if (isGoingForward)
        {
            transform.position += speed * Time.deltaTime * direction + amplitude * Mathf.Sin(frequency * Time.time - phase) * Vector3.up;
        }
        else
        {
            transform.position += -1 * speed * Time.deltaTime * direction + amplitude * Mathf.Sin(frequency * Time.time - phase) * Vector3.up;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotationSpeed * Time.time, transform.rotation.eulerAngles.z);
    }

    private void BacteriaMove()
    {
        internalTimer += Time.deltaTime;
        if (internalTimer > duration)
        {
            internalTimer = 0;
            if (isGoingForward)
            {
                isGoingForward = false;
            }
            else
            {
                isGoingForward = true;
            }
            //isGoingForward = (Math.Pow(isGoingForward - 1), 2);
            Debug.Log(isGoingForward);
        }
        //Debug.Log("VirusMove");
        Debug.Log(speed * direction);
        if (isGoingForward)
        {
            transform.position += speed * Time.deltaTime * direction + amplitude * Mathf.Sin(frequency * Time.time) * Vector3.up;
        }
        else
        {
            transform.position += -1 * speed * Time.deltaTime * direction + amplitude * Mathf.Sin(frequency * Time.time) * Vector3.up;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationSpeed * Time.time);
    }

    private void CellMove()
    {
        targetPosition.x = baseX + radius * Mathf.Cos(frequency * Time.time);
        targetPosition.y = baseY;
        targetPosition.z = baseZ + radius * Mathf.Sin(frequency * Time.time);
        transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (name[0] == 'V')
        {
            VirusMove();
        }
        if (name[0] == 'B')
        {
            BacteriaMove();
        }
        if (name[0] == 'C')
        {
            CellMove();
        }
    }
}