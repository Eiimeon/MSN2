using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scan : MonoBehaviour
{
    public PhysicMaterial testMaterial;

    public Camera cam;
    public MeshCollider SightCollider;
    public Canvas helmetUI;
    public Image lt;
    public Image rt;
    public Image A;

    // Logs
    public Image bLog;
    public Image cLog;
    public Image vLog;
    public Image tLog;
    public Image hLog0;
    public Image hLog1;
    public Image hLog2;
    public Image hLog3;
    public Image hLog4;

    public Text counter;

    //private Image[] logs = new ArrayList( bLog, cLog, vLog);

    private bool[] readLogs = new bool[7];
    private int nReadLogs = 0;

    private Collider currentlyWatchedCollider;

    private int layerMask = 1;

    // Start is called before the first frame update
    void Start()
    {
        SightCollider = GetComponentInChildren<MeshCollider>();
        lt.enabled = false; 
        rt.enabled = false;
        for (int i = 0; i<7; i++)
        {
            readLogs[i] = false;
        }
        HideLogs();
    }

    void HideLogs()
    {
        bLog.enabled = false;
        cLog.enabled = false;
        vLog.enabled = false;
        tLog.enabled = false;
        hLog0.enabled = false;
        hLog1.enabled = false;
        hLog2.enabled = false;
        hLog3.enabled = false;
        hLog4.enabled = false;
        A.enabled = false;

    }
    private void OnTriggerStay (Collider other)
    {
        if (!Physics.Linecast(cam.transform.position, other.transform.position, layerMask))
        {
            lt.enabled = true;
            currentlyWatchedCollider = other;
            Debug.Log(other.name);
        }
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

        if (rt.enabled && Input.GetAxis("Fire3") == 1)
        {
            //currentlyWatchedCollider.gameObject.SetActive(false);
            A.enabled = true;
            switch (currentlyWatchedCollider.name[0])
            {
                case 'B':
                    bLog.enabled = true;
                    readLogs[0] = true;
                    break;
                case 'C':
                    cLog.enabled = true;
                    readLogs[1] = true;
                    break;
                case 'V':
                    vLog.enabled = true;
                    readLogs[2] = true;
                    break;
                case 'T':
                    tLog.enabled = true;
                    readLogs[3] = true;
                    break;
                case '0':
                    hLog0.enabled = true;
                    readLogs[4] = true;
                    break;
                case '1':
                    hLog1.enabled = true;
                    readLogs[5] = true;
                    break;
                case '2':
                    hLog2.enabled = true;
                    readLogs[6] = true;
                    break;
                case '3':
                    hLog3.enabled = true;
                    readLogs[7] = true;
                    break;
                case '4':
                    hLog4.enabled = true;
                    readLogs[8] = true;
                    break;
            }
            nReadLogs = 0;
            for (int i = 0; i < 7; i++)
            {
                if (readLogs[i])
                {
                    nReadLogs++;
                }
            }
            counter.text = nReadLogs + "/7";
            Debug.Log(counter.text);
        }
        if (Input.GetAxis("Submit") == 1)
        {
            HideLogs();
        }
    }
}
