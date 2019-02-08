using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 3f;
    public float distanceToRise = 40f;


    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsStanding()
    {
        float tiltX = (transform.eulerAngles.x < 180f) ? transform.eulerAngles.x : 360 - transform.eulerAngles.x;
        float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;

      
        if (tiltX > standingThreshold || tiltZ > standingThreshold)
        {
            return true;
        }

        return false;
    } 
    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigidbody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRise, 0), Space.World);
        }
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, -distanceToRise, 0), Space.World);
        rigidbody.useGravity = true;
    }
}
