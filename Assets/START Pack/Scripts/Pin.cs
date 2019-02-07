using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 3f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        print(name + IsStanding());
    }

    public bool IsStanding()
    {
        float tiltX = (transform.eulerAngles.x < 180f) ? transform.eulerAngles.x : 360 - transform.eulerAngles.x;
        float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;

       // print(name + tiltX + "    " + tiltZ);

        if (tiltX > standingThreshold || tiltZ > standingThreshold)
        {
            return true;
        }

        return false;
    } 
}
