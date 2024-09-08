using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shoot_detect : MonoBehaviour
{
    public CameraShake cams;
    public ThirdPersonOrbitCamBasic tpc;
    public float mag;
    public float dur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(cams.Shake(dur, mag));
            tpc.enabled = false;
            Debug.Log("Shaking");

        }
        tpc.enabled=true;
    }
}
