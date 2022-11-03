using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatresMove : MonoBehaviour
{
    private float startTime = Time.time;
    private Vector3 targetPosition = Vector3.zero;
    private Vector3 additionnalPosition = Vector3.zero;

    public float frequency;
    public float amplitude;
    public float speed = 1;
    public float duration;
    public float internalTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(name);
        targetPosition = transform.position;
    }

    private void VirusMove()
    {
        //Debug.Log("VirusMove");
        additionnalPosition.z += speed * Time.deltaTime;
        Debug.Log(additionnalPosition);
        additionnalPosition = transform.rotation * additionnalPosition;
        transform.position += additionnalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (name[0] == 'V')
        {
            VirusMove();
        }
    }
}
