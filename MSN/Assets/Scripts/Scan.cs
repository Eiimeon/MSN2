using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scan : MonoBehaviour
{

    public Camera cam;
    public MeshCollider SightCollider;
    public Canvas helmetUI;
    public Image lt;
    public Image rt;

    // Logs
    public Image bLog;
    public Image cLog;
    public Image vLog;

    //private Image[] logs = new ArrayList( bLog, cLog, vLog);

    private Collider currentlyWatchedCollider;

    // Start is called before the first frame update
    void Start()
    {
        SightCollider = GetComponentInChildren<MeshCollider>();
        lt.enabled = false; 
        rt.enabled = false;
    }

    private void OnTriggerStay (Collider other)
    {
        lt.enabled = true;
        currentlyWatchedCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        lt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lt.enabled && cam.fieldOfView < 70)
        {
            rt.enabled = true;
        }
        else
        {
            rt.enabled = false;
        }
    }
}
